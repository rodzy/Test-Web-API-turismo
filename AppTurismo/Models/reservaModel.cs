using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppTurismo.Models
{
    public class reservaModel
    {
        [DisplayName("N°Reserva")]
        public int idReserva { get; set; }
        [DisplayName("Fecha")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime fecha { get; set; }
        [DisplayName("Actividad")]
        public int idActividad { get; set; }
        [DisplayName("Cliente")]
        public string nombreCliente { get; set; }
        [DisplayName("Teléfono")]
        public string numeroContactoCliente { get; set; }
        [DisplayName("Cantidad de personas")]
        public byte cantidadPersonas { get; set; }
        [DisplayName("Total")]
        public decimal total { get; set; }
        [DisplayName("Nombre de Usuario")]
        public int idUsuario { get; set; }

        public virtual actividadModel actividad { get; set; }
        public virtual usuarioModel usuario { get; set; }
    }
}