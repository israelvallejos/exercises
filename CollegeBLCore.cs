using CollegeTracker.DAL;
using CollegeTrackerCore;
using CollegeTrackerModels;
using System;
using System.Collections.Generic;

namespace CollegeTrackerCore.BLL
{
    public abstract class CollegeBLCore
    {
        #region Public Method  
        /// <summary>  
        /// This method is used to get the College Details  
        /// </summary>  
        /// <returns></returns>  
        protected List<CollegeDetails> GetAllCollegeDetails()
        {
            List<CollegeDetails> objCollegeDetails = null;
            try
            {
                objCollegeDetails = new CollegeDAL().GetAllCollegeDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objCollegeDetails;
        }
        #endregion
    }
}