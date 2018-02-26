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
        public void Pub(PlayerModel player)
        {
            Clients.All.Test(player.Nickname);
        }
    }
}