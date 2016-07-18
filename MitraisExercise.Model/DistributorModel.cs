using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitraisExercise.Model
{

    public class DistributorModel
    {
        public Guid BodsId { get { return Guid.NewGuid(); } set { BodsId = value; } }

        public string BodsFullName { get; set; }

        public Status BodsStatus { get; set; }
    }
    public enum Status { None = 0, Active = 1, InActive = 2, Archived = 3 }
}
