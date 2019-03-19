using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SchoolListEditor
{
    public partial class MainWindow
    {
        /// <summary>
        ///     НЕ ЗАБЫТЬ СДЕЛАТЬ SCHOOLS != NULL
        /// </summary>
        /// <param name="openFileDialog"></param>
        /// <param name="schools"></param>
        public void ReadCSV(FileStream fileStream, List<School> schools)
        {
            //  var fileStream = openFileDialog.OpenFile();
            try
            {

                using (StreamReader reader = new StreamReader(fileStream))
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

                schoolList = SchoolForDataGrid.Convert(schools);
                view = CollectionViewSource.GetDefaultView(schoolList);
                view.Filter = ObjectFilter;
                mainDataGrid.ItemsSource = schoolList;
                MessageBox.Show("Успешно загружено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public bool ObjectFilter(object obj)
        {
            SchoolForDataGrid school = (SchoolForDataGrid)obj;
            bool value = schoolList.IndexOf(school) < itemsToShow;
            if (radioButtonIncorporationTrue.IsChecked == true && !school.Form_of_incorporation) value = false;
            if (radioButtonIncorporationFalse.IsChecked == true && school.Form_of_incorporation) value = false;
            if (textBoxSubmission.Text != "")
                if (!school.Submission.Contains(textBoxSubmission.Text)) value = false;
            return value;
        }
    }
}
