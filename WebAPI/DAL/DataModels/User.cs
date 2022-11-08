﻿namespace Domain.DAL
{
    public class User
    { 
        public int Id { get; set; }
        public string? Name { get; private set; }
        public string? Phone { get; private set; }
        public Role Role { get; private set; }
    }
}