using DBLayer;
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Evaluation_Manager.Repositories
{
    public class ActivityRepository
    {
        public static Activity GetActivity(int id)
        {
            Activity activity = null;

            DB.OpenConnection();

            var dr = DB.GetDataReader($"SELECT * FROM Activities WHERE Id = {id}");

            if (dr.HasRows)
            {
                dr.Read();
                activity = CreateObject(dr);
            }

            DB.CloseConnection();

            return activity;
        }

        public static List<Activity> GetActivities()
        {
            List<Activity> activities = new List<Activity>();

            DB.OpenConnection();

            var dr = DB.GetDataReader($"SELECT * FROM Activities");

            while (dr.Read())
            {
                Activity activity = CreateObject(dr);
                activities.Add(activity);
            }

            DB.CloseConnection();

            return activities;
        }

        private static Activity CreateObject(SqlDataReader dr)
        {
            return new Activity()
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                MaxPoints = int.Parse(dr["MaxPoints"].ToString()),
                MinPointsForGrade = int.Parse(dr["MinPointsForGrade"].ToString()),
                MinPointsForSignature = int.Parse(dr["MinPointsForSignature"].ToString()),
            };
        }
    }
}
