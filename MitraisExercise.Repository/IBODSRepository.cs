using MitraisExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitraisExercise.Repository
{
    interface IBODSRepository
    {
        Guid CreateRecord(DistributorModel model);

        bool UpdateRecord(DistributorModel model);

        bool UpdateBatchRecord(List<DistributorModel> models);

        List<DistributorModel> FilterRecord(FilterModel model);
    }
}
