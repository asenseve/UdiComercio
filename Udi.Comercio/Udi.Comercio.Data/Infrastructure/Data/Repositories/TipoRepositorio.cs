using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.Comercio.Data.Domain.Entities;
using Udi.Comercio.Data.Infrastructure.Data.DataModels;

namespace Udi.Comercio.Data.Infrastructure.Data.Repositories
{
    class TipoRepositorio : EFRepositorio<Tipo>
    {

        public int GuardarTipo(string nombre, string descripcion)
        {
            Tipo tipo = new Tipo()
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            Add(tipo);
            SaveChanges();
            return tipo.PkTipo;
        }

        public void ModificarTipo(int pk, string nombre, string descripcion)
        {
            Tipo tipo = this.Get(pk);
            tipo.Nombre = nombre;
            tipo.Descripcion = descripcion;
            Update(tipo);
            SaveChanges();
        }

        public void EliminarTipo(int pk)
        {
            Tipo tipo = this.Get(pk);
            Remove(tipo);
            SaveChanges();
        }

        public Tipo ObtenerTipo(int pk)
        {
            return Get(pk);
        }

        public List<Tipo> ObtenerTipos()
        {
            return GetAll().OrderBy(x => x.Nombre).ToList();
        }

        public List<TipoDto> ObtenerTiposDto()
        {
            return this.BuildQuery().Select(tipo => new TipoDto()
            {
                PkTipo = tipo.PkTipo,
                Nombre = tipo.Nombre,
                Descripcion = tipo.Descripcion,
            }).ToList();
        }

    }
}
