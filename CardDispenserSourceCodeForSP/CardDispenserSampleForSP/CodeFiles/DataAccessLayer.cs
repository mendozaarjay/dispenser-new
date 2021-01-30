using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDispenserSampleForSP
{
    public class DataAccessLayer
    {
        private const string TicketStoredProcedure = "[dbo].[spGenerateNewTicket]";
        private const string HistoryStoredProcedure = "[dbo].[InsertHistory]";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parkingId">Parking Id (Ex. 001)</param>
        /// <param name="gateId">Gate Id (Ex. 01)</param>
        /// <param name="location">Location (Ex. Smarcom)</param>
        /// <param name="terminal">Terminal (Ex. Dispenser1)</param>
        /// <param name="serialId">Serial Id</param>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="userid">User Id</param>
        /// <returns></returns>
        public string GenerateNewHistory(string parkingId, string gateId, string location, string terminal, string serialId, string ipAddress, string userid, string sqlConnectionString)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = TicketStoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@GateId", gateId.Replace("0", ""));
            cmd.Parameters.AddWithValue("@Location", location);
            cmd.Parameters.AddWithValue("@Terminal", terminal);
            cmd.Parameters.AddWithValue("@User", userid);

            var ticketNo = SCObjects.ExecuteNonQueryWithReturn(cmd, sqlConnectionString);

            cmd = new SqlCommand();
            cmd.CommandText = HistoryStoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ParkingId", parkingId);
            cmd.Parameters.AddWithValue("@GateId", gateId);
            cmd.Parameters.AddWithValue("@Location", location);
            cmd.Parameters.AddWithValue("@Terminal", terminal);
            cmd.Parameters.AddWithValue("@Serial", serialId);
            cmd.Parameters.AddWithValue("@Ticket", ticketNo);
            cmd.Parameters.AddWithValue("@InIPAddress", ipAddress);
            cmd.Parameters.AddWithValue("@UserId", userid);
            var result = SCObjects.ExecNonQuery(cmd, sqlConnectionString);
            return result;
        }

    }
}
