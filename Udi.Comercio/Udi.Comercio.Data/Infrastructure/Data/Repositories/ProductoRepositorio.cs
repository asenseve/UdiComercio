using System;
using System.Collections.Generic;
using System.Linq;
using Udi.Comercio.Data.Domain.Entities;
using Udi.Comercio.Data.Infrastructure.Data.DataModels;

namespace Udi.Comercio.Data.Infrastructure.Data.Repositories
{
    class ProductoRepositorio : EFRepositorio<Producto>
    {
        public int GuardarProducto(ProductoDto producto)
        {
            Producto newProducto = new Producto()
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                FechaVencimiento = producto.FechaVencimiento,
                FkTipo = producto.PkTipo
            };
            Add(newProducto);
            SaveChanges();
            return newProducto.PKProducto;
        }

        public void ModificarProducto(ProductoDto producto)
        {
            Producto productoUpd = this.Get(producto.PkProducto);
            productoUpd.Nombre = producto.Nombre;
            productoUpd.Descripcion = producto.Descripcion;
            productoUpd.Precio = producto.Precio;
            productoUpd.Stock = producto.Stock;
            productoUpd.FechaVencimiento = producto.FechaVencimiento;
            productoUpd.FkTipo = producto.PkTipo;
            Update(productoUpd);
            SaveChanges();
        }

        public void EliminarProducto(int pk)
        {
            Producto producto = this.Get(pk);
            Remove(producto);
            SaveChanges();
        }

        public ProductoDto ObtenerProducto(int pk)
        {

            Producto producto = Get(pk);
            return new ProductoDto()
            {
                PkProducto = producto.PKProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                FechaVencimiento = producto.FechaVencimiento,
                PkTipo = producto.FkTipo,
                Tipo = producto.Tipo.Nombre
            };
        }

        public List<ProductoDto> ObtenerProductos()
        {
            return this.BuildQuery().Select(producto => new ProductoDto()            
            {
                PkProducto = producto.PKProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                FechaVencimiento = producto.FechaVencimiento,
                PkTipo = producto.FkTipo,
                Tipo = producto.Tipo.Nombre
            }).ToList();
        }

    }
}
