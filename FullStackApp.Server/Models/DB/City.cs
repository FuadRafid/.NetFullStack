using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class City
{
    [Key]
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Country { get; set; }
    public virtual byte Code { get; set; }
}