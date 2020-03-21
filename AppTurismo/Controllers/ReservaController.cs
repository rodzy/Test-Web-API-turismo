using AppTurismo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AppTurismo.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        /// <summary>
        /// Este ActionResult me devuelve la Lista de todas las reservas en el Inicio
        /// Eso si esta vez consumiendo los datos de la API
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Declaro un enumerable para almacenar los objetos desde el HTTP
            IEnumerable<reservaModel> listaReservas;
            //El response message realiza la comunicación con la API haciendo uso de la clase GlobalVariables
            //GetAsync: Es el metódo que permite obtener(GET) desde la Uri enviada en este caso la Uri en la API es ...api/reserva
            //Result: Es una tarea de HTTP que permite recolectar lo que tenga el cliente de la consulta
            HttpResponseMessage responseMessage = GlobalVariables.WebApiCliente.GetAsync("reserva").Result;
            //listaReservas: Guarda la respuesta que encontró para hacerla visible con el modelo en la vista
            listaReservas = responseMessage.Content.ReadAsAsync<IEnumerable<reservaModel>>().Result;
            //Retornamos la vista con la lista para mostrar los datos desde la API
            return View(listaReservas);
        }
        /// <summary>
        /// AcitonResult que me envia a registrar una actividad por medio de 
        /// un PUT en la API
        /// </summary>
        /// <returns></returns>
        public ActionResult Reservar()
        {
            return View("Index");
        }
    }
}