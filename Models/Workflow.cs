using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Workflow")]
    public class Workflow
    {
        [Key]
        public int Workflow_ID { get; set; }
        public string Workflow_Key { get; set; }
        public string Workflow_Name { get; set; }
        public string Workflow_Desc { get; set; }

        public bool Is_Active { get; set; }
    }
}
