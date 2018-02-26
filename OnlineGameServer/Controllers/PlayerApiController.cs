using OnlineGameServer.Models;
using Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OnlineGameServer.Utils;
using Repo.Entities;

namespace OnlineGameServer.Controllers
{
    public class PlayerApiController: ApiController
    {
        
        public IEnumerable<PlayerModel> GET()
        {
           return PlayerRepository.Instance.GetAll().Select(x=>x.ToClient<PlayerModel,Player>());
        }

        public PlayerModel GET(int id)
        {
            return PlayerRepository.Instance.Get(id).ToClient<PlayerModel, Player>();
        }

        public int POST([FromBody] PlayerModel player)
        {
            return PlayerRepository.Instance.Insert(player.ToGlobal<PlayerModel, Player>());
        }
        public bool DELETE(int id)
        {
            return PlayerRepository.Instance.Delete(id);
        }
        public bool UPDATE([FromBody] PlayerModel player)
        {
            return PlayerRepository.Instance.Update(player.ToGlobal<PlayerModel, Player>());
        }

    }
}