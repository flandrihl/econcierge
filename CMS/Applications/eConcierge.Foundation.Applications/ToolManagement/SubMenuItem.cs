namespace eConcierge.Foundation.Applications.ToolManagement
{
    public class SubMenuItem : ANotifyPropertyChanged
    {
        private string _header;
        private string _name;
        private bool _isSelected;

        public SubMenuItem()
        {
            IsEnabled = true;
        }
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
                OnPropertyChanged("CanSelect");
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("CanSelect");
            }
        }
        public bool CanSelect
        {
            get
            {
                return !IsSelected && IsEnabled;
            }
        }

        public void Activate()
        {
            
        }
    }
}
