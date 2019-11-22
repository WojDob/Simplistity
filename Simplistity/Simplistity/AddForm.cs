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
    public partial class AddForm : Form
    {
        private MainForm mainForm;
        public AddForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker.Enabled = checkBox.Checked;
        }

        private void addTask()
        {
            TaskToDo task = new TaskToDo();

            if(String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Please add a description of your task.");
                textBox.BackColor = Color.IndianRed;
                return;
            }

            task.ToDo = textBox.Text;
            task.Priority = comboBox.Text;
            if(checkBox.Checked)
                task.DueDate = dateTimePicker.Value;

            mainForm.addToListview(task);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addTask();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textBox.BackColor = Color.White;
        }
    }
}
