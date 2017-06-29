using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RxSample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ReactiveProperty<Customer> CustomerInfo { get; } = new ReactiveProperty<Customer>(new Customer());

        public ReactiveCommand AlertCommand { get; }

        public MainWindowViewModel()
        {
            this.AlertCommand = this.CustomerInfo
                .Value
                .HasErrors
                .Inverse()
                .ToReactiveCommand();
            this.AlertCommand.Subscribe(this.AlertExecute);
        }

        private void AlertExecute()
        {
            MessageBox.Show($"{this.CustomerInfo.Value.CustomerName.Value}, {this.CustomerInfo.Value.Memo.Value}");
        }
    }
}
