using System.Text.Json;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceApplication.CQRS;

namespace Api.Base
{
#if DEBUG
    [AllowAnonymous]
    #else
        [Authorize]
    #endif
    public abstract partial class HandlerBaseController<ENT, DTO>
        where ENT : class, new()
        where DTO : class, new()
    {
        protected readonly IValidator<DTO> _validator;

        public HandlerBaseController(IValidator<DTO> validator, IMediator mediator): base(mediator)
        {
            _validator = validator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DTO dto)
        {
            return this.HandlerResponse(await _mediator.Send(new CreateAsyncCommand<ENT, DTO>(dto)));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return this.HandlerResponse(await _mediator.Send(new ToListAsyncQuery<ENT, DTO>()));
        }



    }
}
