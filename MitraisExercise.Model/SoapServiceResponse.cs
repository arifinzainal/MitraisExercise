using System.Collections.Generic;

namespace MitraisExercise.Model
{
    public class SoapServiceResponse
    {
        public bool ProcessResult { get; set; }

        public List<string> ErrorMessages { get; set; }

        public List<DistributorModel> DataResults { get; set; }
    }
}