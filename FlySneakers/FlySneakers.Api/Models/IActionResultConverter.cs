﻿using FlySneakers.Borders.Shared;
using FlySneakers.Shared.Shared;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;

namespace FlySneakers.Api.Models
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response);
    }

    public class ActionResultConverter : IActionResultConverter
    {
        private readonly string _path;

        public ActionResultConverter()
        {
            _path = string.Empty;
        }

        //public ActionResultConverter(IHttpContextAccessor accessor)
        //{
        //    _path = accessor.HttpContext.Request.Path.Value;
        //}

        public IActionResult Convert<T>(UseCaseResponse<T> response)
        {
            if (response == null)
                return BuildError(new[] { new ErrorMessage("000", "ActionResultConverter Error") }, UseCaseResponseKind.InternalServerError);

            if (response.Success())
            {
                return new OkObjectResult(response.Result);
            }

            Log.Error($"[ERROR] {_path} ({{@data}})", response);

            var useCaseResponseErrorKind = response.GetErrorKind();
            if (useCaseResponseErrorKind == null)
                return BuildError(new[] { new ErrorMessage("000", "ActionResultConverter Error") }, UseCaseResponseKind.InternalServerError);

            var hasErrors = response.Errors == null || !response.Errors.Any();
            var errorResult = hasErrors
                ? new[] { new ErrorMessage("000", response.ErrorMessage ?? "Unknown error") }
                : response.Errors;

            return BuildError(errorResult, useCaseResponseErrorKind.Value);
        }

        ObjectResult BuildError(object data, UseCaseResponseKind statusCode)
        {
            if (statusCode == UseCaseResponseKind.InternalServerError)
                Log.Error($"[ERROR] {_path} ({{@data}})", data);

            return new ObjectResult(data)
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
