using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class GlobalErrorController : Controller
    {
        private readonly ILogger<GlobalErrorController> logger;
        public GlobalErrorController(ILogger<GlobalErrorController> _logger)
        {
            this.logger = _logger;
        }

                [AllowAnonymous]
        [Route("GlobalError")]
        public IActionResult GlobalError()
        {

            // Retrieve the exception Details
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;
            logger.LogError(" Path : " + exceptionHandlerPathFeature.Path + " Threw the error - " + exceptionHandlerPathFeature.Error.Message);
            return View();

        }

    }
}
