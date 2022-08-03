using System.Dynamic;
    public class CSVLine:DynamicObject
    {
        public string Line { get; set; }
        public string Header { get; set; }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            string propertyName = binder.Name;
            List<string> headerList = Header.Split(',').ToList();
            int position=headerList.IndexOf(propertyName);
            if (position >= 0)
            {
                List<string> columnList = Line.Split(',').ToList();
                result = columnList[position];

                return true;
            }
            return false;
            
        }

     public string Dump()
        {

            return Line;
        }
    }
    
    public class DynamicCSVProvider
    {
        public string FilePath { get; set; }
        public IEnumerable<CSVLine> GetAllLines()
        {
            List<CSVLine> lines = new List<CSVLine>();
            System.IO.StreamReader _reader = new System.IO.StreamReader(FilePath);
            string header=_reader.ReadLine();
            while (!_reader.EndOfStream)
            {
                
                CSVLine line = new CSVLine() { Header = header,Line=_reader.ReadLine() };
                lines.Add(line);

            }

            return lines;
        }
    }

    public class Client
    {
        public static void Main()
        {
            DynamicCSVProvider provider =new DynamicCSVProvider();
            provider.FilePath = "..//..//patients.csv";
            IEnumerable<CSVLine> patients = provider.GetAllLines();

         IEnumerable<dynamic> result=   patients.Where( (dynamic p) => Int32.Parse( p.AGE) > 35);
           foreach(dynamic patient in result)
            {
                Console.WriteLine(patient.Dump()); // M400,JAMES,35,12356,james@tom.com
                                            //M500,JACOB,38,12346,jacob @tom.com
            }
        }
    }
