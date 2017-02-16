using BusinessEntities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataModel.GenericRepo;

namespace DataModel.Database
{
    public class TokenAccess
    {
        public bool Validate(string token)
        {
            var command = new SqlCommand("ValidateToken")
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@token", token);

            var ds = Gateway.Instance.Submit(command);
            var dt = ds.Tables["data"];

            bool isValid = false;
            foreach (DataRow d in dt.Rows)
            {
                isValid = (bool)d["isValid"];
            }

            return isValid && dt.Rows.Count == 1;
        }

    }
}
