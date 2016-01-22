using FirstMVVM.Commands;
using FirstMVVM.Models;
using System.Windows;
using System.Windows.Input;

namespace FirstMVVM.ViewModels {
	internal class CustomerViewModel {
		private Customer customer;

		public CustomerViewModel() {
			customer = new Customer("biteme");
			UpdateCommand = new CustomerUpdateCommand(this);
		}

		public Customer Customer
		{
			get { return customer; }
		}

		public void SaveChanges() {
			MessageBox.Show(string.Format("Customer {0} saved.", Customer.Name));
		}

		public ICommand UpdateCommand {
			get;
			private set;
		}
	}
}
