using Microsoft.EntityFrameworkCore;

namespace PatientCRUDServiceApi.DBContexts
{
    public class PatientDBContext:DbContext
    {
        public PatientDBContext(DbContextOptions options):base(options) { }

        public DbSet<Models.PatientDataModel> Patients { get; set; }
        
    }
}
