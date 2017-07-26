using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore_MySql.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

        [JsonIgnore]
        public AppDb Db { get; set; }

        public Employee(AppDb db = null)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `Employee` (`Name`, `Address`,`PhoneNo`) VALUES (@Name, @Address,@PhoneNo);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE `Employee` SET `Name` = @Name, `Address` = @Address,`PhoneNo` = @PhoneNo WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM `Employee` WHERE `Id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",DbType = DbType.Int32, Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Name",DbType = DbType.String,Value = Name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Address",DbType = DbType.String,Value = Address,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@PhoneNo",DbType = DbType.String,Value = PhoneNo,
            });
        }
    }
}
