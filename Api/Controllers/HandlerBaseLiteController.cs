using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Base
{
    public class HandlerBaseLiteController<DTO> : Controller
    {
        protected readonly IMediator _mediator;

        public HandlerBaseLiteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected IActionResult HandlerResponse<DTO>(DTO dato)
        {
            return this.Ok(dato);
        }
    }
}
