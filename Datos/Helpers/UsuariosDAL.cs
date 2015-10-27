using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Conexion;
using Entidades;
using AutoMapper;
namespace Datos.Helpers
{

    public class UsuariosDAL
    {
        private empresaBDEntities db = new empresaBDEntities();

        public UsuariosDAL()
        {
            Mapper.CreateMap<usuarios, UsuariosDTO>();
            Mapper.CreateMap<UsuariosDTO, usuarios>();
        }

        public UsuariosDTO GetPk(int i)
        {
            UsuariosDTO uD = new UsuariosDTO();
            usuarios u = db.usuarios.Where(t => t.codigo == i).FirstOrDefault();
            Mapper.Map(u,uD);
            return uD;
        }

        public List<UsuariosDTO> GetAll() 
        {
            List<UsuariosDTO> lst = new List<UsuariosDTO>();
            empresaBDEntities db = new empresaBDEntities();
            List<usuarios> lstO = db.usuarios.ToList();
            //var x = (from t in db.usuarios
            //         select t).ToList();
            Mapper.Map(lstO, lst);
            return lst;

        }

        public void AgregarUsuarios(UsuariosDTO obje)
        {
            try
            {
                usuarios obj = new usuarios();
                Mapper.Map(obje, obj);
                db.usuarios.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarUsuarios(int id, UsuariosDTO obj)
        {
            usuarios u = db.usuarios.Where(t => t.codigo == id).FirstOrDefault();
            if(u != null){
                u.correo = obj.correo;
                u.nombre = obj.nombre;
                u.telefono = obj.telefono;
                db.SaveChanges();
            }
        }
    }
}
