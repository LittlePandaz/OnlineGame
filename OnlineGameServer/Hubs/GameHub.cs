using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using OnlineGameServer.Models;

namespace OnlineGameServer.Hubs
{
    public class GameHub : Hub
    {

        private static readonly List<PlayerModel> Players = new List<PlayerModel> { };
        public void Enter(PlayerModel player)
        {

            Players.Add(player);
            Clients.All.Test(Players);
            
        }
    }
}