using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Customer
{
    [Key]
    public int Id { get; set;} //Propert
    [Required]
    [MaxLength(50), NotNull]
    public string Name { get; set;}
    [Required]
    [MaxLength(100)]
    public string Email { get; set;}
    public double Latitude{ get; set;}
    public double Longitude{ get; set;}




}