using CustomMessageBoxDemo.View;
using Lib.Enums;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomMessageBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResultLib result=CMessageBox.ShowDialogCore("Hello World!",
                "Hello",MessageBoxButtonLib.OK, PackIconKind.QuestionAnswer);
            if (result==MessageBoxResultLib.OK)
            {
                //result is OK
            }
        }
    }
}
