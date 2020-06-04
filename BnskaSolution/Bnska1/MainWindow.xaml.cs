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
using Microsoft.Win32;
using System.IO;

namespace Bnska1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        void OpenFilePathDialog(TextBox textbox)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы из БНСки (*.csv)|*.csv",
                FileName = textbox.Text,
            };
            if (dialog.ShowDialog() == true)
            {
                textbox.Text = dialog.FileName;
            }
        }
        private void ButtonPathCSV1_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePathDialog(textPathCSV1);
        }
        private void ButtonPathCSV2_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePathDialog(textPathCSV2);
        }
        private void ButtonPathCSV3_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePathDialog(textPathCSV3);
        }
        private void ButtonPathCSV4_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePathDialog(textPathCSV4);
        }
        private void ButtonPathCSV5_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePathDialog(textPathCSV5);
        }
        private void ButtonPathCSV6_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePathDialog(textPathCSV6);
        }
        private void ButtonConvert1_Click(object sender, RoutedEventArgs e)
        {
            string pathcsv = textPathCSV1.Text;
            string pathxslx = textPathXSLX1.Text;
            if (string.IsNullOrEmpty(pathcsv))
            {
                MessageBox.Show("Введите путь к csv-файлу из БНСки!","Внимательней!");
                return;
            }
            if (string.IsNullOrEmpty(pathxslx))
            {
                MessageBox.Show("Введите путь к xslx-файлу графика Майорова!", "Внимательней!");
                return;
            }
            if (!File.Exists(pathcsv))
            {
                MessageBox.Show($"Не существует csv-файла БНСки {pathcsv}","Ошибка");
                return;
            }
            try
            {
                Converter.ConvertCSVToXLSX(pathcsv, pathxslx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно произвести экспорт данных в файл Excel\n" + ex.Message, "Ошибка");
                return;
            }
            MessageBox.Show("Экспорт данных в файл Excel завершен успешно.", "Порядок");
        }
        private void ButtonPathXSLX1_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Файлы Mictosoft Excel (*.xslx)|*.xlsx",
                FileName = textPathXSLX1.Text,
            };
            if (dialog.ShowDialog() == true)
            {
                textPathXSLX1.Text = dialog.FileName;
            }
        }
    }
}
