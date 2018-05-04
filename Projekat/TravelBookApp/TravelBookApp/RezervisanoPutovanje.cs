using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public class RezervisanoPutovanje
    {
        private int idPutnika;
        private int idPutovanja;

        public RezervisanoPutovanje(int idPutnika, int idPutovanja)
        {
            this.IdPutnika = idPutnika;
            this.IdPutovanja = idPutovanja;
        }

        public int IdPutnika { get => idPutnika; set => idPutnika = value; }
        public int IdPutovanja { get => idPutovanja; set => idPutovanja = value; }
    }
}
