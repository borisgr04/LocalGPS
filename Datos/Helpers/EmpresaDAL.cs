using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Datos.Conexion;
using Entidades;
namespace Datos.Helpers
{
    public  class EmpresaDAL
    {
        private empresaBDEntities db = new empresaBDEntities();
        public void AgregarEmpresa(EmpresaDTO obje)
        {
            try
            {
                empresa obj = new empresa();
                Mapper.CreateMap<EmpresaDTO, empresa>();
                Mapper.Map(obje, obj);
                db.empresa.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public void ActualizarEmpresa(int id,EmpresaDTO obj)
        {
            try
            {
                empresa u = db.empresa.Where(t => t.codigo == id).FirstOrDefault();
                if (u != null)
                {
                    u.codigo = obj.codigo;
                    u.nombre = obj.nombre;
                    u.direccion = obj.direccion;
                    u.longitud = obj.longitud;
                    u.latitud = obj.latitud;
                    u.correo = obj.correo;
                    u.telefono = obj.telefono;
                    u.pass = obj.pass;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmpresaDTO GetPk(int i)
        {
            try
            {
                EmpresaDTO ud = new EmpresaDTO();
                empresa u = db.empresa.Where(t => t.codigo == i).FirstOrDefault();
                Mapper.Map(u, ud);
                return ud;
            }
            catch (Exception ex)
            {
                
                throw ex
                    ;
            }
        }

        public List<EmpresaDTO> GetAll()
        {
            try
            {
                List<EmpresaDTO> lst = new List<EmpresaDTO>();
                Mapper.CreateMap<empresa, EmpresaDTO>();
                var lstO = db.empresa.ToList();
                Mapper.Map(lstO, lst);
                return lst;
            }
            catch ( Exception ex)
            {
                throw ex;
            }       
        }
 
    }
}
