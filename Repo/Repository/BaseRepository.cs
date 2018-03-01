using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DataAccess.Database;

namespace Repo.Repository
{
    public abstract class BaseRepository<TKey, TEntities> : IRepository<TKey, TEntities> where TEntities : IEntities<TKey>
    {
        public string TableName { get; set; }
        private const string CONNECTION_STRING = @"Server=GREG-WORK;Database=OnlineGame;Trusted_Connection=True;";
        public Connection Connection { get; set; }

        public BaseRepository(string tableName)
        {
            TableName = $"[{tableName}]";
            Connection = new Connection(CONNECTION_STRING);
        }
        public bool Delete(TKey id)
        {
            Command command = new Command($"DELETE * FROM {TableName} WHERE Id = @Id");
            command.AddParameter("Id", id);
            return Connection.ExecuteNonQuery(command) == 1;
        }

        public TEntities Get(TKey id)
        {
            Command command = new Command($"SELECT * FROM {TableName} WHERE Id = @Id");
            command.AddParameter("Id", id);
            return Connection.ExecuteReader(command, Convert).SingleOrDefault();
        }

        public IEnumerable<TEntities> GetAll()
        {
            Command command = new Command($"SELECT * FROM {TableName}");
            return Connection.ExecuteReader(command, Convert);
        }

        public abstract TEntities Convert(IDataRecord dataRecord);

        public abstract TKey Insert(TEntities entity);

        public abstract bool Update(TEntities entity);
        
    }
}
