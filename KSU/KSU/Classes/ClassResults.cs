using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KSU
{
    public class Results
    {
        public int Id { get; set; }
        public string FundMoment { get; set; }
        public int TotalCount { get; set; }
        public double TotalCost { get; set; }
        public int NaturalSocial { get; set; }
        public int Social { get; set; }
        public int Humanitarian { get; set; }
        public int Metodical { get; set; }
        public int Reference { get; set; }
        public int Art { get; set; }
        public int Prented { get; set; }
        public int Electronic { get; set; }
        public int Periodich { get; set; }
        public string Notes { get; set; }
               
    }
}
