using Maintenance.Models;
using Maintenance.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maintenance
{
    public partial class ScheduleForm : Form
    {
        public Schedule Schedule
        {
            get
            {
                this.bindingSource1.EndEdit();
                this.Validate();
                return this.bindingSource1.DataSource as Schedule;
            }

            set
            {
                this.bindingSource1.DataSource = value;
            }
        }
        public ScheduleForm()
        {
            InitializeComponent();
            this.okΒutton.Click += okΒutton_Click;
            
            using(MachinesRepository repo = new MachinesRepository())
            {
                this.machineBindingSource.DataSource = repo.Get();
            }
            using (EmployeesRepository repo = new EmployeesRepository())
            {
                this.employeeBindingSource.DataSource = repo.Get();
            }
        }

        void textBox1_Validating(object sender, CancelEventArgs e)
        {
            var obj = sender as TextBox;
            if (string.IsNullOrWhiteSpace(obj.Text))
            {
                this.errorProvider1.SetError(obj, "Πρέπει να συμπληρωθεί.");
                e.Cancel = true;
            }
            else
                this.errorProvider1.SetError(obj, null);
        }

        void comboBox_Validating(object sender, CancelEventArgs e)
        {
            var obj = sender as ComboBox;
            if (string.IsNullOrWhiteSpace(obj.SelectedValue as string))
            {
                this.errorProvider1.SetError(obj, "Πρέπει να συμπληρωθεί.");
                e.Cancel = true;
            }
            else
                this.errorProvider1.SetError(obj, null);
        }

        void okΒutton_Click(object sender, EventArgs e)
        {
            try
            {   
                var obj = this.Schedule;
                bool hasError = false;

                if (string.IsNullOrWhiteSpace(obj.MachineId))
                {
                    this.errorProvider1.SetError(comboBox1, "Πρέπει να συμπληρωθεί.");
                    hasError = true;                   
                }
                else
                    this.errorProvider1.SetError(comboBox1, null);

                if (string.IsNullOrWhiteSpace(obj.Recurrence))
                {
                    this.errorProvider1.SetError(comboBox2, "Πρέπει να συμπληρωθεί.");
                    hasError = true;
                }
                else
                    this.errorProvider1.SetError(comboBox2, null);

                if (string.IsNullOrWhiteSpace(obj.Inspection))
                {
                    this.errorProvider1.SetError(textBox1, "Πρέπει να συμπληρωθεί.");
                    hasError = true;
                }
                else
                    this.errorProvider1.SetError(textBox1, null);

                if(obj.Done)
                {
                    if (string.IsNullOrWhiteSpace(obj.Work))
                    {
                        this.errorProvider1.SetError(textBox2, "Πρέπει να συμπληρωθεί αν η επιθεώρηση έχει ολοκληρωθεί.");
                        hasError = true;
                    }
                    else
                        this.errorProvider1.SetError(textBox2, null);

                    if (string.IsNullOrWhiteSpace(obj.EmployeeId))
                    {
                        this.errorProvider1.SetError(comboBox3, "Πρέπει να συμπληρωθεί αν η επιθεώρηση έχει ολοκληρωθεί.");
                        hasError = true;
                    }
                    else
                        this.errorProvider1.SetError(comboBox3, null);
                }
                
                if (hasError)
                    return;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message);
            }
        }

        public ScheduleForm(Schedule obj) : this()
        {
            this.bindingSource1.DataSource = obj;
        }
    }
}