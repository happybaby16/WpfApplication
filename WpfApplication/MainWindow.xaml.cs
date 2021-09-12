using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApplication
{

    struct info
    {
        public string name { get; set; }
        public string dateBirth { get; set; }
        public string gender { get; set; }
        public string dopinfo { get; set; }
    }



    



    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string[]> database = new List<string[]>();
        public int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

      

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("base.csv", true))
            {
                if (nameTextBox.Text != "" && dateBirth.Text != "")
                {
                    string[] gender = new string[3] { "Мужской", "Женский", "Свой вариант" };
                    string content = "";
                    content = $"{nameTextBox.Text};{dateBirth.Text};{gender[genderListBox.SelectedIndex]};";
                    if (goodCB.IsChecked == true)
                    {
                        content = content + "Добрый, ";
                    }
                    if (otzCB.IsChecked == true)
                    {
                        content = content + "Отзывчивый, ";
                    }
                    if (scromCB.IsChecked == true)
                    {
                        content = content + "Скромный";
                    }
                    sw.WriteLine(content);
                    MessageBox.Show("Данные успешно записаны.");
                }
                else
                {
                    MessageBox.Show("Поле имени или даты рождения не заполнены!");
                }
            }
           
        }

        private void readButton_Click(object sender, RoutedEventArgs e)
        {
            database = new List<string[]>();
            i = 0;
            if (File.Exists("base.csv"))
            {
                using (StreamReader sr = new StreamReader("base.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var data = line.Split(';');
                        database.Add(data);
                    }
                }
                MessageBox.Show("Данные успешно загружены");
            }
            else { MessageBox.Show("Файл с данными отсутствует! Создайте участника!"); }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (i != database.Count)
            {
                nameLabel.Content = database[i][0];
                birhdateLabel.Content = database[i][1];
                genderLabel.Content = database[i][2];
                infLabel.Content = database[i][3];
                i++;
            }
            else
            {
                MessageBox.Show("Список участников закончился...");
                nameLabel.Content = "";
                birhdateLabel.Content = "";
                genderLabel.Content = "";
                infLabel.Content = "";
            }
            
        }
    }
}
