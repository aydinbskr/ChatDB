using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data.SqlClient;

namespace DataAccess
{
    public class daMember
    {
        public List<doMember> GetAllMembers(int? id, string username, string password, bool? banned, bool? online)
        {
            List<doMember> returnList = new List<doMember>();

            SqlConnection cnn = Helpers.SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(@"
SELECT
    MBR_Id, MBR_Name, MBR_Password, MBR_Banned, MBR_Online
FROM
    Member
WHERE
    1 = 1 ", cnn);

            if (id.HasValue)
            {
                cmd.CommandText += " AND MBR_Id = @MBR_Id";
                cmd.Parameters.AddWithValue("@MBR_Id", id.Value);
            }
            if (!string.IsNullOrWhiteSpace(username))
            {
                cmd.CommandText += " AND MBR_Name = @MBR_Name";
                cmd.Parameters.AddWithValue("@MBR_Name", username);
            }
            if (!string.IsNullOrWhiteSpace(password))
            {
                cmd.CommandText += " AND MBR_Password = @MBR_Password";
                cmd.Parameters.AddWithValue("@MBR_Password", password);
            }
            if (banned.HasValue)
            {
                cmd.CommandText += " AND MBR_Banned = @MBR_Banned";
                cmd.Parameters.AddWithValue("@MBR_Banned", banned.Value);
            }
            if (online.HasValue)
            {
                cmd.CommandText += " AND MBR_Online = @MBR_Online";
                cmd.Parameters.AddWithValue("@MBR_Online", online.Value);
            }
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                doMember member = new doMember();
                member.Id = Convert.ToInt32(rdr["MBR_Id"]);
                member.Username = Convert.ToString(rdr["MBR_Name"]);
                member.Password = Convert.ToString(rdr["MBR_Password"]);
                member.Banned = Convert.ToBoolean(rdr["MBR_Banned"]);
                member.Online = Convert.ToBoolean(rdr["MBR_Online"]);

                returnList.Add(member);
            }

            rdr.Close();
            cnn.Close();


            return returnList;
        }

        public void UpdateMember(doMember member)
        {
            SqlConnection cnn = Helpers.SqlHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(@"
UPDATE Member
SET
MBR_Name = @MBR_Name,
MBR_Password = @MBR_Password,
MBR_Banned = @MBR_Banned,
MBR_Online = @MBR_Online
WHERE
MBR_Id = @MBR_Id", cnn);
            cmd.Parameters.AddWithValue("@MBR_Name", member.Username);
            cmd.Parameters.AddWithValue("@MBR_Password", member.Password);
            cmd.Parameters.AddWithValue("@MBR_Banned", member.Banned);
            cmd.Parameters.AddWithValue("@MBR_Id", member.Id);
            cmd.Parameters.AddWithValue("@MBR_Online", member.Online);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
