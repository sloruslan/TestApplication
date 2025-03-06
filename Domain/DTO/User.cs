using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string Patronymic { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
