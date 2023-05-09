using System;
using System.Collections.Generic;
using System.Data;
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
        public int Natural
        {
            get
            {
                int n = 0;
                if(NaturalSocial == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)NaturalSocial;                       
                }                
            }
        }
        public int SocialResult
        {
            get
            {
                int n = 0;
                if (Social == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)Social;
                }
            }
        }
        public int HumanResult
        {
            get
            {
                int n = 0;
                if (Humanitarian == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)Humanitarian;
                }
            }
        }
        public int MetodicalResult
        {
            get
            {
                int n = 0;
                if (MetodicalSocial == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)MetodicalSocial;
                }
            }
        }
        public int ReferenceResult
        {
            get
            {
                int n = 0;
                if (ReferenceLiterature == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)ReferenceLiterature;
                }
            }
        }
        public int ArtResult
        {
            get
            {
                int n = 0;
                if (ArtLiterature == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)ArtLiterature;
                }
            }
        }
        public int PrentedResult
        {
            get
            {
                int n = 0;
                if (Printed == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)Printed;
                }
            }
        }
        public int ElectronicResult
        {
            get
            {
                int n = 0;
                if (Electronic == null)
                {
                    return 0;
                }
                else
                {
                    return n += (int)Electronic;
                }
            }
        }
        public int PeriodichResult
        {
            get
            {
                int n = 0;
                if (Periodich == null)
                {
                    return 0;
                }
                else
                {
                    return (int)Periodich;
                }
            }
        }
        public string NotesResult
        {
            get
            {
                if(Notes== null)
                {
                    return null;
                }
                else
                {
                    return Notes;
                }
            }
        }
    }
}
