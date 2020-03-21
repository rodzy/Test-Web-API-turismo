using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppTurismo
{
    /// <summary>
    /// La clase es de tipo static para poder usarla a lo largo
    /// del proyecto
    /// La función de esta clase es declarar todas las variables y
    /// métodos que se utilizaran para consumir el recurso API de manera global
    /// utilizando HTTP
    /// </summary>
    public static class GlobalVariables
    {
        //Instancia del cliente HTTP que se usara para contactar la API
        public static HttpClient WebApiCliente = new HttpClient();

        static GlobalVariables()
        {
            //Aquí se establece el dominio de donde vienen los datos, como en este caso la API es local entonces es nuestro servidor de IIS
            //Para obtener la dirección de origen de la API le damos a WebAPI>Properties>Web>Project Url
            WebApiCliente.BaseAddress = new Uri("https://localhost:44336/api/");
            WebApiCliente.DefaultRequestHeaders.Clear();
            WebApiCliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}