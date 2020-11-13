using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace EmployeeMVC.Utility
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Identity
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger
            , IModelMetadataProvider modelMetadataProvider)
        {
            this._modelMetadataProvider = modelMetadataProvider;
            this._logger = logger;
        }
        #endregion

        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                this._logger.LogError($"{context.HttpContext.Request.RouteValues["controller"]} is Error");
                var result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                result.ViewData.Add("Exception", context.Exception);
                context.Result = result;

                context.ExceptionHandled = true;
            }
        }
    }
}
