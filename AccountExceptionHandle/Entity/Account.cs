using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Entity
{
    public class Account
    {
        //accno, name, balance, pin number, isActive openingDate and
        //closingDate properties

        public int AccNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

    }
}
