using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models;

public class Patient
{
    [Key] public int IdPatient { get; set; }
    [MaxLength(100)] [Required] public string? FirstName { get; set; }
    [MaxLength(100)] [Required] public string? LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    // Initialize the Prescriptions collection
}





    
    
    
