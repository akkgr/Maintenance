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
    public partial class SelectDateForm : Form
    {
        public DateTime Date { get; set; }

        public SelectDateForm()
        {
            InitializeComponent();

            this.Load += SelectDateForm_Load;
        }

        void SelectDateForm_Load(object sender, EventArgs e)
        {
            this.monthCalendar1.SetDate ( this.Date );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Date = this.monthCalendar1.SelectionStart;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
