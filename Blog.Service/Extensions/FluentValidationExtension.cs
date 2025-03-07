﻿using FluentValidation.Results;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;

namespace Blog.Service.Extensions
{
	public static class FluentValidationExtension
	{
		public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
		{
			foreach (var error in result.Errors)
			{
				modelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}
		public static void AddToModelIdentityState(this IdentityResult result, ModelStateDictionary modelState)
		{
			foreach (var error in result.Errors)
			{
				modelState.AddModelError("", error.Description);
			}
		}
	}
}
