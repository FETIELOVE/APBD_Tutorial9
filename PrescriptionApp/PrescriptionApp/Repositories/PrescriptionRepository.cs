
using PrescriptionApp.Context;
using PrescriptionApp.DTOs;

using PrescriptionApp.Models;
namespace PrescriptionApp.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly ApbdContext _context;

    public PrescriptionRepository(ApbdContext context)
    {
        _context = context;
    }

    public async Task<Medicament> GetMedicamentByIdAsync(int idMedicament)
    {
        var medicament = await _context.Medicaments.FindAsync(idMedicament);
        if (medicament == null)
        {
            throw new ArgumentException($"Medicament with ID {idMedicament} not found");
        }
        return medicament;
    }

    public async Task<Patient> GetPatientByIdAsync(int idPatient)
    {
        var patient = await _context.Patients.FindAsync(idPatient);
        if (patient == null)
        {
            throw new ArgumentException($"Patient with ID {idPatient} not found");
        }
        return patient;
    }

    public async Task AddPatientAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

        public async Task AddPrescriptionAsync(NewPrescriptionDtos request)
        {
           
            if (request.DueDate < request.Date)
            {
                throw new ArgumentException("DueDate must be greater than or equal to Date");
            }

            
            if (request.Medicaments.Count > 10)
            {
                throw new ArgumentException("A prescription can include a maximum of 10 medications");
            }

           
            foreach (var med in request.Medicaments)
            {
                var existingMedicament = await GetMedicamentByIdAsync(med.IdMedicament);
                if (existingMedicament == null)
                {
                    throw new ArgumentException($"Medicament with ID {med.IdMedicament} does not exist");
                }
            }

            
            var existingPatient = await GetPatientByIdAsync(request.Patient.IdPatient);
            if (existingPatient == null)
            {
            

            var newPatient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    DateOfBirth = request.Patient.DateOfBirth
                };
                await AddPatientAsync(newPatient);
                existingPatient = newPatient; 
            }

            
            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                Patient = existingPatient,
                PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Description 
                }).ToList()
            };

            
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
        }
    }
