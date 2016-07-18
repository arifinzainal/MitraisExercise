using MitraisExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitraisExercise.Attributes
{
    public class SoapServiceResponse
    {
        public bool ProcessResult { get; set; }

        public List<string> ErrorMessages { get; set; }

        public List<DistributorModel> DataResults { get; set; }
    }
}