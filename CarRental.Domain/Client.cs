using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime DOB { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nationality { get; set; }

    [Required]
    public DateTime RentalStartDate { get; set; }

    [Required]
    public DateTime RentalEndDate { get; set; }

    [ForeignKey("Car")]
    public int CarId { get; set; }

    public Car Car { get; set; }
}
