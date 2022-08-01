 public delegate bool AnyArgType_ReturnBoolCommandClass<TSource>(TSource item);
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Royal", "Siemens", "Cerner" };
            
            //Select name from  names where name ends with "s";
            AnyArgType_ReturnBoolCommandClass<string> _functionCommandObj = new AnyArgType_ReturnBoolCommandClass<string>(Program.Endswith_s_Predicate);
            IEnumerable<string> resultList= Search<string>(names,_functionCommandObj);
            //display
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }
            _functionCommandObj = new AnyArgType_ReturnBoolCommandClass<string>(Program.Starswith_S_Predicate);
            resultList = Search<string>(names, _functionCommandObj);
            //display
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }

            int[] numbers = { 1, 2, 3, 4, 5, 8 };
            AnyArgType_ReturnBoolCommandClass<int> _intArgBoolReturnCommandObj = new AnyArgType_ReturnBoolCommandClass<int>(Program.IsEven);
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
        static bool Endswith_s_Predicate(string item)
        {
            return item.EndsWith("s");
        }
        static bool Endswith_r_Predicate(string item)
        {
            return item.EndsWith("r");
        }
        static bool Starswith_P_Predicate(string item)
        {
            return item.StartsWith("P");
        }
        static bool Starswith_S_Predicate(string item)
        {
            return item.StartsWith("S");
        }

        static IEnumerable<Tsource> Search<Tsource>(IEnumerable<Tsource> source, AnyArgType_ReturnBoolCommandClass<Tsource> predicate)
        {
            List<Tsource> resultList = new List<Tsource>();
            //Select name from  names where name ends with "s";

           //IEnumerator<Tsource> iterator= source.GetEnumerator();
           // try
           // {
           //     while (iterator.MoveNext())
           //     {
           //         Tsource currentItem=iterator.Current;
           //         if (predicate(currentItem))
           //         {
           //             resultList.Add(currentItem);
           //         }
           //     }
           // }
           // finally
           // {
           //     if(iterator is IDisposable)
           //     {
           //         iterator.Dispose();
           //     }
           // }
            
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
