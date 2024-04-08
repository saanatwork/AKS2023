using AKS.BOL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AKS.HTMLHelper
{
    public static class UIControlHelper
    {
        public static MvcHtmlString CalendarFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            var value = metadata.Model == null ? string.Empty : metadata.Model.ToString();

            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("type", "date");
            tagBuilder.Attributes.Add("name", propertyName);
            tagBuilder.Attributes.Add("id", propertyName);
            tagBuilder.Attributes.Add("value", value);

            return new MvcHtmlString(tagBuilder.ToString());
        }
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, List<Party> vendorList,string valueField,string textField)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            var selectList = new SelectList(vendorList,valueField,textField, metadata.Model);
            return htmlHelper.DropDownList(propertyName, selectList);
        }
    }
}