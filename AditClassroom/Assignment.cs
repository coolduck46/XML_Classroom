using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AditClassroom
{
    class Assignment
    {
        public string assignmentname;
        public string assignmentdesc;
        public int dueday;
        public int duemonth;
        public int dueyear;

        public Assignment(string assignmentname, string assignmentdesc, int dueday, int duemonth, int dueyear)
        {
            this.assignmentname = assignmentname;
            this.assignmentdesc = assignmentdesc;
            this.dueday = dueday;
            this.duemonth = duemonth;
            this.dueyear = dueyear;
        }


    }
}
