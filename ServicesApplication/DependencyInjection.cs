using Domian.Entity;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServiceApplication.Base;
using ServiceApplication.CQRS;
using ServiceApplication.Dto;

namespace ServiceApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionsApplications(this IServiceCollection services)
        {
            services.AddScoped<IValidator<EstudianteDto>, EstudianteValidator>();
            return services;
        }

        public static IServiceCollection AddMediatrDependecyInjection(this IServiceCollection services)
        {
            services.RegisterMediatrAbstractService<EstudianteService, EstudianteDto, Estudiante, IEstudianteService>();
            //services.RegisterMediatrAbstractService<TestService, TestDto, Test, ITestService>()

            return services;
        }

        public static void RegisterMediatrAbstractService<Service, DTO, ENT, TImplementation>(this IServiceCollection services)
            where Service : BaseServiceApplication<ENT, DTO>
            where DTO : class, new()
            where ENT : class, new()
            where TImplementation : IBaseServiceApplication<ENT, DTO>
        {

            services.AddScoped(typeof(TImplementation), typeof(Service));
            services.AddScoped(typeof(IBaseServiceApplication<ENT, DTO>), typeof(Service));
            services.AddMediatR(typeof(CreateAsyncCommandHandler<ENT, DTO>));
            services.AddScoped(typeof(IRequestHandler<CreateAsyncCommand<ENT, DTO>, DTO>),typeof(CreateAsyncCommandHandler<ENT, DTO>));

            services.AddMediatR(typeof(ToListAsyncQueryHandler<ENT, DTO>));
            services.AddScoped(typeof(IRequestHandler<ToListAsyncQuery<ENT, DTO>, List<DTO>>), typeof(ToListAsyncQueryHandler<ENT, DTO>));

        }
    }
}
