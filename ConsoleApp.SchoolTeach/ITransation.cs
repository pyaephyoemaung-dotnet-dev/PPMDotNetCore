using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.SchoolTeach
{
    interface ITransation
    {
        void showTransation();
        double getAmount();
    }
    public class Transation : ITransation
    {
        private string tCode;
        private string date;
        private double amout;
        public Transation()
        {
            tCode = "0001";
            date = "5/9/2025";
            amout = 30000000;
        }
    }
    public Tr(string tCode,string date,double amout)
    {
        this.tCode = tCode;
        this.date = date;
        this.
    }
}
