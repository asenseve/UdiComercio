using System;
using System.Web.Mvc;
using Udi.Comercio.Data.Domain.Entities;
using Udi.Comercio.Data.Domain.Services;

namespace Udi.Comercio.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoServicio _productoServicio = new ProductoServicio();

        public JsonResult GuardarProducto(string producto)
        {
            try
            {
                var productoDto = ComunServicio.ObtenerDtoFromString<ProductoDto>(producto);
                int pk = _productoServicio.GuardarProducto(productoDto);

                return new JsonResult { Data = new { Success = true, Data = pk } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult EliminarProducto(int pk)
        {
            try
            {
                _productoServicio.EliminarProducto(pk);
                var data = new { Success = true };
                return this.Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var data = new { Success = false, Mensaje = ex.Message };
                return this.Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerProductos()
        {
            try
            {
                var data = _productoServicio.ObtenerAbmProductos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

    }
}