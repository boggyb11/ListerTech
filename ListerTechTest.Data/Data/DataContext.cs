using ListerTechTest.Data.CoreModels;
using Microsoft.EntityFrameworkCore;

namespace ListerTechTest.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Spell> Spells { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

    }
}
