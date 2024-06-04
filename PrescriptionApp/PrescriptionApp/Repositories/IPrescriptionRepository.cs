
using PrescriptionApp.DTOs;
using PrescriptionApp.Models;

namespace PrescriptionApp.Repositories;

public interface IPrescriptionRepository
{
    Task<Patient> GetPatientByIdAsync(int id);
    Task AddPatientAsync(Patient patient);
    Task<Medicament> GetMedicamentByIdAsync(int id);
    
    Task AddPrescriptionAsync(NewPrescriptionDtos request);

}
    
   
    

