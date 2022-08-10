using System.ComponentModel.DataAnnotations;

namespace PatientCRUDServiceApi.Models
{
    public class PatientDataModel
    {
        [Key]
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
    }
}
