using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Cat
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public double Weigth { get; set; }
        public string Color { get; set; }
        public bool HasCirtificate { get; set; }
        public string Feed { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
    }
}