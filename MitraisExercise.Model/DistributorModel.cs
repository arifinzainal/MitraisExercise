using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MitraisExercise.Model
{
    [DataContract]
    public class DistributorModel
    {
        public Guid BodsId { get; set; }

        public string BodsFullName { get; set; }

        public Status BodsStatus { get; set; }
    }
    [DataContract]
    public enum Status { None = 0, Active = 1, InActive = 2, Archived = 3 }
}
