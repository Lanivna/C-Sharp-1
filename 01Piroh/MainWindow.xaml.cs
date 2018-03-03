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
using FontAwesome.WPF;

namespace _01Piroh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(UpdateResult, ShowLoader);
        }

        private void UpdateResult()
        {
            ((MainWindowViewModel) DataContext).Age = "Your age is " + ((MainWindowViewModel) DataContext).Age;

            ((MainWindowViewModel) DataContext).Western =
                "Your Western sign is " + ((MainWindowViewModel) DataContext).Western;

            ((MainWindowViewModel) DataContext).Chinese =
                "Your Chinese sign is " + ((MainWindowViewModel) DataContext).Chinese;
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }

    }
}
