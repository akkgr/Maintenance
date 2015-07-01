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
            this.listView1.OwnerDraw = true;
            this.listView1.UseSubItemCheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.DoubleClick += listView1_DoubleClick;
            this.toolStrip1.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
            this.toolStrip2.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
            this.toolStrip2.Visible = false;
            this.statusStrip1.Renderer = Antiufo.Controls.Windows7Renderer.Instance;
            this.toolStripButton1.Click += toolStripButton1_Click;
            this.toolStripButton2.Click += toolStripButton2_Click;
        }

        void toolStripButton1_Click(object sender, EventArgs e)
        {
            SelectDateForm frm = new SelectDateForm();
            frm.Date = Convert.ToDateTime(this.toolStripTextBox1.Text);
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.toolStripTextBox1.Text = string.Format("{0:d}", frm.Date);
                getSchedules();
            }
        }

        void toolStripButton2_Click(object sender, EventArgs e)
        {
            SelectDateForm frm = new SelectDateForm();
            frm.Date = Convert.ToDateTime(this.toolStripTextBox2.Text);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.toolStripTextBox2.Text = string.Format("{0:d}", frm.Date);
                getSchedules();
            }
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
                this.toolStrip2.Visible = false;
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
                this.toolStrip2.Visible = false;
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
                this.toolStripTextBox1.Text = string.Format("{0:d}", DateTime.Now.Date);
                this.toolStripTextBox2.Text = string.Format("{0:d}", DateTime.Now.Date);
                this.toolStrip2.Visible = true;
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

        private void getSchedules()
        {
            var d1 = Convert.ToDateTime(this.toolStripTextBox1.Text);
            var d2 = Convert.ToDateTime(this.toolStripTextBox2.Text);
            (view as SchedulesView).GetByDates(this.listView1, d1, d2);
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

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (view == null) return;

            ListViewPrinter lvp = new ListViewPrinter();
            lvp.ListView = this.listView1;
            lvp.PrintPreview();
        }
    }
}
