using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTurismo.Models
{
    public class usuarioModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarioModel()
        {
            this.reserva = new HashSet<reservaModel>();
        }

        public int idUsuario { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public string contrasenna { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservaModel> reserva { get; set; }
    }
}