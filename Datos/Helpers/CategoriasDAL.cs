using AutoMapper;
using Datos.Conexion;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Helpers
{
    public class CategoriasDAL
    {
        private empresaBDEntities db = new empresaBDEntities();
        
        public List<CategoriasDTO> GetAll()
        {
            List<CategoriasDTO> lst = new List<CategoriasDTO>();
            Mapper.CreateMap<categorias, CategoriasDTO>();
            var lstO = db.categorias.ToList();
            Mapper.Map(lstO, lst);
            return lst;
        }
    }
}
