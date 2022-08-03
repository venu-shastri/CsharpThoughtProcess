 //Observable
    internal class Subject
    {
        string state;
        // List<Action> Observers = new List<Action>();
        Action Observer;
        public void MutateState()
        {
            Console.WriteLine("State Mutated");
            this.NotifyObserver();
        }

        //Observer Hook Methods
        public void AddObserver(Action observer)
        {
            //this.Observer = observer;
            //  this.Observers.Add(observer);
          //  Observer = System.Delegate.Combine(Observer, observer) as Action;
          this.Observer += observer;

        }
        public void RemoveObserver(Action observer)
        {
            //this.Observers.Remove(observer);
         // Observer=  System.Delegate.RemoveAll(Observer, observer) as Action;
         this.Observer-=observer;

        }
        private void NotifyObserver()
        {
            if (Observer != null)
            {
                //foreach (var observer in Observers)
                //{
                //    observer.Invoke();//Observer();
                //}
                Observer.Invoke(); //Iterate Invocation List and Invoke Delegate targets
            }

        }
    }

    internal class ObserverOne
    {
        public void Update()
        {
            Console.WriteLine($"{nameof(ObserverOne)} Received Subject State Change Notification");
        }
    }
    internal class ObserverTwo
    {
        public void PingMe()
        {
            Console.WriteLine($" {nameof(ObserverTwo)} Received Subject State Change Notification");
        }
    }

    internal class Entrypoint
    {
        static void Main()
        {
            Subject _subject = new Subject();

            ObserverOne _observer = new ObserverOne();
            Action _command = new Action(_observer.Update);

            ObserverTwo _newObserver = new ObserverTwo();
            Action _newCommand = new Action(_newObserver.PingMe);

            _subject.AddObserver(_command);
            _subject.AddObserver(_newCommand);

            while (true)
            {
                _subject.MutateState();
                System.Threading.Thread.Sleep(2000);
            }

        }
    }

    interface IWebDriver {
        void Open();
        void Close();
    }

    class ChromeDriver:IWebDriver {
        public void Open() {
            Console.WriteLine("Chrome Browser Launched");
        }
        public void Close()
        {
            Console.WriteLine("Chrome Browser Closed");
        }
    }
    class IEDriver :IWebDriver{

        public void Open()
        {
            Console.WriteLine("IE Browser Launched");
        }
        public void Close()
        {
            Console.WriteLine("IE Browser Closed");
        }
    }
    class Firefox :IWebDriver{

        public void Open()
        {
            Console.WriteLine("FireFox Browser Launched");
        }
        public void Close()
        {
            Console.WriteLine("Firefox Browser Closed");
        }
    }

    //Composite Design Pattern
    class CompositeWebDriver : IWebDriver
    {
        List<IWebDriver> _listOfDrivers = new List<IWebDriver>();
        public void Close()
        {
            foreach(var driver in _listOfDrivers)
            {
                driver.Close();
            }
        }

        public void Open()
        {
            //Multiplex
            foreach(var driver in _listOfDrivers)
            {
                driver.Open();
            }
        }
        public void AddDriver(IWebDriver _driver)
        {
            this._listOfDrivers.Add(_driver);

        }
        public void RemoveDriver (IWebDriver driver)
        {
            this._listOfDrivers.Remove(driver);
        }
    }
    class AutomationSession
    {
        IWebDriver _targetBrowser;
        public void setTargetBrowser(IWebDriver targetBrowser)
        {
            this._targetBrowser = targetBrowser;

        }

        public void StartAutomation()
        {
            this._targetBrowser.Open();
        }
        public void StopAutomation()
        {
            this._targetBrowser.Close();

        }
        static void Main___()
        {
            AutomationSession _session = new AutomationSession();
            _session.setTargetBrowser(new ChromeDriver());
            _session.StartAutomation();
            _session.StopAutomation();
            _session.setTargetBrowser(new IEDriver());
            _session.StartAutomation();
            _session.StopAutomation();

            CompositeWebDriver _compositeDriver = new CompositeWebDriver();
            _compositeDriver.AddDriver(new ChromeDriver());
            _compositeDriver.AddDriver(new IEDriver());

            _session.setTargetBrowser(/* Multiple Web Drivers*/ _compositeDriver);
            _session.StartAutomation();//Open Multiple Browsers
            _session.StopAutomation();//Close Opened browsers
        }
    }
