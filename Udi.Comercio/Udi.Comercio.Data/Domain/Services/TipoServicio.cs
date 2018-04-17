using System.Collections.Generic;
using Udi.Comercio.Data.Infrastructure.Data.DataModels;
using Udi.Comercio.Data.Infrastructure.Data.Repositories;

namespace Udi.Comercio.Data.Domain.Services
{
    public class TipoServicio
    {
        private readonly TipoRepositorio _tipoRepositorio;

        public TipoServicio()
        {
            this._tipoRepositorio = new TipoRepositorio();
        }

        public int GuardarTipo(int pk, string nombre, string descripcion)
        {
            if (pk == 0)
                pk = _tipoRepositorio.GuardarTipo(nombre, descripcion);
            else
                _tipoRepositorio.ModificarTipo(pk, nombre, descripcion);
            return pk;
        }

        public void EliminarTipo(int pk)
        {
            _tipoRepositorio.EliminarTipo(pk);
        }

        public Tipo ObtenerTipo(int pk)
        {
            return _tipoRepositorio.ObtenerTipo(pk);
        }

        public List<Tipo> ObtenerTipos()
        {
            return _tipoRepositorio.ObtenerTipos();
        }

    }
}
