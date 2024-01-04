using AutoMapper;
using Feedback.API.BLL.Services.IServices;
using Feedback.API.DAL.Dtos;
using Feedback.API.DAL.Repositories.IRepositories;

namespace Feedback.API.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepo;
        private readonly IMapper _mapper;

        public FeedbackService(
            IFeedbackRepository feedbackRepo,
            IMapper mapper)
        {
            _feedbackRepo = feedbackRepo ?? throw new ArgumentNullException(nameof(feedbackRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Create(DAL.Models.Response.Feedback item)
        {
            await _feedbackRepo.Create(item);
        }

        public async Task<List<FeedbackDto>> Get()
        {
            var items = await _feedbackRepo.Get();
            var mapItems = _mapper.Map<List<FeedbackDto>>(items);

            return mapItems;
        }

        public async Task<FeedbackDto> Get(Guid id)
        {
            var item = await _feedbackRepo.Get(id);
            var mapItem = _mapper.Map<FeedbackDto>(item);

            return mapItem;
        }

        public async Task Update(DAL.Models.Response.Feedback item)
        {
            await _feedbackRepo.Update(item);
        }
    }
}
