﻿using System;
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
using System.Xml.Serialization;

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
        private void Window_Closed(object sender, EventArgs e)
        {
            SaveState();
        }


        async private void ConvertAll_Click(object sender, RoutedEventArgs e)
        {
            if (checkPump1.IsChecked == true)
                await RunConvertAsync(buttonConvert1, textPathCSV1.Text, textPathXSLX1.Text);
            if (checkPump2.IsChecked == true)
                await RunConvertAsync(buttonConvert2, textPathCSV2.Text, textPathXSLX2.Text);
            if (checkPump3.IsChecked == true)
                await RunConvertAsync(buttonConvert3, textPathCSV3.Text, textPathXSLX3.Text);
            if (checkPump4.IsChecked == true)
                await RunConvertAsync(buttonConvert4, textPathCSV4.Text, textPathXSLX4.Text);
            if (checkPump5.IsChecked == true)
                await RunConvertAsync(buttonConvert5, textPathCSV5.Text, textPathXSLX5.Text);
            if (checkPump6.IsChecked == true)
                await RunConvertAsync(buttonConvert6, textPathCSV6.Text, textPathXSLX6.Text);
        }
        #region Диалоги открытия путей к файлам CSV

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
        #endregion
        #region Конвертирования из одного формата в другой
        void ConvertFromCSVToXLSX(string pathcsv, string pathxslx)
        {
            if (string.IsNullOrEmpty(pathcsv))
            {
                MessageBox.Show("Введите путь к csv-файлу из БНСки!", "Внимательней!");
                return;
            }
            if (string.IsNullOrEmpty(pathxslx))
            {
                MessageBox.Show("Введите путь к xslx-файлу графика Майорова!", "Внимательней!");
                return;
            }
            if (!File.Exists(pathcsv))
            {
                MessageBox.Show($"Не существует csv-файла БНСки {pathcsv}", "Ошибка");
                return;
            }
            if (!File.Exists(pathxslx))
            {
                MessageBox.Show($"Не существует xlsx-файла графика Майорова {pathxslx}", "Ошибка");
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
        }
        async private Task RunConvertAsync(Button btn, string pathscv, string pathxlsx)
        {
            btn.IsEnabled = false;
            btn.Content = "Выполнение";
            await Task.Run(() => ConvertFromCSVToXLSX(pathscv, pathxlsx));
            btn.IsEnabled = true;
            btn.Content = "->";
        }
        async private void ButtonConvert1_Click(object sender, RoutedEventArgs e)
        {
            await RunConvertAsync((Button)sender, textPathCSV1.Text, textPathXSLX1.Text);
        }
        async private void ButtonConvert2_Click(object sender, RoutedEventArgs e)
        {
            await RunConvertAsync((Button)sender, textPathCSV2.Text, textPathXSLX2.Text);
        }
        async private void ButtonConvert3_Click(object sender, RoutedEventArgs e)
        {
            await RunConvertAsync((Button)sender, textPathCSV3.Text, textPathXSLX3.Text);
        }
        async private void ButtonConvert4_Click(object sender, RoutedEventArgs e)
        {
            await RunConvertAsync((Button)sender, textPathCSV4.Text, textPathXSLX4.Text);
        }
        async private void ButtonConvert5_Click(object sender, RoutedEventArgs e)
        {
            await RunConvertAsync((Button)sender, textPathCSV5.Text, textPathXSLX5.Text);
        }
        async private void ButtonConvert6_Click(object sender, RoutedEventArgs e)
        {
            await RunConvertAsync((Button)sender, textPathCSV6.Text, textPathXSLX6.Text);
        }
        #endregion
        #region Диалоги открытия файлов для записи XLSX
        void SaveFilePathDialog(TextBox textbox)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Файлы Mictosoft Excel (*.xslx)|*.xlsx",
                FileName = textbox.Text,
            };
            if (dialog.ShowDialog() == true)
            {
                textbox.Text = dialog.FileName;
            }
        }
        private void ButtonPathXSLX1_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePathDialog(textPathXSLX1);
        }
        private void ButtonPathXSLX2_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePathDialog(textPathXSLX2);
        }
        private void ButtonPathXSLX3_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePathDialog(textPathXSLX3);
        }
        private void ButtonPathXSLX4_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePathDialog(textPathXSLX4);
        }
        private void ButtonPathXSLX5_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePathDialog(textPathXSLX5);
        }
        private void ButtonPathXSLX6_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePathDialog(textPathXSLX6);
        }
        #endregion
        [Serializable]
        public class SavedStateXML
        {
            public bool checkPump1;
            public bool checkPump2;
            public bool checkPump3;
            public bool checkPump4;
            public bool checkPump5;
            public bool checkPump6;
            public string textPathCSV1;
            [XmlAttribute]
            public string textPathCSV2;
            [XmlAttribute]
            public string textPathCSV3;
            [XmlAttribute]
            public string textPathCSV4;
            [XmlAttribute]
            public string textPathCSV5;
            [XmlAttribute]
            public string textPathCSV6;
            [XmlAttribute]
            public string textPathXSLX1;
            [XmlAttribute]
            public string textPathXSLX2;
            [XmlAttribute]
            public string textPathXSLX3;
            [XmlAttribute]
            public string textPathXSLX4;
            [XmlAttribute]
            public string textPathXSLX5;
            [XmlAttribute]
            public string textPathXSLX6;
        }
        static void SaveStateToXML(SavedStateXML obj, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(SavedStateXML));
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlFormat.Serialize(fs, obj);
            }
        }
        static SavedStateXML LoadFromXMLToState(string filename)
        {
            SavedStateXML state = new SavedStateXML();
            XmlSerializer xmlFormat = new XmlSerializer(typeof(SavedStateXML));
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                state = xmlFormat.Deserialize(fs) as SavedStateXML;
            }
            return state;
        }
        private void SaveState()
        {
            SavedStateXML state = new SavedStateXML
            {
                checkPump1 = checkPump1.IsChecked ?? false,
                checkPump2 = checkPump2.IsChecked ?? false,
                checkPump3 = checkPump3.IsChecked ?? false,
                checkPump4 = checkPump4.IsChecked ?? false,
                checkPump5 = checkPump5.IsChecked ?? false,
                checkPump6 = checkPump6.IsChecked ?? false,
                textPathCSV1 = textPathCSV1.Text,
                textPathCSV2 = textPathCSV2.Text,
                textPathCSV3 = textPathCSV3.Text,
                textPathCSV4 = textPathCSV4.Text,
                textPathCSV5 = textPathCSV5.Text,
                textPathCSV6 = textPathCSV6.Text,
                textPathXSLX1 = textPathXSLX1.Text,
                textPathXSLX2 = textPathXSLX2.Text,
                textPathXSLX3 = textPathXSLX3.Text,
                textPathXSLX4 = textPathXSLX4.Text,
                textPathXSLX5 = textPathXSLX5.Text,
                textPathXSLX6 = textPathXSLX6.Text,
            };
            SaveStateToXML(state, "state.xml");
        }
    }
}
