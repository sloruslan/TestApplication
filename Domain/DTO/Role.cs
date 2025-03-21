﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Role
    {
        public long Id { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
