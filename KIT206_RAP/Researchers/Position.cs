using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP.Researchers

{
    public enum Level
    { 
        A, 
        B, 
        C, 
        D, 
        E 
    }
 
    internal class Position
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Level Level{ get; set; }
    
        public Position(DateTime startDate, DateTime endDate, Level level)
        {
            StartDate = startDate;
            EndDate = endDate;
            Level = level;
        }
    }
}
