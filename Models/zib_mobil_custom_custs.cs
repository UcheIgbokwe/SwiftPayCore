using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwiftPayCore.Models
{
    public class zib_mobil_custom_custs
    {
        [Required]
        public int customer_id { get; set; }
        [Required]
        public string customer_name { get; set; }
        [Required]
        public DateTime create_dt { get; set; }
        [Required]
        public int empl_id { get; set; }
        //DEFAULT 'Y'
        [Required]
        public char back_date_tran { get; set; }
        //DEFAULT 'N'
        [Required]
        public char enable_pooling { get; set; }
        public string pool_acct_no { get; set; }
        public DateTime? pooling_cut_off { get; set; }
        public string pooling_option { get; set; }
        public string status { get; set; }
        public DateTime? last_pooling_dt { get; set; }
        
    }

    public class zib_mobil_custom_custsDTO
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public DateTime create_dt { get; set; }
        public int empl_id { get; set; }
        public char back_date_tran { get; set; }
        public char enable_pooling { get; set; }
        public string pool_acct_no { get; set; }
        public DateTime pooling_cut_off { get; set; }
        public string pooling_option { get; set; }
        public string status { get; set; }
        public DateTime last_pooling_dt { get; set; }
    }
}