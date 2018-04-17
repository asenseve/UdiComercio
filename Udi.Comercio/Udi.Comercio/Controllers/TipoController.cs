using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udi.Comercio.Data.Domain.Services;

namespace Udi.Comercio.Controllers
{
    public class TipoController : Controller
    {
        private readonly TipoServicio tipoServicio = new TipoServicio();

        public JsonResult GuardarTipo(int pk, string nombre, string descripcion)
        {
            try
            {
                pk = tipoServicio.GuardarTipo(pk, nombre, descripcion);

                return new JsonResult { Data = new { Success = true, Data = pk } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult EliminarTipo(int pk)
        {
            try
            {
                this.tipoServicio.EliminarTipo(pk);

                return new JsonResult { Data = new { Success = true } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult ObtenerTipo(int pk)
        {
            try
            {
                var data = this.tipoServicio.ObtenerTipo(pk);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult ObtenerTipos()
        {
            try
            {
                var data = this.tipoServicio.ObtenerTipos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}