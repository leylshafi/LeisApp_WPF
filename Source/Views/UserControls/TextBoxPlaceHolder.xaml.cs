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

namespace Source.Views.UserControls
{
    public partial class TextBoxPlaceHolder : UserControl
    {
        public TextBoxPlaceHolder()
        {
            InitializeComponent();
        }
        public string PlaceHolderText
        {
            get { return (string)GetValue(PlaceHolderTextProperty); }
            set { SetValue(PlaceHolderTextProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.Register("PlaceHolderText", typeof(string), typeof(TextBoxPlaceHolder));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxPlaceHolder));





        public bool AcceptsReturn
        {
            get { return (bool)GetValue(AcceptsReturnProperty); }
            set { SetValue(AcceptsReturnProperty, value); }
        }

        public static readonly DependencyProperty AcceptsReturnProperty =
            DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(TextBoxPlaceHolder));



        public event TextChangedEventHandler? TextChangedUC;

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangedUC?.Invoke(this, e);
        }
    }
}
