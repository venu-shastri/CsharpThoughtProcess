using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientCRUDServiceApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDataController : ControllerBase
    {
        //Dependency
        Repositories.IPatientDataRepository _repositoryRef;

        //Constructor Injection
        public PatientDataController(Repositories.IPatientDataRepository repository)
        {
            this._repositoryRef = repository;
        }

        //Action Methods
        [HttpPost]
        public string Post([FromBody] Models.PatientDataModel model)
        {
            return this._repositoryRef.AddNewPatient(model);
        }

        [HttpGet]
        public IEnumerable<Models.PatientDataModel> Get()
        {
            return this._repositoryRef.GetAllPatients();
        }
    }
}
