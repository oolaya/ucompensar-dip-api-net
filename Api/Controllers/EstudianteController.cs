using Api.Base;
using Domian.Entity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceApplication;
using ServiceApplication.Dto;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : HandlerBaseController<Estudiante, EstudianteDto>
    {
        public EstudianteController(IValidator<EstudianteDto> validator, IMediator mediator)
            : base(validator, mediator)
        {

        }

    }
}
