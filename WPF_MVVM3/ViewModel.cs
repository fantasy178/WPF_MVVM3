using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM3;

namespace WPF_MVVM3
{
    class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> cars;
        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set
            {
                if(this.cars != value)
                {
                    this.cars = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand ButtonCmd { get; set; }

        public ViewModel()
        {
            ButtonCmd = new RelayCommand(OnButtonCmdExecuted, () => { return true; });
            cars = new ObservableCollection<Car>()
            {
                new Car() { Name = "A", WheelNo = 4 },
                new Car() { Name = "B", WheelNo = 2 },
            };            
        }

        private void OnButtonCmdExecuted(object o)
        {
            MessageBox.Show(o.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
