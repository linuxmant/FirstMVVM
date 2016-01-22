using FirstMVVM.ViewModels;
using System.Windows.Input;
using System;

namespace FirstMVVM.Commands {


	internal class CustomerUpdateCommand : ICommand {

		private CustomerViewModel viewModel;

		public CustomerUpdateCommand(CustomerViewModel viewModel) {
			this.viewModel = viewModel;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter) {
			return viewModel.Customer.IsValid;
		}

		public void Execute(object parameter) {
			viewModel.SaveChanges();
		}
	}
}
