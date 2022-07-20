using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS8618

namespace ConferenceModule.ApiCms.Controllers;

[Route("/api/v1/[controller]")]
public class ApiControllerBase : ControllerBase {
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext!.RequestServices!.GetService<IMediator>()!;


    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="id"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected ActionResult ResponseObject<T>(T? result, object id) where T : class {
        if (result == null)
            throw new NotFoundException(typeof(T).Name, id.ToString());
        return Ok(result);
    }

    /// <summary>
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected ActionResult ResponseList<T>(IReadOnlyList<T> list) where T : class {
        if (!list.Any()) return NoContent();
        return Ok(list);
    }

    protected ActionResult ResponsePagedList<T>(PagedResult<T> list) where T : class {
        if (!list.Results.Any()) return NoContent();
        return Ok(list);
    }
}