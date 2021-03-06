﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LinkedIn.Web.Models.CustomValidators
{
    public class ImgValidationAttribute : ValidationAttribute
    {
        private const string _DefaultErrorMessage = "Only the following file types are allowed: {0}";
        private IEnumerable<string> _ValidTypes { get; set; }
        private int MaxContentLength { get; set; }

        public ImgValidationAttribute(string validTypes)
        {
            _ValidTypes = validTypes.Split(',').Select(s => s.Trim().ToLower());
            ErrorMessage = string.Format(_DefaultErrorMessage, string.Join(" or ", _ValidTypes));
            MaxContentLength = 1024 * 1024 * 2;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<HttpPostedFileBase> files = value as IEnumerable<HttpPostedFileBase>;
            foreach (HttpPostedFileBase file in files)
            {
                if (file != null)
                {
                    if (file != null && !_ValidTypes.Any(e => file.FileName.EndsWith(e)))
                    {
                        return new ValidationResult(ErrorMessageString);
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        return new ValidationResult("File is too large, maximum size is : " + (MaxContentLength / 1024).ToString() + "MB");
                    }
                }
            }
            return ValidationResult.Success;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientValidationRule
        //    {
        //        ValidationType = "filetype",
        //        ErrorMessage = ErrorMessageString
        //    };
        //    rule.ValidationParameters.Add("validtypes", string.Join(",", _ValidTypes));
        //    yield return rule;
        //}
    }
}
