using Source.Views.Abstract;
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
using System.Windows.Shapes;

namespace Source.Views
{
    /// <summary>
    /// Interaction logic for AddTweetView.xaml
    /// </summary>
    public partial class AddTweetView : Window,IClosable
    {
        public AddTweetView()
        {
            InitializeComponent();
        }
    }
}
