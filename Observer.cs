 public class Window
    {
        Button _clearButton = new Button();
        TextBox _searchTextBox = new TextBox();
        public void Show()
        {
            Console.WriteLine("Window Painted");
        }
        public void ButtonClickSimulation()
        {
            _clearButton.OnClick();
        }

    }
    public class Button
    {
        public void OnClick()
        {
            Console.WriteLine("Button clicked");
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

       static void Main()
        {
            Window _window = new Window();
            _window.Show();
            while (true)
            {
                _window.ButtonClickSimulation();
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
