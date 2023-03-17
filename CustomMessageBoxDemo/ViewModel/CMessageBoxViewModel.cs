using CustomMessageBoxDemo.Command;
using Lib.Concrete;
using Lib.Enums;
using MaterialDesignThemes.Wpf;

namespace CustomMessageBoxDemo.ViewModel
{
    public class CMessageBoxViewModel : CustomMessageBoxViewModel
    {
        public CMessageBoxViewModel(string messageBoxText, string title, MessageBoxButtonLib? button=null,PackIconKind? packIcon=null)
        {
            Message = messageBoxText;
            Title = title;
            DisplayButtons(button??MessageBoxButtonLib.OK);
            DisplayImage(packIcon??PackIconKind.InformationCircle);

            okButtonCommand = new RelayCommand(OKButtonCommand);//Example
        }

        private RelayCommand okButtonCommand;

        public RelayCommand OkButtonCommand
        {
            get { return okButtonCommand; }
        }

        private void OKButtonCommand()
        {
            Result = MessageBoxResultLib.OK;
        }

    }
}
