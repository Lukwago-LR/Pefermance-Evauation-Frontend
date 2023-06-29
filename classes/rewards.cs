using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SATRI_CLIENT
{
    public class rewards
    {
        private List<string> outcome = new List<string>();
        
        public rewards()
        {
            outcome.Add("No Salary Increment");
            outcome.Add("Warning letter");
            outcome.Add("Gets an inflation-related increment");
            outcome.Add("5% increment in salary");
        }

        public List<string> getoutcome()
        {
            return outcome;
        }

    }
}