using Lib.Abstract;
using Lib.Enums;
using System.ComponentModel;

namespace Lib.Concrete
{
    public class CustomMessageBoxViewModel : INotifyPropertyChanged, ICustomMessageBoxView
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Private
        private string message;
        private string title;
        private MessageBoxResultLib result;
        private bool buttonOKVisible;
        private bool buttonYesVisible;
        private bool buttonNoVisible;
        private bool buttonCancelVisible;
        private Enum packIcon;
        #endregion

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }


        public MessageBoxResultLib Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged("Result"); }
        }

        public bool ButtonOKVisible
        {
            get { return buttonOKVisible; }
            set { buttonOKVisible = value; OnPropertyChanged("ButtonOKVisible"); }
        }

        public bool ButtonYesVisible
        {
            get { return buttonYesVisible; }
            set { buttonYesVisible = value; OnPropertyChanged("ButtonYesVisible"); }
        }

        public bool ButtonNoVisible
        {
            get { return buttonNoVisible; }
            set { buttonNoVisible = value; OnPropertyChanged("ButtonNoVisible"); }
        }

        public bool ButtonCancelVisible
        {
            get { return buttonCancelVisible; }
            set { buttonCancelVisible = value; OnPropertyChanged("ButtonCancelVisible"); }
        }

        public Enum PackIcon
        {
            get { return packIcon; }
            set { packIcon = value; OnPropertyChanged("PackIcon"); }
        }

        public void DisplayButtons(MessageBoxButtonLib button)
        {
            switch (button)
            {
                case MessageBoxButtonLib.OKCancel:
                    ButtonOKVisible = true;
                    ButtonCancelVisible = true;

                    ButtonYesVisible = false;
                    ButtonNoVisible = false;
                    break;
                case MessageBoxButtonLib.YesNo:
                    ButtonYesVisible = true;
                    buttonNoVisible = true;

                    ButtonOKVisible = false;
                    ButtonCancelVisible = false;
                    break;
                case MessageBoxButtonLib.YesNoCancel:
                    ButtonYesVisible = true;
                    buttonNoVisible = true;
                    ButtonCancelVisible = true;

                    ButtonOKVisible = false;
                    break;
                default:
                    ButtonOKVisible = true;

                    ButtonYesVisible = false;
                    buttonNoVisible = false;
                    ButtonCancelVisible = false;
                    break;
            }
        }

        public void DisplayImage<TEnum>(TEnum packIcon) where TEnum:struct,Enum
        {
            PackIcon = packIcon;
        }
    }
}
