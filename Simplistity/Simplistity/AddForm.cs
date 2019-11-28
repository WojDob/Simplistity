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

        private void addTask()
        {
            Todo task = new Todo();

            if(String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Please add a description of your task.");
                textBox.BackColor = Color.IndianRed;
                return;
            }

            task.Description = textBox.Text;
            task.Priority = comboBox.Text;
            if(checkBox.Checked)
                task.DueDate = dateTimePicker.Value;

            foreach (Todo todo in mainForm.tasks)
            {
                if(todo.getTaskText().Equals(task.getTaskText()))
                {
                    MessageBox.Show("This task has already been created.");
                    return;
                }
            }

            mainForm.addTask(task);
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

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Text.Equals("None"))
            {
                comboBox.SelectedItem = null;
                comboBox.Text = "";
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker.Enabled = checkBox.Checked;
        }

    }
}
