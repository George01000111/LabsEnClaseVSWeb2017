using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Binders
{
    public class ProductBinder : IModelBinder
    {
        //public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, 
        //    ModelBindingContext bindingContext)
        //{
        //    if (bindingContext == null)
        //        throw new ArgumentNullException(nameof(bindingContext));

        //    //var request = bindingContext.ModelType
        //    if (bindingContext.ModelType == typeof(Product))
        //    {
        //        //Product model1;
        //        //if (bindingContext.Model == null)
        //        //{
        //        //    model1 = new Product();
        //        //}
        //        //else
        //        //{
        //        //    model1 = (Product)bindingContext.Model;
        //        //}
        //        Product model = (Product)bindingContext.Model ?? new Product();
        //        //Product model2 = bindingContext.Model == null ? new Product() : (Product)bindingContext.Model;

        //        model.Id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").AttemptedValue);
        //        model.ProductName = bindingContext.ValueProvider.GetValue("ProductName").AttemptedValue;
        //        model.Package = bindingContext.ValueProvider.GetValue("Package").AttemptedValue;
        //        model.IsDiscontinued = Convert.ToBoolean(bindingContext.ValueProvider.GetValue("IsDiscontinued").AttemptedValue);
        //        model.SuppliedId = Convert.ToInt32(bindingContext.ValueProvider.GetValue("SuppliedId").AttemptedValue);
        //        model.UnitPrice = Convert.ToDecimal(bindingContext.ValueProvider.GetValue("UnitPrice").AttemptedValue);

        //        bindingContext.Model = model;

        //        return true;
        //    }
        //    return false;            
        //}

        public object BindModel(ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            if (bindingContext.ModelType == typeof(Product))
            {
                Product model = (Product)bindingContext.Model ?? new Product();

                model.Id = bindingContext.ValueProvider.GetValue("Id") == null ? 
                    0 : 
                    Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").AttemptedValue);
                model.ProductName = bindingContext.ValueProvider.GetValue("ProductName").AttemptedValue;
                model.Package = bindingContext.ValueProvider.GetValue("Package").AttemptedValue;
                model.IsDiscontinued = Convert.ToBoolean(bindingContext.ValueProvider.GetValue("IsDiscontinued").AttemptedValue);
                model.SuppliedId = Convert.ToInt32(bindingContext.ValueProvider.GetValue("SuppliedId").AttemptedValue);
                model.UnitPrice = Convert.ToDecimal(bindingContext.ValueProvider.GetValue("UnitPrice").AttemptedValue);

                //bindingContext.Model = model;

                return model;
            }
            return null;
        }
    }
}