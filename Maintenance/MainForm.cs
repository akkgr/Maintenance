using BrightIdeasSoftware;
using Maintenance.Models;
using Maintenance.Repositories;
using Maintenance.Views;
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
    public partial class MainForm : Form
    {
        private IView view; 
        public MainForm()
        {
            InitializeComponent();
            this.listView1.ShowGroups = false;
            this.listView1.UseFiltering = true;
            this.listView1.UseSubItemCheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.DoubleClick += listView1_DoubleClick;
            this.toolStrip1.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
            this.statusStrip1.Renderer = Antiufo.Controls.Windows7Renderer.Instance;            
        }

        void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (view == null) return;
            try
            {
                view.Edit(this.listView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void machinesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.findToolStripTextBox.Text = string.Empty;
                view = new MachinesView();
                try
                {
                    view.Get(this.listView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void employeesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.findToolStripTextBox.Text = string.Empty;
                view = new EmployeesView();
                try
                {
                    view.Get(this.listView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void scheduleToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.findToolStripTextBox.Text = string.Empty;
                view = new SchedulesView();
                try
                {
                    view.Get(this.listView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            if (view == null) return;
            try
            {
                view.New(this.listView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (view == null) return;
            if (this.listView1.SelectedObject == null)
                return;

            string message = "Να γίνει διαγραφή της επιλεγμένης εγγραφής;";
            if(MessageBox.Show(message,"Προσοχή",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    view.Delete(this.listView1);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void findToolStripButton_Click(object sender, EventArgs e)
        {
            if (view == null) return;
            view.Filter(this.listView1, this.findToolStripTextBox.Text);
        }
    }
}
