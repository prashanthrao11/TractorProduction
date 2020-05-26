using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_User")]
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }

        [NotMapped]
        public int Role_ID { get; set; }

        [NotMapped]
        public int Role_Name { get; set; }
        public bool Is_Active { get; set; }

    }
}
