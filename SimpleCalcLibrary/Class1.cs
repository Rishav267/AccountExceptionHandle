using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalcLibrary
{
    public class Calculator
    {
        public int Sum(int fno , int sno)
        {
            int result = fno + sno;
            return result;
        }

        public int Subtract(int f, int s)
        {
            int res = f - s;
            return res;
        }

        public double Divide(int fno , int sno)
        {
            double res=0;
            if (sno != 0)
                res = (float) fno / sno;
            return res;
        }

        public bool IsPrime(int no)
        {       if (no <= 0)
                return false;
                for (int i=2;i<=no;i++)
                {
                    if (no % i == 0)
                        return false;
                }
            return true;
            
        }
    }
}
