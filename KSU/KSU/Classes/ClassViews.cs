using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU
{
    public partial class Views
    {
        public int QM { get; set; }

        public string ViewsTitle
        {
            get
            {
                return Kind;
            }
        }
    }
}
