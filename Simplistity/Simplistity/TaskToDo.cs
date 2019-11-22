using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplistity
{
    public class TaskToDo
    {
        public string ToDo { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Checked { get; set; }


        public TaskToDo() { DueDate = null; }


    }
}
