using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    public class ProductionFinalApproval
    {
        [Key]
        public int Final_Approval_ID { get; set; }
        public int Final_Approval_Status_ID { get; set; }
        public int Submitted_By_ID { get; set; }
        
    }
}
