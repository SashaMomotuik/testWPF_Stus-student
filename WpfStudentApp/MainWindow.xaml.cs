using Microsoft.Win32;
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
using System.Configuration;
using System.Drawing;
using System.IO;

namespace WpfStudentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathTmp = "";
        public MainWindow()
        {
            InitializeComponent();

           // imageShow.Source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["defImage"].ToString()));

        }

        private void btnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
           if ( of.ShowDialog() == true)
            {

                imageShow.Source = new BitmapImage(new Uri(of.FileName));

                btnAdd.IsEnabled = true;

            }

           if(txtName.Text.Length!=0)
            {
                imageShow.IsEnabled = true;
            }



        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtName.Text.Length > 5)
            {
                btnOpenImage.IsEnabled = true;
            }
            else
            {
                btnOpenImage.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imageShow.Source.ToString());
            MessageBox.Show(imageName);
            Bitmap r = new Bitmap(imageShow.Source.ToString().Trim(@"file:///".ToCharArray()));
            r.SetResolution(150, 150);
            r.Save(ConfigurationManager.AppSettings["FolderImage150"].ToString() + imageName);

            r.SetResolution(32  , 32);
            r.Save(ConfigurationManager.AppSettings["FolderImage32"].ToString() + imageName);


        }
    }
}
