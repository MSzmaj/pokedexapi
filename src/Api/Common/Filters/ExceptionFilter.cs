using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PokedexApi.Common.Exceptions;
using FluentValidation;
using System;
using Microsoft.Extensions.Logging;

namespace PokedexApi.Api.Common.Filters {
    public class ExceptionFilter : IAsyncExceptionFilter {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter (IWebHostEnvironment hostingEnvironment, ILogger<ExceptionFilter> logger) {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
            _logger.LogError(context.Exception.StackTrace);

            if (_hostingEnvironment.IsDevelopment()) {
                return Task.CompletedTask;
            }

            var httpStatusCode = HttpStatusCode.InternalServerError;
            var message = "Internal Server Error";
            
            if (context.Exception is PokemonNotFoundException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                message = context.Exception.Message;
            } else if (context.Exception is InvalidOperationException) {
                message = context.Exception.Message;
            } else if (context.Exception is ValidationException) {
                httpStatusCode = HttpStatusCode.BadRequest;
                message = context.Exception.Message;
            }

            context.Result = new JsonResult(new {
                StatusCode = httpStatusCode,
                Message = message
            });

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}