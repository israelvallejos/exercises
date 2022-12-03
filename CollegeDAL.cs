using System;
using System.Collections.Generic;
using CollegeTrackerModels;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CollegeTracker.DAL
{
    public class CollegeDAL
    {
        #region Variables  
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adap;
        DataTable dt;
        DataSet ds;
        string connectionstring = ConfigurationManager.ConnectionStrings["CollegeTrackerConnectionString"].ConnectionString;
        #endregion

        #region Constructor  
        public CollegeDAL()
        {
            con = new SqlConnection(this.connectionstring);
        }
        #endregion

        #region Public Method  
        /// <summary>  
        /// This method is used to get all College Details.  
        /// </summary>  
        /// <returns></returns>  
        public List<CollegeDetails> GetAllCollegeDetails()
        {
            List<CollegeDetails> objCollegeDetails = new List<CollegeDetails>();
            using (cmd = new SqlCommand("CT_CollegeDetails_Select", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    adap = new SqlDataAdapter();
                    adap.SelectCommand = cmd;
                    dt = new DataTable();
                    adap.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        CollegeDetails col = new CollegeDetails();
                        col.CollegeID = Convert.ToInt32(row["CollegeID"]);
                        col.CollegeName = row["CollegeName"].ToString();
                        col.CollegeAddress = row["CollegeAddress"].ToString();
                        col.CollegePhone = Convert.ToInt64(row["CollegePhone"]);
                        col.CollegeEmailID = row["CollegeEmailID"].ToString();
                        col.ContactPerson = row["ContactPerson"].ToString();
                        col.State = row["State"].ToString();
                        col.City = row["City"].ToString();
                        objCollegeDetails.Add(col);
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                }
                return objCollegeDetails;
            }
        }
        #endregion
    }
}