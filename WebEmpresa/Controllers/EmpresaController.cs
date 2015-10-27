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
    public class EmpresaController : ApiController
    {
        EmpresaDAL h = new EmpresaDAL();
        // GET api/empresa
        public IEnumerable<EmpresaDTO> Get()
        {
            return h.GetAll();
        }

        // GET api/empresa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/empresa
        public void Post(EmpresaDTO obj)
        {
            h.AgregarEmpresa(obj);
        }

        // PUT api/empresa/5
        public void Put(int id, EmpresaDTO obj)
        {
            h.ActualizarEmpresa(id, obj);
        }

        // DELETE api/empresa/5
        public void Delete(int id)
        {
        }
    }
}
