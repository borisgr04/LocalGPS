using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class PromocionesDTO
    {
        public long codigo { get; set; }
        public string nombre { get; set; }
        public long precio { get; set; }
        public long empresa { get; set; }
        public DateTime fechaIncial { get; set; }
        public DateTime fechaFincal { get; set; }
        public string imagen { get; set; }
    }
}
