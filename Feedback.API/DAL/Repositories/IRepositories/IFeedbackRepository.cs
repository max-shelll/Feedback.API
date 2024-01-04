using Feedback.API.DAL.Models.Response;

namespace Feedback.API.DAL.Repositories.IRepositories
{
    public interface IFeedbackRepository
    {
        Task Create(Models.Response.Feedback item);

        Task<List<Models.Response.Feedback>> Get();

        Task<Models.Response.Feedback> Get(Guid id);

        Task Update(Models.Response.Feedback item);

        //Task Delete(Guid id);
    }
}
