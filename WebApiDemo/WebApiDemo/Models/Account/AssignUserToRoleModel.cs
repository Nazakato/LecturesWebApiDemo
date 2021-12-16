﻿using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models.Account
{
    public class AssignUserToRoleModel
    {
        [Required]
        public string Email { get; set; }
        [Required, MinLength(1)]
        public string[] Roles { get; set; }
    }
}
