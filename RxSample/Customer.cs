using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxSample
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required")]
        public ReactiveProperty<string> CustomerName { get; }

        public Customer()
        {
            this.CustomerName = new ReactiveProperty<string>("")
                .SetValidateAttribute(() => this.CustomerName);
        }
    }
}
