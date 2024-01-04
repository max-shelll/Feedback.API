
using AutoMapper;
using Feedback.API.BLL;
using Feedback.API.BLL.Services;
using Feedback.API.BLL.Services.IServices;
using Feedback.API.DAL.Repositories;
using Feedback.API.DAL.Repositories.IRepositories;

namespace Feedback.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            /// [ -- Services DI -- ]
            builder.Services
               .AddSingleton(mapper)
               /// Repositories
               .AddTransient<IFeedbackRepository, FeedbackRepository>()
               /// Services
               .AddSingleton<IFeedbackService, FeedbackService>();
 

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.MapControllers();

            app.Run();
        }
    }
}
