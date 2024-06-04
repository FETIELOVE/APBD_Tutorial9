﻿using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models;

public class Prescription
{
    [Key] public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    [Required] public int IdPatient { get; set; }
    public Patient Patient { get; set; }

    public int IdDoctor { get; set; }
    public Doctor Doctor { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

}
