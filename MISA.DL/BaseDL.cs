using Dapper;
using MISA.DL.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class BaseDL<MISAEntity> : IBaseDL<MISAEntity>
    {

        protected string _connectionString = "" +
                       "Host = 47.241.69.179;" +
                       "Port = 3306;" +
                       "User Id = dev;" +
                       "Password = 12345678;" +
                       "Database = 15B_MS145_AMIS_DQDAT;";

        protected IDbConnection _dbConnection;

        public IEnumerable<MISAEntity> GetAll()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{tableName}s ";
               
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }

        }

        public MISAEntity GetById(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"SELECT * FROM {tableName} WHERE {tableName}Id = '{entityId.ToString()}'";
                var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand);
                return entity;
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var storeName = $"Proc_Insert{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
        public int Update(MISAEntity entity, Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var entityIdPropertyName = $"{tableName}Id";

                typeof(MISAEntity).GetProperty($"{entityIdPropertyName}").SetValue(entity, entityId);

                var storeName = $"Proc_Update{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Delete(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"DELETE FROM {tableName} WHERE {tableName}.{tableName}Id = '{entityId.ToString()}'";
                var rowsAffect = _dbConnection.Execute(sqlCommand);
                return rowsAffect;

            }
        }
    }
}
