using Datos.Helpers;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebEmpresa.Controllers
{
    public class CategoriasController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CategoriasDTO> Get()
        {
            return new CategoriasDAL().GetAll(); 
        }

        // GET api/<controller>/5
        public string Get(int id)
        {

            return "";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}