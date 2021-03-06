﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_User_Role")]
    public class UserRole
    {
        [Key]
        public int User_Role_ID { get; set; }
        public int User_ID { get; set; }
        public int Role_ID { get; set; }
        public bool Is_Active { get; set; }
    }
}
