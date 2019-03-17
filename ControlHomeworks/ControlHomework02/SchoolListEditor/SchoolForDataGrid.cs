using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchoolListEditor
{
    public partial class MainWindow
    {
        public class SchoolForDataGrid
        {

            public string Name { get; set; }

            public string Adress { get; set; }

            public string Okrug { get; set; }

            public string Rayon { get; set; }

            public bool Form_of_incorporation { get; set; }

            public string Submission { get; set; }

            public string Tip_uchrezhdeniya { get; set; }

            public string Vid_uchrezhdeniya { get; set; }

            public string Telephone { get; set; }

            public string Web_site { get; set; }

            public string E_mail { get; set; }

            public string X { get; set; }

            public string Y { get; set; }

            public string Global_id { get; set; }

            public static ObservableCollection<SchoolForDataGrid> Convert(List<School> schools)
            {
                ObservableCollection<SchoolForDataGrid> result = new ObservableCollection<SchoolForDataGrid>();
                foreach(var i in schools)
                {
                    result.Add(new SchoolForDataGrid()
                    {
                        Name = i.Name,
                        Adress = i.Location.Adress,
                        Okrug = i.Location.Okrug,
                        Rayon = i.Location.Rayon,
                        Form_of_incorporation = i.Form_of_incorporation,
                        Submission = i.Submission,
                        Tip_uchrezhdeniya = i.Tip_uchrezhdeniya,
                        Vid_uchrezhdeniya = i.Vid_uchrezhdeniya,
                        Telephone = i.Telephone,
                        Web_site = i.Web_site,
                        E_mail = i.E_mail,
                        X = i.X,
                        Y = i.Y,
                        Global_id = i.Global_id
                    });
                }
                return result;
            }
        }
    }
}
