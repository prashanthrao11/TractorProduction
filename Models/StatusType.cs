using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Status_Type")]
    public class StatusType
    {
        [Key]
        public int Status_Type_Id { get; set; }
        public string Status_Type_Key { get; set; }
        public string Status_Type_Name { get; set; }
    }
}
