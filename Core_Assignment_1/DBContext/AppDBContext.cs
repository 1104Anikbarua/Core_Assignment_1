using Core_Assignment_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Assignment_1.DBContext
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }

        DbSet<RegistrationClass> Registrations {  get; set; }
    }
}
