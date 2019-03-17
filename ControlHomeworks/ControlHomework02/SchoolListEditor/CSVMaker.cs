using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolListEditor
{
    public partial class MainWindow
    {
        public void ReadCSV(OpenFileDialog openFileDialog)
        {
            var fileStream = openFileDialog.OpenFile();
            List<School> schools = new List<School>();

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
            mainDataGrid.Items.Refresh();
            mainDataGrid.ItemsSource = schoolList;
            MessageBox.Show("ok");
        }
    }
}
