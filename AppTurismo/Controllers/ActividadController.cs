using AppTurismo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AppTurismo.Controllers
{
    public class ActividadController : Controller
    {
        // GET: Actividad
        /// <summary>
        /// Este ActionResult me devuelve todas las actividades disponibles por la API
        /// para que el usuario las pueda seleccionar
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Esta es la lista en la que se van a guardar las Actividades para agregarlas al modelo
            IEnumerable<actividadModel> listaActividades;
            //El response message realiza la comunicación con la API haciendo uso de la clase GlobalVariables
            //GetAsync: Es el metódo que permite obtener(GET) desde la Uri enviada en este caso la Uri en la API es ...api/actividad
            //Result: Es una tarea de HTTP que permite recolectar lo que tenga el cliente de la consulta
            HttpResponseMessage responseMessage = GlobalVariables.WebApiCliente.GetAsync("actividad").Result;
            //Guarda la respuesta que encontró para hacerla visible con el modelo en la vista
            listaActividades = responseMessage.Content.ReadAsAsync<IEnumerable<actividadModel>>().Result;
            //Retornamos la vista con la lista para mostrar los datos desde la API
            return View(listaActividades);
        }
    }
}