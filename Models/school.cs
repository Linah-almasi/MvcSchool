using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSchool.Models;

public class Lesson
{
    internal object? Title;

    public int Id { get; set; }
    public string? Subject { get; set; }

    [Display(Name = "Start Time")]
    [DataType(DataType.Date)]
    public DateTime StartTime { get; set; }
    public string? Location { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public string? Genre { get; internal set; }
}