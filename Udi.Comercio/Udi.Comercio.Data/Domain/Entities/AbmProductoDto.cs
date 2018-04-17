using System.Collections.Generic;

namespace Udi.Comercio.Data.Domain.Entities
{
    public class AbmProductoDto
    {
        public List<ProductoDto> Productos { get; set; }

        public List<TipoDto> Tipos { get; set; }
    }
}
