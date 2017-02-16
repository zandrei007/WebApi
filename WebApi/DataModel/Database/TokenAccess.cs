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

        public User Authenticate(User user)
        {
            var command = new SqlCommand("Authenticate")
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);

            var ds = Gateway.Instance.Submit(command);
            var dt = ds.Tables["data"];


            var userResult = new User();
            bool isValid = false;
            foreach (DataRow d in dt.Rows)
            {
                userResult.Name = d["name"].ToString();
                userResult.Token = d["token"].ToString();
            }

            return userResult;
        }
    }
}
