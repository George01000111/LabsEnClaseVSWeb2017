using Cibertec.Mvc.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.ValueProviders
{
    public class ProductValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            //Define que cuando el ModelBinder esta buscando una propiedad con 
            //el nombre "Package", el ValueProvider va ejecutar este VP personalizado
            return prefix.Contains("Package");
        }

        public ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                return new ValueProviderResult(Service.GetPackageNumber(), Service.GetPackageNumber(),
                    CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }

    public class ProductValueProviderFactory : ValueProviderFactory
    {
        /// <summary>
        /// Este metodo es llamado cuando el Model Binder quiere obtener valores para realizar
        /// el enlace de datos (binding)
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new ProductValueProvider();
        }
    }
}