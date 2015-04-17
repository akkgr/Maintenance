
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maintenance.Models
{
    public class Employee
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
