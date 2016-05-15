using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Physics.Api.Models
{
    public class DensityParameters
    {
        [Required]
        [Range(0, float.MaxValue)]
        public float Volume { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public float Weight { get; set; }
    }
}