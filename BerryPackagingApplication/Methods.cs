using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryPackagingApplication
{
    class Methods
    {
        public String GetCurrentTime()
        {
            String time = string.Format("{0:HH:mm}", DateTime.Now);

            return time;
        }
            
        public String GetCurrentDate()
        {
            return DateTime.Today.ToString("dd-MM-yyyy"); 
        }
        public float SetWeight(float Prod, float Case)
        {
            float WeightBRT = Prod;
            float WeightNT = WeightBRT - Case;

            return WeightNT;
        }

    }
}
