using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSchool.Models;

namespace MvcSchool.Data
{
    public class MvcSchoolContext : DbContext
    {
        public MvcSchoolContext (DbContextOptions<MvcSchoolContext> options)
            : base(options)
        {
        }

        public DbSet<MvcSchool.Models.Lesson> Lesson { get; set; } = default!;
    }
}
