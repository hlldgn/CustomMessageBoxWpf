# CustomMessageBoxWpf

First Step

1-Creating our WPF project.
2-Add the lib dll to our project as a reference.
3-Add the MaterialDesignThemes nuget package https://www.nuget.org/packages/MaterialDesignThemes/ to our project.

--You can create the MessageBox design you want under the View folder.
--When designing, it is mandatory to create a few fields.
--A base model structure was created using the INotifyPropertyChanged interface. These are as shown in the table below and in the image.

![table](https://user-images.githubusercontent.com/100942011/225893771-704c64f6-9450-4365-89da-7eb63141f0de.jpg)

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

![BindingCustomMessageBox](https://user-images.githubusercontent.com/100942011/225893820-c2865f6f-8e9e-4628-9173-90700e990bcb.jpg)


Step 2

ViewModel

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


BoolenConverter

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bValue = false;
            if (value is bool)
            {
                bValue = (bool)value;
            }
            else if (value is Nullable<bool>)
            {
                Nullable<bool> tmp = (Nullable<bool>)value;
                bValue = tmp.HasValue ? tmp.Value : false;
            }
            return (bValue) ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                return (Visibility)value == Visibility.Visible;
            }
            else
            {
                return false;
            }
        }
    }



MessageBox.cs


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


How to Use

        private void btnMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResultLib result=CMessageBox.ShowDialogCore("Hello World",
                "World",PackIconKind.QuestionAnswer);
            if (result==MessageBoxResultLib.OK)
            {
                //result is OK
            }
        }
