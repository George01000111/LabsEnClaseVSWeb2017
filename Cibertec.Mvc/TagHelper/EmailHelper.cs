using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.TagHelper
{
    public static class EmailHelper
    {
        public static IHtmlString EmailCustom(
            this HtmlHelper helper, string context)
        {
            var str = $"<a href=\"mailto:{context}\">{context}</a>";
            return new HtmlString(str);
        }
    }
}