﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Entities
{
    public interface IEntities<TKey>
    {
        TKey Id { get; set; }
    }
}
