using System;
using System.Web.Services;
using MitraisExercise.Model;
using MitraisExercise.Repository;
using System.Collections.Generic;

namespace MitraisExercise.WebServices
{
    /// <summary>
    /// Summary description for BODSService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BODSService : WebService
    {
        private readonly BODSREpository _repository;

        public BODSService()
        {
            _repository = new BODSREpository();
        }

        [WebMethod]
        public SoapServiceResponse AddDistributorRecord(DistributorModel entity)
        {
            var response = new SoapServiceResponse();
            try
            {
                var result = _repository.CreateRecord(entity);
                response.ProcessResult = result != null ? true : false;
                response.DataResults = new List<DistributorModel> { result };
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
            }
            return response;
        }

        [WebMethod]
        public SoapServiceResponse UpdateDistributorRecord(DistributorModel entity)
        {
            var response = new SoapServiceResponse();
            try
            {
                var result = _repository.UpdateRecord(entity);
                response.ProcessResult = result;
                response.DataResults = new List<DistributorModel> {  entity };
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
            }
            return response;
        }

        [WebMethod]
        public SoapServiceResponse FilterDistributorRecord(FilterModel filter)
        {
            var response = new SoapServiceResponse();
            try
            {
                var results = _repository.FilterRecord(filter);
                response.ProcessResult = results.Count > 0 ? true : false; // false means that no record is displayed
                response.DataResults = results;
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
            }
            return response;
        }

    }
}
