using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplistity
{
    class TaskToDo
    {
        public string ToDo { get; set; }
        public string Priority { get; set; }


        public TaskToDo(string todo, string priority)
        {
            this.ToDo = todo;
            this.Priority = priority;
        }


    }
}
