namespace SchoolListEditor
{
    public partial class MainWindow
    {
        public class School
        {
            public int ROWNUM { get; set; }

            public string Name { get; set; }

            public Disposition Location { get; set; } = new Disposition();

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
        }
        public class Disposition
        {

            public string Adress { get; set; }

            public string Okrug { get; set; }

            public string Rayon { get; set; }

        }
    }
}
