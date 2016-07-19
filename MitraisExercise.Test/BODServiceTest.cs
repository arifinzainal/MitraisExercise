using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitraisExercise.Model;

namespace MitraisExercise.Test
{
    [TestClass()]
    public class BODSServiceTest
    {
        #region Web Service Initialisation
        private static BODSService.BODSServiceSoapClient _service;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            _service = new BODSService.BODSServiceSoapClient();
        }

        [ClassCleanup]
        public static void CleanUpClass()
        {
            _service.Close();
        }
        #endregion


        [TestMethod]
        public void CreateDistributorRecord()
        {
            var entity = new DistributorModel { BodsFullName = "Test", BodsStatus = Status.Active };
            var result = _service.AddDistributorRecord(new BODSService.DistributorModel
                            {
                              BodsId = entity.BodsId,
                              BodsFullName = entity.BodsFullName,
                              BodsStatus =  (BODSService.Status)entity.BodsStatus
                            });
            Assert.AreEqual(entity.BodsId, result.DataResults[0].BodsId);
        }

        [TestMethod]
        public void UpdateDistributorRecord()
        {
            var entityToUpdate = new DistributorModel {
                                    BodsId = new Guid("617dba9d-391b-4ca7-aeeb-0703ca526709"),
                                    BodsFullName = "Test Web Site",
                                    BodsStatus = Status.Archived };

            var result = _service.UpdateDistributorRecord(new BODSService.DistributorModel {
                            BodsId = entityToUpdate.BodsId,
                            BodsFullName = entityToUpdate.BodsFullName,
                            BodsStatus = (BODSService.Status)entityToUpdate.BodsStatus });

            Assert.AreEqual(result.DataResults[0].BodsFullName, entityToUpdate.BodsFullName);

        }
      
    }
}
