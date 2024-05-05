using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace PPMDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Kai> Query<Kai>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var lst = db.Query<Kai>(query, param).ToList();
            return lst;
        }
        public Kai QueryFirstOrDefault<Kai>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<Kai>(query, param).FirstOrDefault();
            return item!;
        }
        public int Execute(string query , object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }
    }
}
