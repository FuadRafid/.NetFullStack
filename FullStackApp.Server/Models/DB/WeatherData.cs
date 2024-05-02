using System.ComponentModel.DataAnnotations;

public class WeatherData
{
    [Key]
    public virtual int Id { get; set; }
    public virtual String Status { get; set; }
    public virtual byte DangerLevel { get; set; }
}