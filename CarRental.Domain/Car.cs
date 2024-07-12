using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string LicensePlate { get; set; }

    [Required]
    [MaxLength(50)]
    public string Model { get; set; }

    [Required]
    [MaxLength(50)]
    public string Manufacturer { get; set; }

    [Required]
    public int Year { get; set; }
}
