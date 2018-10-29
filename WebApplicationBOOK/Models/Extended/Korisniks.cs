using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationBOOK.Models.Extended
{
    [MetadataType(typeof(KorisnikeMetadata))]

    public partial class Korisniks
   
    {


    }
    public class KorisnikeMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo osigurajte Ime")]
        public string FristName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Molimo osigurajte Prezime")]
        public string LastName { get; set; }

    }
}