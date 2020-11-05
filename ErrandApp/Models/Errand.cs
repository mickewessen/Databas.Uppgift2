using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrandApp.Models
{
    public partial class Errand
    {
        public Errand(string description, DateTime creationTime, string customerFirstName, string customerLastName, string customerEmail, int? customerPhonenumber, string status, string category, string createdby)
        {
            Description = description;
            CreationTime = creationTime;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CustomerEmail = customerEmail;
            CustomerPhonenumber = customerPhonenumber;
            Status = status;
            Category = category;
            Createdby = createdby;
        }

        public Errand(string description, string status, string category, string comment)
        {
            Description = description;
            Status = status;
            Category = category;
            Comment = comment;
        }

        public Errand()
        {
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationTime { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        public int? CustomerPhonenumber { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        [Required]
        [StringLength(50)]
        public string Createdby { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
    }
}
