using System;
using System.Collections.Generic;

namespace UsersWebApi.Models.Users
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
    }

}
