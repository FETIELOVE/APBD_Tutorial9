using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models;

public class PrescriptionMedicament
{
    
    public int IdMedicament { get; set; }
    public Medicament? Medicament { get; set; }
    public int IdPrescription { get; set; }
    public Prescription Prescription { get; set; }
    [Required]
    public int Dose  { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Details { get; set; }
    
    public PrescriptionMedicament()
    {
        Prescription = new Prescription(); 
    }
}
    
   
    
    
