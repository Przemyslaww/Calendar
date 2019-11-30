using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class TaskModel
    {
        public int id { get; set; }

        public string taskText { get; set; }

        public int isChecked { get; set; }

        public string date { get; set; }
    }
}
