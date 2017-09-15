using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INotifyPropertyChanged_Style2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Constructor
        public MainWindowViewModel()
        {
            this.Name = "Initial Name";
            InitializeCommands();
        }

        
        #endregion

        #region Properties
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        #endregion

        #region ICommand
        public ICommand Click { get; set; }
        private void InitializeCommands()
        {
            Click = new CustomCommand(OnClick, CanClick);
        }

        private bool CanClick(object obj)
        {
            return true;
        }

        private void OnClick(object obj)
        {
            Name = "New Name " + new Random().Next(1, 100);
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
