namespace CodeDemoCore
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Royal", "Siemens", "Cerner" };

            //Select name from  names where name ends with "s";
            Func<string, bool> _functionCommandObj = Program.Endswith_Any_Predicate_Generator("s");
            IEnumerable<string> resultList= Search<string>(names,_functionCommandObj);
            //display
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }
            _functionCommandObj = Program.Endswith_Any_Predicate_Generator("r");
            resultList = Search<string>(names, _functionCommandObj);
            //display
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }



            int[] numbers = { 1, 2, 3, 4, 5, 8 };
           Func<int,bool>  _intArgBoolReturnCommandObj = new Func<int, bool>(Program.IsEven);
            IEnumerable<int> intResultList = Search<int>(numbers, _intArgBoolReturnCommandObj);

            foreach (int  item in intResultList)
            {
                Console.WriteLine(item);
            }

        }

        static bool IsEven(int item)
        {
            return item % 2 == 0;
        }
        //outer function
        static Func<string, bool> Endswith_Any_Predicate_Generator(string endsWith)
        {
            //Lamda
           Func<string, bool> predicate= (string item) =>
            {
                //inner function body
                return item.EndsWith(endsWith);
            };
            return predicate;
        }
       
        static Func<string,bool> Starswith_Any_Predicate(string startsWith)
        {
          
            //local functions
            bool StartsWithPredicate(string item)
            {
                return item.StartsWith(startsWith);
            }
            return new Func<string, bool> ( StartsWithPredicate);
           
        }
      

        static IEnumerable<Tsource> Search<Tsource>(IEnumerable<Tsource> source, Func<Tsource,bool> predicate)
        {
            List<Tsource> resultList = new List<Tsource>();
            
            foreach (Tsource item in source)
            {
                if(predicate.Invoke(item))
                {
                    resultList.Add(item);

                }
            }
            return resultList;

        }
    }
}
