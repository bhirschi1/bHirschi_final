using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bHirschi_final.Models
{
    public class Entertainer
        //Create the Entertainer class according to the sqlite db
    {
        [Required]
        [Key]
        public int EntertainerID { get; set; }
        public string EntStageName { get; set; }
     
        public string EntSSN { get; set; }
        public string EntStreetAddress { get; set; }
        public string EntCity { get; set; }
        public string EntState { get; set; }
        public string EntZipCode { get; set; }
        public string EntPhoneNumber { get; set; }
        public string EntWebPage { get; set; }
        public string EntEMailAddress { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
