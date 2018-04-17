using System.Collections.Generic;
using Udi.Comercio.Data.Domain.Entities;
using Udi.Comercio.Data.Infrastructure.Data.Repositories;

namespace Udi.Comercio.Data.Domain.Services
{
    public class ProductoServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public ProductoServicio()
        {
            _productoRepositorio = new ProductoRepositorio();
        }

        public int GuardarProducto(ProductoDto producto)
        {
            int pk = 0;
            if (producto.PkProducto == 0)
                pk = _productoRepositorio.GuardarProducto(producto);
            else { 
                _productoRepositorio.ModificarProducto(producto);
                pk = producto.PkProducto;
            }
            return pk;
        }

        public void EliminarProducto(int pk)
        {
            _productoRepositorio.EliminarProducto(pk);
        }

        public ProductoDto ObtenerProducto(int pk)
        {
            return _productoRepositorio.ObtenerProducto(pk);
        }

        public List<ProductoDto> ObtenerProductos()
        {
            return _productoRepositorio.ObtenerProductos();
        }

        public AbmProductoDto ObtenerAbmProductos()
        {
            TipoRepositorio tipoRep = new TipoRepositorio();
            var abm = new AbmProductoDto()
            {
                Productos = _productoRepositorio.ObtenerProductos(),
                Tipos = tipoRep.ObtenerTiposDto()
            };
            return abm;
        }


    }
}
