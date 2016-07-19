using System;
using System.Collections.Generic;
using MitraisExercise.Model;
using System.Data;

namespace MitraisExercise.Repository
{
    public class BODSREpository:IBODSRepository
    {
        private DataTable DataTable { get; set; }

        public BODSREpository()
        {
            LoadData();
        }

        public DistributorModel CreateRecord(DistributorModel model)
        {
            DataTable.Rows.Add(model.BodsId, model.BodsFullName, model.BodsStatus);
            DataTable.AcceptChanges();
            return model;
        }

        public List<DistributorModel> FilterRecord(FilterModel model)
        {
            var filter = string.Empty;
            var result = new List<DistributorModel>();
            var rows = new List<DataRow>().ToArray();

            if (model.DistributorId != null)
            {
                filter = String.Format("BODS_Id={0}",model.DistributorId);
            }

            if (model.DistributorStatus != 0)
            {
                filter = String.Format("BODS_Status={0}", model.DistributorStatus);
            }

            if (model.DistributorId != null && model.DistributorStatus != 0)
            {
                filter = String.Format("BODS_Id={0} AND BODS_Status={1}", model.DistributorId, model.DistributorStatus);
            }
            rows = !string.IsNullOrEmpty(filter) ? DataTable.Select(filter) : DataTable.Select();

            foreach (var row in rows)
            {                
                result.Add(ConstructDistributorModel(row));
            }
            return result;
        }

        public bool UpdateRecord(DistributorModel model)
        {

            var result = false;
            try
            {
                var filter = String.Format("BODS_Id={0}", model.BodsId);             //filter first based on Bods Id 
                var rows = DataTable.Select(filter);
                rows[0]["BODS_Id"] = model.BodsId;
                rows[0]["BODS_FullName"] = model.BodsFullName;
                rows[0]["BODS_Status"] = model.BodsStatus;
                DataTable.AcceptChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
       

        #region Private Method 
        private void LoadData()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add("BODS_Id", typeof(Guid)).AllowDBNull = false;
            DataTable.Columns.Add("BODS_FullName", typeof(string)).AllowDBNull = false;
            DataTable.Columns.Add("BODS_Status", typeof(byte)).AllowDBNull = false;
            DataTable.PrimaryKey = new[] { DataTable.Columns[0] };
            DataTable.Rows.Add(new Guid("617dba9d-391b-4ca7-aeeb-0703ca526709"), "My Website", 1);
            DataTable.Rows.Add(new Guid("bee3c0be-ccbf-4882-ad5a-d288f5677a51"), "Test V3 Offload", 2);
            DataTable.Rows.Add(new Guid("5df458a8-a743-4e81-bf0d-bd874f6f0cd3"), "About Australia", 3);
            DataTable.AcceptChanges();
        }

        private DistributorModel ConstructDistributorModel(DataRow selectedRow)
        {
            var distributorStatus = int.Parse(selectedRow[2].ToString());
            return new DistributorModel
            {
                BodsId = Guid.Parse(selectedRow[0].ToString()),
                BodsFullName = selectedRow[1].ToString(),
                BodsStatus = (Status) distributorStatus};
        }
        #endregion
    }
}
