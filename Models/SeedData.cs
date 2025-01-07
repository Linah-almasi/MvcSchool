using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcSchool.Data;
using System;
using System.Linq;

namespace MvcSchool.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcSchoolContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcSchoolContext>>()))
        {
            // Look for any movies.
            IList < Lesson > lessons = context.Lesson.ToList();
            if (context.Lesson.Any())
            {
                return;   // DB has been seeded
            }
            context.Lesson.AddRange(
                new Lesson
                {
                    Subject = "ENGLISH",
                    Time = DateTime.Parse("13:00"),
                    Location = "Auditorium",
                    Price = 7.99M
                },
                new Lesson
                {
                    Subject = "FRENCH",
                    Time = DateTime.Parse("11:00"),
                    Location = "Theater",
                    Price = 7.99M
                   
                },
                new Lesson
                {
                    Subject = "GERMAN",
                    Time = DateTime.Parse("12:00"),
                    Location = "Main hall",
                    Price = 7.99M
                },
                new Lesson
                {
                    Subject = "Latino",
                    Time = DateTime.Parse("08:00"),
                    Location = "Complex center",
                    Price = 7.99M
                }
            );
            context.SaveChanges();
        }
    }
}