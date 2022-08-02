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
        public int Age { get; set; }
        public string ContactNumber { get; set; }

        //Public Field
        public string Email;


    }
    public class PatientCSVProvider
    {
        public List<PatientInfo> GetAllPatients()
        {
            throw new NotImplementedException();
        }
    }

    public class Client
    {
        public void Query()
        {
            PatientCSVProvider provider=new PatientCSVProvider();
            provider.FilePath = "....csv";
           IEnumerable<PatientInfo> patients= provider.GetAllPatients();
         IEnumerable<PatientInfo> result=   patients.Where(p => p.Age > 30);
           foreach(PatientInfo patient in result)
            {
                Console.WriteLine(patient.Dump()); // M400,JAMES,35,12356,james@tom.com
                                            //M500,JACOB,38,12346,jacob @tom.com
            }
        }
    }
