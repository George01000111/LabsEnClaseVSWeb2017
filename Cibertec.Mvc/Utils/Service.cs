using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.Mvc.Utils
{
    /// <summary>
    /// Simula un servicio, Suponiendo que la generacion del nombre del paquete
    /// //depende de una logica especial
    /// </summary>
    static class Service
    {
        public static string GetPackageNumber()
        {
            return "0000-1234-1234";
        }
    }
}