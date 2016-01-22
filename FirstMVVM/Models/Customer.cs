using System.ComponentModel;

namespace FirstMVVM.Models {
	class Customer : INotifyPropertyChanged, IDataErrorInfo {

		private string name;
		public string Name
		{
			get { return name; }
			set {
				name = value;
				OnPropertyChanged("Name");
			}
		}

		public Customer(string customerName) {
			name = customerName;
		}

		#region  INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName) {
			PropertyChangedEventHandler handler = PropertyChanged;

			if(handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		#region IDataErrorInfo Members

		string IDataErrorInfo.Error
		{
			get { return null; }
		}

		string IDataErrorInfo.this[string propertyName]
		{
			get { return GetValidationError(propertyName); }
		}

		#endregion

		#region Validation

		public bool IsValid {
			get {
				foreach(string property in ValidateProperties) {
					if (GetValidationError(property) != null) {
						return false;
					}
				}
				return true;
			}
		}

		static readonly string[] ValidateProperties = {
			"Name"
		};

		string GetValidationError(string propertyName) {
			string error = null;

			switch (propertyName) {
				case "Name":
					error = ValidateCustomerName();
					break;
			}

			return error;
		}

		private string ValidateCustomerName() {
			if (string.IsNullOrWhiteSpace(Name)) {
				return "Name cannot be null or empty";
			}
			return null;
		}

		#endregion
	}
}
