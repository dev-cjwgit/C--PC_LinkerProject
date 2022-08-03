using SQLiteComponent;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<HeaderItem>();
            DeleteCommand = new Command(ExecuteMethod, null);
            PCLinkerDB.GetInstance();
            
            var data = PCLinkerDB.GetInstance().GetHeaderList();
            foreach (var item in data)
            {
                var temp = new ObservableCollection<TabContentViewModel>();
                temp.Add(new TabContentViewModel()
                {
                    ContentText = "김치찌개1",
                    ContentIcon = Environment.CurrentDirectory + @"\ICO\computer.ico"
                });
                temp.Add(new TabContentViewModel()
                {
                    ContentText = "김치찌개2",
                    ContentIcon = Environment.CurrentDirectory + @"\ICO\computer.ico"
                });

                Tabs.Add(new HeaderItem()
                {
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + item.IconPath ,
                    HeaderText = item.Title,
                    Content = temp
                });
            }
        }

        private void ExecuteMethod(object obj)
        {
            Console.WriteLine("");
            throw new NotImplementedException();
        }

        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<HeaderItem> Tabs { get; set; }
    }
    public class Command : ICommand
    {
        Action<object> _executeMethod;
        Func<object, bool> _canexecuteMethod;
        public event EventHandler CanExecuteChanged;
        public Command(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canexecuteMethod = canexecuteMethod;
        }


        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
            throw new NotImplementedException();
        }
    }
}
