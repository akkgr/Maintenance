using BrightIdeasSoftware;
using Recurrence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Maintenance.Models
{
    public class Schedule
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string MachineId { get; set; }

        [Required]
        public DateTime CurrentDate { get; set; }

        [Required]
        public string Recurrence { get; set; }

        [Required]
        public string Inspection { get; set; }

        public string Work { get; set; }

        public DateTime NextDate { get; set; }

        public string EmployeeId { get; set; }

        public bool Done { get; set; }

        [ForeignKey("MachineId")]
        public virtual Machine Machine { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public void UpdateNextTime()
        {
            switch (this.Recurrence)
            {
                case "Ημερήσια":
                    this.NextDate = Recur.Daily().StartingFrom(this.CurrentDate).Next();
                    break;
                case "Εβδομαδιαία":
                    this.NextDate = Recur.Weekly().StartingFrom(this.CurrentDate).Next();
                    break;
                case "Μηνιαία":
                    this.NextDate = Recur.Monthly().StartingFrom(this.CurrentDate).Next();
                    break;
                case "Τριμηνιαία":
                    this.NextDate = Recur.Quarterly().StartingFrom(this.CurrentDate).Next();
                    break;
                case "Εξαμηνιαία":
                    this.NextDate = Recur.Βiannual().StartingFrom(this.CurrentDate).Next();
                    break;
                case "Ετήσια":
                    this.NextDate = Recur.Yearly().StartingFrom(this.CurrentDate).Next();
                    break;
            }
        }
    }
}
