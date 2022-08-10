namespace PatientCRUDServiceApi.Repositories
{
    public interface IPatientDataRepository
    {
        string AddNewPatient(Models.PatientDataModel model);



         IEnumerable<Models.PatientDataModel> GetAllPatients();
        
    }
}
