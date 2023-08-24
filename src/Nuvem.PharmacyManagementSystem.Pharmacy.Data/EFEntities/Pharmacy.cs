using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.EFEntities;

[Table("Pharmacy")]
public partial class Pharmacy
{
    [Key]
    public int PharmacyId { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(200)]
    public string? City { get; set; }

    [StringLength(200)]
    public string? State { get; set; }

    [StringLength(12)]
    public string? Zip { get; set; }

    [Column("FilledPrescriptionMTD")]
    public int? FilledPrescriptionMtd { get; set; }

    //public bool IsConnStringWorking { get; set;}

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
