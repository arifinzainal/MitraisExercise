using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitraisExercise.Models
{
    public class DistributorModel
    {
        public Guid BodsId { get; set; }

        public string BodsFullName { get; set; }

        public Status BodsStatus { get; set; }
    }
    public enum Status { Active = 1, InActive = 2, Archived = 3 }
}