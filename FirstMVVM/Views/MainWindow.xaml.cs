using FirstMVVM.ViewModels;
using System.Windows;

namespace FirstMVVM.Views {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			DataContext = new CustomerViewModel();
		}
	}
}
