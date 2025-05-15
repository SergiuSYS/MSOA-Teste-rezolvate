using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MsoaTest1
{
    public class DateCopil
    {
        public string _nume {  get; set; }
        public string _prenume { get; set; }
        public string _CNP { get; set; }

        public int _varsta { get; set; }
        public char _sex { get; set; }
        public DateTime _dataNasterii { get; set; }

        public List<DateCadou> _cadouri {  get; set; }


        public DateCopil(string nume, string prenume, string CNP)
        {
            _nume = nume;
            _prenume = prenume;
            _CNP = CNP;
            _cadouri = new List<DateCadou>();
            CalculateCnpData();
        }
        private void CalculateCnpData()
        {
            int genderDigit = int.Parse(_CNP.Substring(0, 1));
            int year = int.Parse(_CNP.Substring(1, 2));
            int month = int.Parse(_CNP.Substring(3, 2));
            int day = int.Parse(_CNP.Substring(5, 2));

            int century;

            if (genderDigit == 1 || genderDigit == 2)
                century = 1900;
            else if (genderDigit == 3 || genderDigit == 4)
                century = 1800;
            else if (genderDigit >= 5 && genderDigit <= 9)
                century = 2000;
            else
                throw new ArgumentException("Cifra pentru sex/secol din CNP este invalidă.");

            int fullYear = century + year;

            _dataNasterii = new DateTime(fullYear, month, day);
            
            if (genderDigit % 2 == 1)
                _sex = 'M';
            else
                _sex = 'F';

            var today = DateTime.Today;
            _varsta = today.Year - _dataNasterii.Year;

        }
        public override string ToString() //facem override la toString deoarece este folosit automat cand este introdus in comboBox
        {
            return _nume + " " + _prenume;
        }
        public void AddCadou(DateCadou dateCadou)
        {
            if (dateCadou == null)
                throw new ArgumentNullException( nameof(dateCadou));
            _cadouri.Add(dateCadou);
        }
    }
}
