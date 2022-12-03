using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CollegeTrackerModels;
using CollegeTrackerAPI.Areas.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeTrackerAPI.Areas.Controller
{
    public class CollegeDetailsController : ApiController
    {
        #region Variable  
        /// <summary>  
        /// varibale for CollegeBL  
        /// </summary>  
        private CollegeBL objCollegeBL;
        /// <summary>  
        /// variable for HttpResponseMessage  
        /// </summary>  
        HttpResponseMessage response;
        #endregion

        #region Response Method  
        /// <summary>  
        /// This method is used to fetch the College Details  
        /// </summary>  
        /// <returns></returns>  
        [HttpGet, ActionName("GetAllCollegeDetails")]
        public HttpResponseMessage GetAllCollegeDetails()
        {
            objCollegeBL = new CollegeBL();
            HttpResponseMessage response;
            try
            {
                var detailsResponse = objCollegeBL.GetAllCollegeDetails();
                if (detailsResponse != null)
                    response = Request.CreateResponse<List<CollegeDetails>>(HttpStatusCode.OK, detailsResponse);
                else
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        #endregion
    }
}