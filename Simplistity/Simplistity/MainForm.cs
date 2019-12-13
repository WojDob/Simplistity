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

        //======================Adding tasks======================

        public void addTask(Todo task)
        {
            tasks.Add(task);
            addToListview(task);
            save();
        }

        private void addToListview(Todo task)
        {
            
            ListViewItem item = new ListViewItem();
            item.Text = task.getTaskText();
            if (task.Checked)
                item.Checked = true;
            listView1.Items.Add(item);

        }

        private void refreshListView()
        {
            listView1.Items.Clear();
            foreach (Todo task in tasks)
            {
                addToListview(task);
            }
        }

        //======================File handling======================

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
            if (File.Exists("Todo.xml"))
            {
                XDocument xml = XDocument.Load("Todo.xml");

                tasks = (from task in xml.Root.Elements("task")
                         select new Todo(
                             task.Element("description").Value,
                             task.Element("priority").Value,
                             task.Element("dueDate").Value,
                             Convert.ToBoolean(task.Element("checked").Value)
                        )).ToList<Todo>();

                foreach (Todo task in tasks)
                {
                    addToListview(task);
                }
            }
            else
            {
                save();
            }
        }

        //=======================Buttons======================

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.Show();
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            //write checked items to file
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Directory.GetCurrentDirectory()+"\\done.txt", true))
            {
                foreach (Todo task in tasks)
                {
                    if (task.Checked)
                    {
                        file.WriteLine("x " + task.getTaskText());
                    }
                }
            }

            //remove tasks form task list
            tasks.RemoveAll(item => item.Checked == true);

            //remove tasks from listview
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                    listView1.Items.Remove(item);
            }

            save();
        }

        //======================Events======================

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                foreach (Todo task in tasks)
                {
                    if (item.Text.Equals(task.getTaskText()) && item.Checked)
                        task.Checked = true;
                    if (item.Text.Equals(task.getTaskText()) && item.Checked==false)
                        task.Checked = false;
                }
            }
            save();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            tasks = tasks.OrderBy(x => x.DueDate).ToList();
            refreshListView();
            save();
        }

    }
}
