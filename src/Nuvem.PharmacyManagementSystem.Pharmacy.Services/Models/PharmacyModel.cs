using System.ComponentModel.DataAnnotations;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Services.Models;
public class PharmacyModel
{    
    public int PharmacyId { get; set; }    

    [Required, MaxLength(150),MinLength(5)]
    public string Name { get; set; } = null!;
    [MaxLength(150),MinLength(5)]
    public string? Address { get; set; }
    [MaxLength(150),MinLength(3)]
    public string? City { get; set; }
    [MaxLength(150),MinLength(3)]
    public string? State { get; set; }
    
    [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$")]
    public string? Zip { get; set; }
    public int? FilledPrescriptionMtd { get; set; }   
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}