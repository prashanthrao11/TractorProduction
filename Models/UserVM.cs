using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("VW_UserDetails")]
    public class UserVM
    {
        [Key]
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public bool Is_Active{get;set;}
        public int User_Role_ID { get; set; }
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }
        public string DepartmentIds { get; set; }
        public string DepartmentNames { get; set; }
    }
}
