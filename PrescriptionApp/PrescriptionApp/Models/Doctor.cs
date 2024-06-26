﻿using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models;

public class Doctor
{
    [Key] public int IdDoctor { get; set; }

    [MaxLength(100)] [Required] public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)] [Required] public string LastName { get; set; } = string.Empty;
    [MaxLength(100)] [Required] public string Email { get; set; } = string.Empty;

    public ICollection<Prescription> Prescriptions { get; set; }

}
