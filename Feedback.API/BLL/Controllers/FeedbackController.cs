using Amazon.Runtime.Internal;
using Feedback.API.BLL.Services.IServices;
using Feedback.API.DAL.Dtos;
using Feedback.API.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.API.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ILogger<FeedbackController> _logger;

        private IFeedbackService _feedbackService;

        public FeedbackController(
            ILogger<FeedbackController> logger,
            IFeedbackService feedbackService)
        {
            _logger = logger;
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DAL.Models.Response.Feedback item)
        {
            try
            {
                if (item == null)
                {
                    _logger.LogWarning("Invalid request data. Feedback item is null.");
                    return BadRequest("Invalid request data. Feedback item is null.");
                }

                await _feedbackService.Create(item);

                _logger.LogInformation($"A new feedback has been created successfully, author: {item.Author}");
                return Ok(new { Message = "Feedback has been created successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create feedback. {ex}");
                return StatusCode(500, new { Message = "Failed to create feedback.", Error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var feedbackList = await _feedbackService.Get();
                return Ok(feedbackList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while receiving Feedbacks. {ex}");
                return StatusCode(500, new { Message = "An error occurred while receiving Feedbacks.", Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var feedback = await _feedbackService.Get(id);

                if (feedback == null)
                {
                    _logger.LogWarning($"Feedback with id {id} not found.");
                    return NotFound($"Feedback with id {id} not found.");
                }

                return Ok(feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while receiving Feedback. {ex}");
                return StatusCode(500, new { Message = "An error occurred while receiving Feedback.", Error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DAL.Models.Response.Feedback item)
        {
            try
            {
                if (item == null)
                {
                    _logger.LogWarning("Invalid request data. Feedback item is null.");
                    return BadRequest("Invalid request data. Feedback item is null.");
                }

                await _feedbackService.Update(item);

                _logger.LogInformation($"Feedback from the id: {item.Id}, has been updated");
                return Ok(new { Message = "The feedback has been updated" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update feedback. {ex}");
                return StatusCode(500, new { Message = "Failed to update feedback.", Error = ex.Message });
            }
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        await _feedbackService.Delete(id);

        //        _logger.LogInformation($"Feedback from the id: {id}, has been deleted");
        //        return Ok(new { Message = "The feedback has been deleted" });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to delete feedback. {ex}");
        //        return StatusCode(500, new { Message = "Failed to delete feedback.", Error = ex.Message });
        //    }
        //}
    }
}
