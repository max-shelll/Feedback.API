using Feedback.API.DAL.Dtos;
using Feedback.API.DAL.Models.Response;

namespace Feedback.API.BLL.Services.IServices
{
    public interface IFeedbackService
    {
        Task Create(DAL.Models.Response.Feedback item);

        Task<List<FeedbackDto>> Get();

        Task<FeedbackDto> Get(Guid id);

        Task Update(DAL.Models.Response.Feedback item);

        //Task Delete(Guid id);
    }
}
