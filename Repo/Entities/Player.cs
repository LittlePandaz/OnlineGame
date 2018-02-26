using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Entities
{
    public class Player : IEntities<int>
    {
        public int Id { get; set; }

    }
}
