using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace LemonWayWebService
{
    public class CustomRequestValidator : RequestValidator
    {
        protected  override bool IsValidRequestString(HttpContext context, string value,
            RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
        {
            validationFailureIndex = -1;
            return true;
        }
    }
}