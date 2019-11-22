using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplistity
{
    public partial class MainForm : Form
    {
        public List<TaskToDo> tasks = new List<TaskToDo>();

        public MainForm()
        {
            
            InitializeComponent();

        }
        public void addToListview(TaskToDo task)
        {
            ListViewItem item = new ListViewItem();
            item.Text = (task.Priority + " " + task.ToDo);
            if (task.DueDate.HasValue)
                item.Text = item.Text + " " + task.DueDate.Value.ToShortDateString();
            listView1.Items.Add(item);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.Show();
        }
    }
}
