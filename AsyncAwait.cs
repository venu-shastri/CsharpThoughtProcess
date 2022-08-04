  internal class ProgramBegin
    {

        static void Main_()
        {
            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
            BreakFastDemo.PrepareBreakfast();
            _watch.Stop();
            Console.WriteLine($"Time taken to prepare breakfast {_watch.Elapsed.TotalSeconds}");
        }

        //Caller
        static void Main()
        {
            Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Strated Executing Main  Method");
            //    DoTask();//Synchronous Call - Blocking Calls
            //Task _asycOperationRef = new Task(DoTask);
            //_asycOperationRef.Start();
            //  ExecuteTasks();
            SearchTask("Break!");
            Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Ended Executing Main  Method");
            Console.ReadLine();
        }
        //Search
        static async void  ExecuteTasks()
        {
            //await Task.Run(DoTask);
            //await Task.Run(NextTask);
            // Task _doTask = Task.Run(DoTask);
            //Task _NextTask = Task.Run(NextTask);
            //await Task.WhenAll(_doTask, _NextTask);
            //await Task.Run(FinalTask);

            await DoTaskAsync();
            await NextTaskAsync();
            await FInalTaskAsync();
            

        }
        static void DoTask() { 
        
         for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Executing DoTask Method");
                System.Threading.Thread.Sleep(1000);
            }
            
        }
        static Task DoTaskAsync()
        {
            return Task.Run(DoTask);
        }
        static void NextTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Executing NextTask Method");
                System.Threading.Thread.Sleep(1000);
            }

        }
        static Task NextTaskAsync()
        {
            return Task.Run(NextTask);
        }
        static void FinalTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Executing FinalTask Method");
                System.Threading.Thread.Sleep(1000);
            }

        }
        static Task FInalTaskAsync()
        {
            return Task.Run(FinalTask);
        }


        static async void SearchTask(string searchKey)
        {
            string response=await SendSarchRequestAsync(searchKey);
            string processedContent=await ProcessNetworkResponseAsync(response);
            await UpdateUiAsync(processedContent);


        }
        static Task<string> SendSarchRequestAsync(string searchKey)
        {
         return   Task.Run<string>(() => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Executing Network Request Method , SearchKey :{searchKey}");
                    System.Threading.Thread.Sleep(1000);
                }
                return "response from httpwebserver";
            });
        }

        static Task<string> ProcessNetworkResponseAsync(string response)
        {
            return Task.Run<string>(() => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Executing Network Response Porcessing  Method : Response: {response}");
                    System.Threading.Thread.Sleep(1000);
                }
                return response.ToUpper();
            });
        }

        static Task UpdateUiAsync(string content)
        {
            return Task.Run(() => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}  Executing Ui Update Method : Content: {content}");
                    System.Threading.Thread.Sleep(1000);
                }
                
            });
        }



    }
