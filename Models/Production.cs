using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Production")]
    public class Production

    {
        [Key]
        public int Production_ID { get; set; }
        public int Workflow_ID { get; set; }
        public int Status_ID { get; set; }
        public DateTime? Date { get; set; }
        public string Tractor_Part_Number { get; set; }
        public string Engine_Part_Number { get; set; }
        public string Transmission_Part_Number { get; set; }
        public string Hydraulics_Part_Number { get; set; }
        public string Tractor_Series { get; set; }
        public string Engine_Series { get; set; }
        public string Transmission_Series { get; set; }
        public string Hydraulics_Series { get; set; }
        public string Tractor_SAP_Series { get; set; }
        public string Engine_SAP_Series { get; set; }
        public string Transmission_SAP_Series { get; set; }
        public string Hydraulics_SAP_Series { get; set; }
        public Boolean Is_Change_Tractor { get; set; }
        public Boolean Is_Change_Engine { get; set; }
        public Boolean Is_Change_Transmission { get; set; }
        public Boolean Is_Change_Hydraulics { get; set; }
        public string Created_By { get; set; }

        public DateTime? Created_Date { get; set; }

        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        [NotMapped]
        public string Status { get; set; }

    }
}
