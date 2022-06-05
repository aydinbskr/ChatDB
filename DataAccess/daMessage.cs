using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data.SqlClient;

namespace DataAccess
{
    public class daMessage
    {
        //MSG_Id, MSG_Body, MSG_To, MSG_From, MSG_IsToRead, MSG_IsToDeleted, MSG_IsFromDeleted, MSG_Date
        public List<doMessage> GetAllMessage(int? id, int? to, int? from, bool? isToRead, bool? isToDeleted, bool? isFromDeleted, DateTime? minDate)
        {
            List<doMessage> returnList = new List<doMessage>();

            SqlConnection cnn = Helpers.SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(@"
SELECT
    MSG_Id, MSG_Body, MSG_To, ToIcin.MBR_Name as ToAdi, MSG_From, FromIcin.MBR_Name As FromAdi, MSG_IsToRead, MSG_IsToDeleted, MSG_IsFromDeleted, MSG_Date
FROM
    Message
    INNER JOIN Member As FromIcin ON FromIcin.MBR_Id = Message.MSG_From
    INNER JOIN Member As ToIcin ON ToIcin.MBR_Id = Message.MSG_From
WHERE
    1 = 1 ", cnn);

            if (id.HasValue)
            {
                cmd.CommandText += " AND MSG_Id = @MSG_Id";
                cmd.Parameters.AddWithValue("@MSG_Id", id.Value);
            }


            if (to.HasValue)
            {
                cmd.CommandText += " AND MSG_To = @MSG_To";
                cmd.Parameters.AddWithValue("@MSG_To", to.Value);
            }
            else
            {
                cmd.CommandText += " AND MSG_To is null";
            }

            if (from.HasValue)
            {
                cmd.CommandText += " AND MSG_From = @MSG_From";
                cmd.Parameters.AddWithValue("@MSG_From", from.Value);
            }
            if (isToRead.HasValue)
            {
                cmd.CommandText += " AND MSG_IsToRead = @MSG_IsToRead";
                cmd.Parameters.AddWithValue("@MSG_IsToRead", isToRead.Value);
            }
            if (isToDeleted.HasValue)
            {
                cmd.CommandText += " AND MSG_IsToDeleted = @MSG_IsToDeleted";
                cmd.Parameters.AddWithValue("@MSG_IsToDeleted", isToDeleted.Value);
            }
            if (isFromDeleted.HasValue)
            {
                cmd.CommandText += " AND MSG_IsFromDeleted = @MSG_IsFromDeleted";
                cmd.Parameters.AddWithValue("@MSG_IsFromDeleted", isFromDeleted.Value);
            }
            if (minDate.HasValue)
            {
                cmd.CommandText += " AND MSG_Date >= @MSG_Date";
                cmd.Parameters.AddWithValue("@MSG_Date", minDate.Value);
            }
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                doMessage message = new doMessage();
                message.Id = Convert.ToInt32(rdr["MSG_Id"]);
                message.Body = Convert.ToString(rdr["MSG_Body"]);
                if (!rdr.IsDBNull(rdr.GetOrdinal("MSG_To")))
                    message.To = Convert.ToInt32(rdr["MSG_To"]);
                message.ToName = Convert.ToString(rdr["ToAdi"]);
                message.From = Convert.ToInt32(rdr["MSG_From"]);
                message.FromName = Convert.ToString(rdr["FromAdi"]);
                message.IsToRead = Convert.ToBoolean(rdr["MSG_IsToRead"]);
                message.IsToDeleted = Convert.ToBoolean(rdr["MSG_IsToDeleted"]);
                message.IsFromDeleted = Convert.ToBoolean(rdr["MSG_IsFromDeleted"]);
                message.Date = Convert.ToDateTime(rdr["MSG_Date"]);

                returnList.Add(message);
            }

            rdr.Close();
            cnn.Close();


            return returnList;
        }

        public void InsertMessage(int? to, int from, string body)
        {
            SqlConnection cnn = Helpers.SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(@"
INSERT INTO Message
(MSG_Body, " + ((to.HasValue) ? " MSG_To ," : " ") + "MSG_From, MSG_IsToRead, MSG_IsToDeleted, MSG_IsFromDeleted, MSG_Date)" + @"
VALUES
(@MSG_Body, " + ((to.HasValue) ? " @MSG_To ," : " ") + "@MSG_From, @MSG_IsToRead, @MSG_IsToDeleted, @MSG_IsFromDeleted, @MSG_Date)", cnn);
            cmd.Parameters.AddWithValue("@MSG_Body", body);
            if (to.HasValue)
                cmd.Parameters.AddWithValue("@MSG_To", to);
            cmd.Parameters.AddWithValue("@MSG_From", from);
            cmd.Parameters.AddWithValue("@MSG_IsToRead", false);
            cmd.Parameters.AddWithValue("@MSG_IsToDeleted", false);
            cmd.Parameters.AddWithValue("@MSG_IsFromDeleted", false);
            cmd.Parameters.AddWithValue("@MSG_Date", DateTime.Now);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
