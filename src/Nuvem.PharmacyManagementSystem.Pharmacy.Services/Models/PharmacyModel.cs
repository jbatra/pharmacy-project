
using System.ComponentModel.DataAnnotations;

public class PharmacyModel
{
    
    public int PharmacyId { get; set; }    

    [Required, MaxLength(150),MinLength(5)]
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    
    [RegularExpression("^([0-9]{5})$")]
    public string? Zip { get; set; }
    public int? FilledPrescriptionMtd { get; set; }   
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}