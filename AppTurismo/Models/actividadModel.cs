using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppTurismo.Models
{
    public class actividadModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public actividadModel()
        {
            this.reserva = new HashSet<reservaModel>();
        }

        public int idActividad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [DisplayFormat(DataFormatString ="${0:N2}")]
        public decimal costo { get; set; }
        public byte cantidadPersonasDescuento { get; set; }
        [DisplayFormat(DataFormatString ="{0:#}%",ApplyFormatInEditMode =true)]
        public byte porcentajeDescuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservaModel> reserva { get; set; }
    }
}