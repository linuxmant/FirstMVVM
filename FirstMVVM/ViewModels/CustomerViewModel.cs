using FirstMVVM.Commands;
using FirstMVVM.Models;
using FirstMVVM.Views;
using System.Windows.Input;

namespace FirstMVVM.ViewModels {
	internal class CustomerViewModel {
		private Customer customer;
		private CustomerInfoViewModel childViewModel;


		public CustomerViewModel() {
			customer = new Customer("biteme");
			childViewModel = new CustomerInfoViewModel() { Info = "Instantiated in CustomerViwModel ctor." };
			UpdateCommand = new CustomerUpdateCommand(this);
		}

		public Customer Customer
		{
			get { return customer; }
		}

		public void SaveChanges() {
			CustomerInfoView view = new CustomerInfoView();
			view.DataContext = childViewModel;

			//childViewModel.Info = Customer.Name + " was updated on the database.";

			view.Show();
		}

		public ICommand UpdateCommand {
			get;
			private set;
		}
	}
}
