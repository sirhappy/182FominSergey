using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;

namespace SchoolListEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ObservableCollection<SchoolForDataGrid> schoolList = new ObservableCollection<SchoolForDataGrid>();
        List<School> linkSchoolList = new List<School>();
        int itemsToShow = int.MaxValue;
        ICollectionView view;
        string path = "";
        public List<School> schools = null;

        public MainWindow()
        {
            InitializeComponent();
            mainDataGrid.ItemsSource = schoolList;
        }

        private void LoadCSVButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == true)
                {
                    path = openFileDialog.FileName;
                    schools = new List<School>();
                    using (var fs = openFileDialog.OpenFile())
                        ReadCSV((FileStream)fs, schools);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBoxCountOfElements_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemsToShow = -1;
            int.TryParse(((TextBox)sender).Text, out itemsToShow);
            if (itemsToShow < 1) itemsToShow = int.MaxValue;
            view?.Refresh();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            view?.Refresh();
        }

        private void TextBoxSubmission_TextChanged(object sender, TextChangedEventArgs e)
        {
            view?.Refresh();
        }

        private void SaveHereCSVButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (path == "")
                {
                    MessageBox.Show("Файл не найден, сохраните в отдельный файл");
                    return;
                }
                using (FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        int cnt = 0;
                        sw.WriteLine("ROWNUM;name;adress;okrug;rayon;form_of_incorporation;submission;" +
                                     "tip_uchrezhdeniya;vid_uchrezhdeniya;telephone;web_site;e_mail;X;Y;global_id");
                        foreach (SchoolForDataGrid school in schoolList)
                        {
                            string s = "";
                            s += ++cnt + ";";
                            s += FormatForCSV(school.Name);
                            s += FormatForCSV(school.Adress);
                            s += FormatForCSV(school.Okrug);
                            s += FormatForCSV(school.Rayon);
                            if (school.Form_of_incorporation) s += ("Государственное;");
                            else s += ("Негосударственное;");
                            s += FormatForCSV(school.Submission);
                            s += FormatForCSV(school.Tip_uchrezhdeniya);
                            s += FormatForCSV(school.Vid_uchrezhdeniya);
                            s += FormatForCSV(school.Telephone);
                            s += FormatForCSV(school.Web_site);
                            s += FormatForCSV(school.E_mail);
                            s += FormatForCSV(school.X);
                            s += FormatForCSV(school.Y);
                            s += FormatForCSV(school.Global_id);
                            s = s.Substring(0, s.Length - 1);
                            int t = 0;
                            foreach (char i in s)
                                if (i == ';') ++t;
                            sw.WriteLine(s);
                        }
                    }
                }
                MessageBox.Show("Успешно сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string FormatForCSV(string s) => "\"" + s?.Replace("\"", "\"\"") + "\";";

        private void SaveAddHereCSVButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<School> schools = new List<School>();
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fs))
                {
                    using (TextFieldParser parser = new TextFieldParser(reader))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(";");
                        string[] fields = parser.ReadFields();
                        // TODO: check zagolovok
                        while (!parser.EndOfData)
                        {
                            //Process row
                            fields = parser.ReadFields();

                            School school = new School();
                            school.ROWNUM = int.Parse(fields[0]);
                            school.Name = fields[1];
                            school.Location.Adress = fields[2];
                            school.Location.Okrug = fields[3];
                            school.Location.Rayon = fields[4];
                            school.Form_of_incorporation = (fields[5] == "Негосударственное") ? false : true;
                            school.Submission = fields[6];
                            school.Tip_uchrezhdeniya = fields[7];
                            school.Vid_uchrezhdeniya = fields[8];
                            school.Telephone = fields[9];
                            school.Web_site = fields[10];
                            school.E_mail = fields[11];
                            school.X = fields[12];
                            school.Y = fields[13];
                            school.Global_id = fields[14];
                            schools.Add(school);
                        }
                    }
                }
                ObservableCollection<SchoolForDataGrid> fileSchoolList = SchoolForDataGrid.Convert(schools), tmpSchoolList;

                using (FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        int cnt = 0;
                        sw.WriteLine("ROWNUM;name;adress;okrug;rayon;form_of_incorporation;submission;" +
                                     "tip_uchrezhdeniya;vid_uchrezhdeniya;telephone;web_site;e_mail;X;Y;global_id");
                        tmpSchoolList = schoolList;
                        schoolList = fileSchoolList;
                        foreach (SchoolForDataGrid school in schoolList)
                        {
                            string s = "";
                            s += ++cnt + ";";
                            s += FormatForCSV(school.Name);
                            s += FormatForCSV(school.Adress);
                            s += FormatForCSV(school.Okrug);
                            s += FormatForCSV(school.Rayon);
                            if (school.Form_of_incorporation) s += ("Государственное;");
                            else s += ("Негосударственное;");
                            s += FormatForCSV(school.Submission);
                            s += FormatForCSV(school.Tip_uchrezhdeniya);
                            s += FormatForCSV(school.Vid_uchrezhdeniya);
                            s += FormatForCSV(school.Telephone);
                            s += FormatForCSV(school.Web_site);
                            s += FormatForCSV(school.E_mail);
                            s += FormatForCSV(school.X);
                            s += FormatForCSV(school.Y);
                            s += FormatForCSV(school.Global_id);
                            s = s.Substring(0, s.Length);
                            sw.WriteLine(s);
                        }
                        schoolList = tmpSchoolList;
                        foreach (SchoolForDataGrid school in schoolList)
                        {
                            string s = "";
                            s += ++cnt + ";";
                            s += FormatForCSV(school.Name);
                            s += FormatForCSV(school.Adress);
                            s += FormatForCSV(school.Okrug);
                            s += FormatForCSV(school.Rayon);
                            if (school.Form_of_incorporation) s += ("Государственное;");
                            else s += ("Негосударственное;");
                            s += FormatForCSV(school.Submission);
                            s += FormatForCSV(school.Tip_uchrezhdeniya);
                            s += FormatForCSV(school.Vid_uchrezhdeniya);
                            s += FormatForCSV(school.Telephone);
                            s += FormatForCSV(school.Web_site);
                            s += FormatForCSV(school.E_mail);
                            s += FormatForCSV(school.X);
                            s += FormatForCSV(school.Y);
                            s += FormatForCSV(school.Global_id);
                            s = s.Substring(0, s.Length);
                            sw.WriteLine(s);
                        }
                    }
                }
                schools = new List<School>();
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                    ReadCSV(fs, schools);
                view.Refresh();
                MessageBox.Show("Успешно сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveThereCSVButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (FileStream fs = File.Open(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            int cnt = 0;
                            sw.WriteLine("ROWNUM;name;adress;okrug;rayon;form_of_incorporation;submission;" +
                                         "tip_uchrezhdeniya;vid_uchrezhdeniya;telephone;web_site;e_mail;X;Y;global_id");
                            foreach (SchoolForDataGrid school in schoolList)
                            {
                                string s = "";
                                s += ++cnt + ";";
                                s += FormatForCSV(school.Name);
                                s += FormatForCSV(school.Adress);
                                s += FormatForCSV(school.Okrug);
                                s += FormatForCSV(school.Rayon);
                                if (school.Form_of_incorporation) s += ("Государственное;");
                                else s += ("Негосударственное;");
                                s += FormatForCSV(school.Submission);
                                s += FormatForCSV(school.Tip_uchrezhdeniya);
                                s += FormatForCSV(school.Vid_uchrezhdeniya);
                                s += FormatForCSV(school.Telephone);
                                s += FormatForCSV(school.Web_site);
                                s += FormatForCSV(school.E_mail);
                                s += FormatForCSV(school.X);
                                s += FormatForCSV(school.Y);
                                s += FormatForCSV(school.Global_id);
                                s = s.Substring(0, s.Length - 1);
                                int t = 0;
                                foreach (char i in s)
                                    if (i == ';') ++t;
                                sw.WriteLine(s);
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
