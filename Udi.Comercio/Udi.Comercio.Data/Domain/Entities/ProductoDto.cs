using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.Comercio.Data.Domain.Entities
{
    public class ProductoDto
    {
        public int PkProducto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public int? Stock { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public int PkTipo { get; set; }

        public string Tipo { get; set; }
    }
}
