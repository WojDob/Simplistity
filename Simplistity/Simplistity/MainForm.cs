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
        private List<TaskToDo> tasks = new List<TaskToDo>();

        public MainForm()
        {
            
            InitializeComponent();
            tasks.Add(new TaskToDo("get good at c#", "A"));
            tasks.Add(new TaskToDo("finish this program", "B"));
            refresh();

        }

        private void refresh()
        {
            foreach (TaskToDo obj in tasks)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (obj.Priority + " " + obj.ToDo);

                item.Tag = obj;

                listView1.Items.Add(item);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }
    }
}
