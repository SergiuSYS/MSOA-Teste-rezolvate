using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsoaTest1
{
    public class DateCadou
    {
        public string _nume { get; set; }
        public string _tip { get; set; }
        public double _pret { get; set; }

        public DateCadou(string nume, string tip, double pret)
        {
            _nume = nume;
            _tip = tip;
            _pret = pret;
        }
    }
}
