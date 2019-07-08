using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCardSystem
{
    public class TransportCard
    {
        const int START_ID = 100000000;
        const int ADULT_FEE = 90;
        const int SERVICE_LIFE_YEARS = 10;

        static int count;

        private int _wallet;

        public int CardId { get; private set; }
        public int Wallet { get; set; }

        public DateTime ExpiryDate { get; private set; }

        public TransportCard ()
        {
            count++;
            CardId = count + START_ID;
            ExpiryDate = DateTime.Now.AddYears(SERVICE_LIFE_YEARS);
        }

        public bool IsValid()
        {
            return ( DateTime.Now < ExpiryDate) ?  true : false;         
        }

        public bool IsPaid()
        {
            if(Wallet >= ADULT_FEE)
            {
                Wallet -= ADULT_FEE;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
