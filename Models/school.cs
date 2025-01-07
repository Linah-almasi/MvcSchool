using System.ComponentModel.DataAnnotations;

namespace MvcSchool.Models;

public class Lesson
{
    public int Id { get; set; }
    public string? Subject { get; set; }
    [DataType(DataType.Date)]
    public DateTime Time { get; set; }
    public string? Location { get; set; }
    public decimal Price { get; set; }
}