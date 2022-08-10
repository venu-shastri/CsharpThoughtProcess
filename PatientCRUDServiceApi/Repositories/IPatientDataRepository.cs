namespace PatientCRUDServiceApi.Repositories
{
    public interface IPatientDataRepository
    {
        string AddNewPatient(Models.PatientDataModel model);
        Task<string> AddNewPatientAsync(Models.PatientDataModel model);


         IEnumerable<Models.PatientDataModel> GetAllPatients();
        Task<List<Models.PatientDataModel>> GetAllPatientsAsync();


    }
}
