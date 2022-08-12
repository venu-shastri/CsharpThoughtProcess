using System.ComponentModel.DataAnnotations;

namespace PatientCRUDServiceApi.Models
{
    public class PatientDataModel
    {
        //public string Id { get; set; }
        //PatientDataModelId{get;set;}
        [Key]
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
    }
}
