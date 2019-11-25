using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace Simplistity
{
    public partial class MainForm : Form
    {
        public List<Todo> tasks = new List<Todo>();

        public MainForm()
        {
            InitializeComponent();
            load();
        }
        public void addToListview(Todo task)
        {

            ListViewItem item = new ListViewItem();
            item.Text = task.getTaskText();
            if (task.Checked)
                item.Checked = true;
            listView1.Items.Add(item);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.Show();
        }

        public void save()
        {

            XDocument xml = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("tasks",
                from task in tasks
                select new XElement("task",
                    new XElement("description", task.Description),
                    new XElement("dueDate", task.DueDate),
                    new XElement("priority", task.Priority),
                    new XElement("checked",task.Checked)
                    )
                )
            );
            xml.Save("Todo.xml");
        }

        private void load()
        {
            XDocument xml = XDocument.Load("Todo.xml");

            tasks = (from task in xml.Root.Elements("task")
                     select new Todo(
                         task.Element("description").Value,
                         task.Element("priority").Value,
                         task.Element("dueDate").Value,
                         Convert.ToBoolean(task.Element("checked").Value)
                    )).ToList<Todo>();

            foreach(Todo task in tasks)
            {
                addToListview(task);
            }
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tasks.Count.ToString());

            tasks.RemoveAll(item => item.Checked == true);
            MessageBox.Show(tasks.Count.ToString());
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                    listView1.Items.Remove(item);
            }
            save();
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                foreach (Todo task in tasks)
                {
                    if (item.Text.Equals(task.getTaskText()) && item.Checked)
                        task.Checked = true;
                }
            }
            save();
        }
    }
}
