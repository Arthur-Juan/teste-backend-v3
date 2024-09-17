using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Genre;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Play;
using TheatricalPlayersRefactoringKata.Data.Model.Output;

namespace TheatricalPlayersRefactoringKata.API.Extensions;


public static class ErrorHandler
{
    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(
            errorApp =>
            {
                errorApp.Run(async ctx =>
                {
                    var exptHandlerPathFeat = ctx.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exptHandlerPathFeat?.Error;

                    var code = (int)HttpStatusCode.InternalServerError;
                    var message = exception?.Message;

                    if (exception is InvalidCustomerException)
                    {
                        code = (int)HttpStatusCode.BadRequest;
                        message = exception.Message;
                    }


                    if (exception is InvalidPlayException)
                    {
                        code = (int)HttpStatusCode.BadRequest;
                        message = exception.Message;
                    }

                    if (exception is PlayNotFoundException)
                    {
                        code = (int)HttpStatusCode.NotFound;
                        message = exception.Message;
                    }

                    if (exception is InvalidGenreException)
                    {
                        code = (int)HttpStatusCode.BadRequest;
                        message = exception.Message;
                    }


                    ctx.Response.StatusCode = code;
                    ctx.Response.ContentType = "application/json";
                    await ctx.Response.WriteAsJsonAsync(new ErrorDTO(
                        code, message
                    ));
                });
            }
            );
    }
}