using System;
using System.ComponentModel;

namespace eConcierge.CMSClient.Code
{
    [Serializable]
    public abstract class ANotifyPropertyChanged : INotifyPropertyChanged
    {
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}