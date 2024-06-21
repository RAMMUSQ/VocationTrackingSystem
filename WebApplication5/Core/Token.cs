﻿namespace Core.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
        public DateTime Expiration { get; set; }
    }
}