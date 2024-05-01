﻿using System.ComponentModel.DataAnnotations;

namespace PotsAndPlans.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}