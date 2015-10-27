using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos.Helpers;
using Entidades;
namespace APIEmpresa.Controllers
{
    public class PromocionesController : ApiController
    {

        PromocionesDAL h = new PromocionesDAL();
        // GET api/promociones
        public IEnumerable<PromocionesDTO> Get()
        {
            return h.GetAll();
        }

        // GET api/promociones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/promociones
        public void Post(PromocionesDTO obj)
        {
            h.AgregarPromociones(obj);
        }

        // PUT api/promociones/5
        public void Put(int id, PromocionesDTO obj)
        {
            h.ActualizarPromociones(id, obj);   
        }

        // DELETE api/promociones/5
        public void Delete(int id)
        {
        }
    }
}
