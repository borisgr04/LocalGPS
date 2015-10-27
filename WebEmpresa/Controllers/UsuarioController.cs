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
    public class UsuarioController : ApiController
    {
        UsuariosDAL h = new UsuariosDAL();
        // GET api/usuario
        public IEnumerable<UsuariosDTO> Get()
        {
            return h.GetAll();
        }

        // GET api/usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/usuario
        public void Post(UsuariosDTO obj)
        {
            h.AgregarUsuarios(obj);

        }

        // PUT api/usuario/5
        public void Put(int id, UsuariosDTO obj)
        {
            h.ActualizarUsuarios(id,obj);
        }

        // DELETE api/usuario/5
        public void Delete(int id)
        {
        }
    }
}
