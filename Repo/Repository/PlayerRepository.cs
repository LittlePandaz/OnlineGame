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
    public class PlayerRepository : BaseRepository<int, Player>
    {
        public PlayerRepository():base("Player")
        {

        }
        public override Player Convert(IDataRecord dataRecord)
        {
            return new Player()
            {
                Id = (int)dataRecord["Id"],
                Nickname = dataRecord["Nickname"].ToString(),
                Email = dataRecord["Email"].ToString(),
                Password = dataRecord["Password"].ToString()
            };
        }

        public override int Insert(Player entity)
        {
            Command command = new Command($"INSERT INTO {TableName} (Nickname, Email, Password) OUTPUT INSERTED.Id VALUES(@Nickname, @Email, @Password)");
            command.AddParameter("Nickname", entity.Nickname);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            return (int)Connection.ExecuteScalar(command);
        }

        public override bool Update(Player entity)
        {
            Command command = new Command($"UPDATE {TableName} SET Nickname = @Nickname, Email = @Email, Password = @Password WHERE Id = @Id");
            command.AddParameter("Nickname", entity.Nickname);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            command.AddParameter("Id", entity.Id);
            return Connection.ExecuteNonQuery(command) == 1;
        }
    }
}
