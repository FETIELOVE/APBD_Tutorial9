namespace PrescriptionApp.DTOs;

public class NewPrescriptionDtos
{
    public required PatientDto Patient { get; set; }
    public required List<MedicamentDto> Medicaments { get; set; } = new List<MedicamentDto>();
    
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}
