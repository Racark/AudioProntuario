using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudioProntuario.Models
{
    public class Audio
    {
        [Key]
        public int idAudio { get; set; }

        public string AudioProntuario { get; set; }
    }
}