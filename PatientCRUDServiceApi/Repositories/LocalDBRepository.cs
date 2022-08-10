using Microsoft.EntityFrameworkCore;
using PatientCRUDServiceApi.Models;

namespace PatientCRUDServiceApi.Repositories
{
    public class LocalDBRepository : IPatientDataRepository
    {
        DBContexts.PatientDBContext _pdbc;
        public LocalDBRepository(DBContexts.PatientDBContext pdbc)
        {
            this._pdbc = pdbc;
        }
        public string AddNewPatient(Models.PatientDataModel model)
        {

            this._pdbc.Patients.Add(model);
            this._pdbc.SaveChanges();
            return model.PatientId;
        }

        public Task<string> AddNewPatientAsync(PatientDataModel model)
        {
            return Task.Run<string>(() => { return this.AddNewPatient(model); });
        }

        public IEnumerable<Models.PatientDataModel> GetAllPatients()
        {
            return this._pdbc.Patients;
        }
        public  Task<List<Models.PatientDataModel>> GetAllPatientsAsync()
        {
            return this._pdbc.Patients.ToListAsync();
        }
    }
}
