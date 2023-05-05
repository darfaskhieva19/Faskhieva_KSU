using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU
{
    public partial class Results
    {
        public int Counts // Вывод общего количества
        {
            get
            {
                if (TotalCount == null)
                {
                    return 0;
                }
                else
                {
                    return (int)TotalCount;
                }                
            }
        }
        public string Cost // Вывод общей стоимости
        {
            get
            {
                if (TotalCost == null)
                {
                    return null;
                }
                else
                {
                    return string.Format("{0:N2}", TotalCost); ;
                }               
            }
        }

    }
}
