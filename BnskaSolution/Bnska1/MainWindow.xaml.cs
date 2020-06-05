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
            LoadState();
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
        /// <summary>
        /// Сохранение состояния приложения
        /// </summary>
        private void SaveState()
        {
            SavedStateXML state = new SavedStateXML
            {
                MainWindow = new SavedStateXML.MainWindowXML
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
                },
            };
            try
            {
                SavedStateXML.SaveStateToXML(state, "state.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить состояние приложения.\n" + ex.Message);
            }
        }
        /// <summary>
        /// Загрузка состояния приложения
        /// </summary>
        private void LoadState()
        {
            SavedStateXML state = new SavedStateXML();
            try
            {
                state = SavedStateXML.LoadFromXMLToState("state.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить состояние приложения.\n" + ex.Message);
                return;
            }
            if (state.MainWindow == null)
                return;
            SavedStateXML.MainWindowXML mainWindow = state.MainWindow;
            checkPump1.IsChecked = mainWindow.checkPump1;
            checkPump2.IsChecked = mainWindow.checkPump2;
            checkPump3.IsChecked = mainWindow.checkPump3;
            checkPump4.IsChecked = mainWindow.checkPump4;
            checkPump5.IsChecked = mainWindow.checkPump5;
            checkPump6.IsChecked = mainWindow.checkPump6;
            textPathCSV1.Text = mainWindow.textPathCSV1;
            textPathCSV2.Text = mainWindow.textPathCSV2;
            textPathCSV3.Text = mainWindow.textPathCSV3;
            textPathCSV4.Text = mainWindow.textPathCSV4;
            textPathCSV5.Text = mainWindow.textPathCSV5;
            textPathCSV6.Text = mainWindow.textPathCSV6;
            textPathXSLX1.Text = mainWindow.textPathXSLX1;
            textPathXSLX2.Text = mainWindow.textPathXSLX2;
            textPathXSLX3.Text = mainWindow.textPathXSLX3;
            textPathXSLX4.Text = mainWindow.textPathXSLX4;
            textPathXSLX5.Text = mainWindow.textPathXSLX5;
            textPathXSLX6.Text = mainWindow.textPathXSLX6;
        }

        private void SendAll_Click(object sender, RoutedEventArgs e)
        {
            List<string> attList = new List<string>();
            if (checkPump1.IsChecked == true)
                attList.Add(textPathXSLX1.Text);
            if (checkPump2.IsChecked == true)
                attList.Add(textPathXSLX2.Text);
            if (checkPump3.IsChecked == true)
                attList.Add(textPathXSLX3.Text);
            if (checkPump4.IsChecked == true)
                attList.Add(textPathXSLX4.Text);
            if (checkPump5.IsChecked == true)
                attList.Add(textPathXSLX5.Text);
            if (checkPump6.IsChecked == true)
                attList.Add(textPathXSLX6.Text);
            try
            {
                Outlook.CreateMailItemToMayorovYurzin(attList.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при формировании письма.\n" + ex.Message);
            }
        }
    }
}
