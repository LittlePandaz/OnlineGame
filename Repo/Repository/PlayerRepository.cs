using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository
{
    public class PlayerRepository : BaseRepository<int, Player>
    {
        public PlayerRepository():base("player")
        {

        }
        public override Player Convert(IDataRecord dataRecord)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Player entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}
