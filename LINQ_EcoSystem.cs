using System.Linq;
using CodeDemo.Extesions;
using System.Collections.Generic;
namespace CodeDemo
{
    
    public class PatientInfo
    {
        //constructor
        public PatientInfo(string mrn)
        {
            this.mrn = mrn;
        }
        //Backing Field - Memory
        private string mrn;
        //Public Property
        public string MRN { get { return this.mrn; } }


        //Auto implemented Properties
        public string Name { get; set; }
        public int   Age { get; set; }
        public string ContactNumber { get; set; }

        //Public Field
        public string Email;


    }

    //Projection Model
  public class Mrn_Name_Model
    {
        public string MRN { get; set; }
        public string Name { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {

            List<PatientInfo> patientList = new List<PatientInfo>()
            {
                /* Collection Initializer */
                new PatientInfo("M100"){ /*Object Data Member Initializer*/  Name="Tom1",Age=35, ContactNumber="1234567", Email="tom1@tom.com"},
                new PatientInfo("M200"){ /*Object Initializer*/  Name="Tom2",Age=45, ContactNumber="15234567", Email="tom2@tom.com"},
                new PatientInfo("M300"){ /*Object Initializer*/  Name="Tom3",Age=55, ContactNumber="17234567", Email="tom3@tom.com"},
                new PatientInfo("M400"){ /*Object Initializer*/  Name="Tom4",Age=65, ContactNumber="12384567", Email="tom4@tom.com"}
            };

            //Projection Query
            //Select Patient Name and MRN where Age > 50

           IEnumerable<Mrn_Name_Model> result= patientList
     /*Fluent Interface Pattern (Method Chaining) */ .Where((PatientInfo patient) => { return patient.Age > 50; })
                                                     .Select((PatientInfo filteredPatient) => {
                                                         return new Mrn_Name_Model { MRN = filteredPatient.MRN, Name = filteredPatient.Name }; 
                                                     });
            foreach(Mrn_Name_Model patient in result)
            {
                
            }

            //Projection Query
            //Select Patient MRN, Name and Email where Age > 50
        /* Implicitly Typed Variable */  var newResult =  patientList .Where((PatientInfo patient) => { return patient.Age > 50; })
                                                    .Select((PatientInfo filteredPatient) => {
                                                        /* Anonymous Types */
                                                        return new { MRN = filteredPatient.MRN, Name = filteredPatient.Name, Email=filteredPatient.Email };
                                                    });
            foreach(var patient in newResult)
            {
                System.Console.WriteLine($"{patient.MRN},{patient.Name},{patient.Email}");
            }
           


        }

       
    }
}
