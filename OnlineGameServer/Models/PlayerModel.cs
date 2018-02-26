using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineGameServer.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}