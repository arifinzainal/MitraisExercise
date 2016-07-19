using MitraisExercise.Model;
using System.Collections.Generic;

namespace MitraisExercise.Repository
{
    interface IBODSRepository
    {
        DistributorModel CreateRecord(DistributorModel model);

        bool UpdateRecord(DistributorModel model);
        
        List<DistributorModel> FilterRecord(FilterModel model);
    }
}
