using PatientCRUDServiceApi.Models;

namespace PatientCRUDServiceApi.Repositories
{
    public class LocalMemoryRepository:IPatientDataRepository
    {
        List<Models.PatientDataModel> _patientList = new()
        {
            new(){ PatientId=Guid.NewGuid().ToString(), Age=30,PatientName="Tom" },
            new(){ PatientId=Guid.NewGuid().ToString(), Age=35,PatientName="Hary" },
            new(){ PatientId=Guid.NewGuid().ToString(), Age=36,PatientName="Jack" }
        };
        public string AddNewPatient(Models.PatientDataModel model)
        {
            this._patientList.Add(model);
            return model.PatientId;
        }

        public Task<string> AddNewPatientAsync(PatientDataModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.PatientDataModel> GetAllPatients()
        {
            return this._patientList;
        }

        public Task<List<PatientDataModel>> GetAllPatientsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
