using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU
{
    public partial class Reason
    {
        public int QM { get; set; }

        public string TitleReason
        {
            get
            {
                return Kind;
            }
        }
    }
}
