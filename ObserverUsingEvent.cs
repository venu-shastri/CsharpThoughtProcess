  public class Window
    {
        Button _clearButton = new Button();
        TextBox _searchTextBox = new TextBox();

        public Window()
        {
            Action _command = new Action(ClearButton_Click);
            //_clearButton.AddObserver(_command);
            _clearButton.Click += _command;
        }


        public void Show()
        {
            Console.WriteLine("Window Painted");
        }

        private void ClearButton_Click()
        {
            _searchTextBox.Clear();
        }
        public void ButtonClickSimulation()
        {
            _clearButton.OnClick();
        }


    }
    public class Button
    {
        //Encapsulate Delegate Instance to enable Event Driven or class as a observable...(Observer)
        //Hook Methods
        //public event property
      public event  Action Click;
        //private Action Click;
        public void OnClick()
        {
            Console.WriteLine("Button clicked");
            this.NotifyObserver();
        }

      
        private void NotifyObserver()
        {
            if (Click != null)
            {

                Click.Invoke();
            }

        }

    }
    public class TextBox
    {
        public void Clear()
        {
            Console.WriteLine("TextBox Content Cleared");
        }
    }
    internal class Observer
    {

       static void _Main()
        {
            Window _window = new Window();
            _window.Show();
            while (true)
            {
                //user click
                _window.ButtonClickSimulation();
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
