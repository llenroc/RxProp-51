using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxSample
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required")]
        public ReactiveProperty<string> CustomerName { get; }

        [Required(ErrorMessage = "Customer memo is required")]
        public ReactiveProperty<string> Memo { get; }

        public ReadOnlyReactiveProperty<bool> HasErrors { get; }

        public Customer()
        {
            this.CustomerName = new ReactiveProperty<string>("")
                .SetValidateAttribute(() => this.CustomerName);
            this.Memo = new ReactiveProperty<string>("")
                .SetValidateAttribute(() => this.Memo);

            this.HasErrors = new[]
                {
                    this.CustomerName.ObserveHasErrors,
                    this.Memo.ObserveHasErrors,
                }.CombineLatest(x => x.Any(y => y))
                .ToReadOnlyReactiveProperty();
        }
    }
}
