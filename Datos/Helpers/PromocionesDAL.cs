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
    public class PromocionesDAL
    {
        private empresaBDEntities db = new empresaBDEntities();

        public PromocionesDAL()
        {
            Mapper.CreateMap<promocion, PromocionesDTO>();
            Mapper.CreateMap<PromocionesDTO, promocion>();
        }
        public void AgregarPromociones(PromocionesDTO obje)
        {
            try
            {
                promocion obj = new promocion();
                Mapper.CreateMap<PromocionesDTO, promocion>();
                Mapper.Map(obje, obj);
                db.promocion.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PromocionesDTO GetPk(int i)
        {
            try
            {
                PromocionesDTO ud = new PromocionesDTO();
                promocion u = db.promocion.Where(t => t.codigo == i).SingleOrDefault();
                Mapper.Map(u, ud);
                return ud;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PromocionesDTO> GetAll()
        {
            try
            {
                List<PromocionesDTO> lst = new List<PromocionesDTO>();

                List<promocion> lstO = db.promocion.ToList();
                Mapper.Map(lstO, lst);
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarPromociones(int id, PromocionesDTO obj)
        {
            promocion u = db.promocion.Where(t => t.codigo == id).FirstOrDefault();
            if (u != null)
            {
                u.codigo = obj.codigo;
                u.nombre = obj.nombre;
                u.precio = obj.precio;
                u.empresa = obj.empresa;
                obj.fechaIncial = obj.fechaIncial;
                obj.fechaFincal = obj.fechaFincal;
                obj.imagen = obj.imagen;
                db.SaveChanges();
            }
        }
    }
}
