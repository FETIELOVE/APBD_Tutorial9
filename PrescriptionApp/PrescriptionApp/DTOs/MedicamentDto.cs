

namespace PrescriptionApp.DTOs;

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}