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
        
        public IEnumerable<PlayerModel> Get()
        {
           return PlayerRepository.Instance.GetAll().Select(x=>x.ToClient<PlayerModel,Player>());
        }

        public PlayerModel Get(int id)
        {
            return PlayerRepository.Instance.Get(id).ToClient<PlayerModel, Player>();
        }

        public int Post([FromBody] PlayerModel player)
        {
            return PlayerRepository.Instance.Insert(player.ToGlobal<PlayerModel, Player>());
        }
        public bool Delete(int id)
        {
            return PlayerRepository.Instance.Delete(id);
        }
        public bool Put([FromBody] PlayerModel player)
        {
            return PlayerRepository.Instance.Update(player.ToGlobal<PlayerModel, Player>());
        }

    }
}