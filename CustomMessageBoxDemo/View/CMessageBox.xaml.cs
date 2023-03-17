using CustomMessageBoxDemo.ViewModel;
using Lib.Enums;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace CustomMessageBoxDemo.View
{
    /// <summary>
    /// Interaction logic for CMessageBox.xaml
    /// </summary>
    public partial class CMessageBox : Window
    {
        public CMessageBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ShowDialogCore is a Method that opens a messagebox and fills in the necessary information
        /// </summary>
        /// <param name="message">Message Body</param>
        /// <param name="title">Window Title</param>
        /// <param name="button">Select buttons</param>
        /// <param name="packIcon">Select Icon</param>
        public static MessageBoxResultLib ShowDialogCore(string message,string title,MessageBoxButtonLib button,PackIconKind packIcon)
        {
            CMessageBox cMessage = new CMessageBox();
            CMessageBoxViewModel cMessageViewModel = new CMessageBoxViewModel(message, title, button, packIcon);
            cMessage.DataContext = cMessageViewModel;
            cMessage.ShowDialog();
            return cMessageViewModel.Result;
        }
        /// <summary>
        /// ShowDialogCore is a Method that opens a messagebox and fills in the necessary information
        /// </summary>
        /// <param name="message">Message Body</param>
        /// <param name="title">Window Title</param>
        public static MessageBoxResultLib ShowDialogCore(string message,string title)
        {
            CMessageBox cMessage = new CMessageBox();
            CMessageBoxViewModel cMessageViewModel = new CMessageBoxViewModel(message, title);
            cMessage.DataContext = cMessageViewModel;
            cMessage.ShowDialog();
            return cMessageViewModel.Result;
        }
        /// <summary>
        /// ShowDialogCore is a Method that opens a messagebox and fills in the necessary information
        /// </summary>
        /// <param name="message">Message Body</param>
        /// <param name="title">Window Title</param>
        /// <param name="packIcon">Select Icon</param>
        public static MessageBoxResultLib ShowDialogCore(string message,string title,PackIconKind packIcon)
        {
            CMessageBox cMessage = new CMessageBox();
            CMessageBoxViewModel cMessageViewModel = new CMessageBoxViewModel(message, title, packIcon:packIcon);
            cMessage.DataContext = cMessageViewModel;
            cMessage.ShowDialog();
            return cMessageViewModel.Result;
        }
    }
}