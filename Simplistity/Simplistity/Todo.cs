using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Simplistity
{
    public class Todo
    {
        public string Description { get; set; }
        public string Priority { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? DueDate { get; set; }

        public bool Checked { get; set; }



        public Todo() { DueDate = null; Checked = false; }

        public Todo(string description, string priority, string dueDate, bool check)
        {
            Description = description;
            Priority = priority;
            if (!string.IsNullOrEmpty(dueDate))
                DueDate = Convert.ToDateTime(dueDate);
            else
                DueDate = null;
            Checked = check;
        }

        public string getTaskText()
        {
            string taskText = (Priority + " " + Description);
            if (DueDate.HasValue)
                taskText = taskText + " " + DueDate.Value.ToShortDateString();
            return taskText;
        }
    }
}
