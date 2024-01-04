using AutoMapper;
using Feedback.API.DAL.Dtos;

namespace Feedback.API.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<DAL.Models.Response.Feedback, FeedbackDto>();
        }
    }
}
