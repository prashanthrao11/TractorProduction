using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_DepartmentUsers")]
    public class DepartmentUsers
    {
        [Key]
        public int DepartmentUser_ID { get; set; }
        public int User_ID { get; set; }
        public int Department_ID { get; set; }
        public bool Is_Active { get; set; }
    }
}
