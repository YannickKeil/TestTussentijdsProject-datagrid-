using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
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
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestTussentijdsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestProjectEntities dataEntities = new TestProjectEntities();
        public MainWindow()
        {
            InitializeComponent();
            var query =
                from Author in dataEntities.Authors
                    //where Author.city == "Oakland"
                orderby Author.au_lname
                select new { Voornaam = Author.au_fname, Achternaam = Author.au_lname, Author.phone, Author.address, Author.city, Author.state, Author.zip };

            dataGrid1.ItemsSource = query.ToList();
            //List<User> users = new List<User>();
            //users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            //users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            //users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            //dataGrid1.ItemsSource = users;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid1_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btnSelectedItem_Click(object sender, RoutedEventArgs e)
        {

            //using (TestProjectEntities ctx = new TestProjectEntities())
            //{
            //    //    //MessageBox.Show(dataGrid1.SelectedItem.ToString());
            //    if (File.Exists("gegevens.Json")) { }
            //    else
            //    {
            //        File.Create("gegevens.Json").Dispose();
            //    }
            //string jsonString;
            //List<User> users = new List<User>();
            //users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            //users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            //users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            //foreach (var item in users)
            //{


            //    jsonString = JsonSerializer.Serialize<Werknemer>(item);
            //    File.AppendAllText("gegevens.Json", jsonString);

            //}
            //}
            using (TestProjectEntities ctx = new TestProjectEntities())
            {
                //var werknrm = JsonDeserlialize(typeof(IQueryable<Werknemer>), "gegevens.Json") as IQueryable<Werknemer>;
                /*string test = "";
                JsonSerializer jsonSerializer = new JsonSerializer();
                if (File.Exists("gegevens.Json"))
                {
                    StreamReader sr = new StreamReader("gegevens.Json");
                    JsonReader jsonReader = new JsonTextReader(sr);
                    var obj = jsonSerializer.Deserialize(jsonReader);
                    jsonReader.Close();
                    sr.Close();
                    test = obj.ToString();
                    
                }
                MessageBox.Show(test);*/
                var json = File.ReadAllText("gegevens.Json");
                List<Werknemer> werknemers = JsonConvert.DeserializeObject<List<Werknemer>>(json);
                foreach (var item in werknemers)
                {
                    MessageBox.Show(item.Voornaam.ToString());
                }

                //var werknrm = obj;
                //MessageBox.Show(werknrm.ToString());
            }
        }

        private void btnSelectedrow_Click(object sender, RoutedEventArgs e)
        {
            using (TestProjectEntities ctx = new TestProjectEntities())
            {
                //var werknmr = ctx.Werknemers.Select(w => new { WerknemerID = w.WerknemerID, Achternaam = w.Achternaam, Voornaam = w.Voornaam, Functie = w.Functie, Beleefdheidstitel = w.Beleefdheidstitel, Geboortedatum = (DateTime)w.Geboortedatum, In_dienst = (DateTime)w.In_dienst });
                var werknmr = ctx.Werknemers.Select(w => w);
                //JsonSerialize(werknmr, "gegevens.Json");
                List<Werknemer> testwerknemers = new List<Werknemer>();
                foreach (var item in werknmr)
                {

                    Werknemer test = new Werknemer() { WerknemerID = item.WerknemerID, Achternaam = item.Achternaam, Voornaam = item.Voornaam, Functie = item.Functie, Beleefdheidstitel = item.Beleefdheidstitel, Geboortedatum = (DateTime)item.Geboortedatum, In_dienst = (DateTime)item.In_dienst };
                    //JsonSerializer jsonSerializer = new JsonSerializer();
                    testwerknemers.Add(test);
                }
                if (!File.Exists("gegevens.Json"))
                {
                    //File.Delete("gegevens.Json");
                    //File.Create("gegevens.Json");
                    //StreamWriter sw = new StreamWriter("gegevens.Json",true);
                    //JsonWriter jsonWriter = new JsonTextWriter(sw);

                    //jsonSerializer.Serialize(jsonWriter, item);

                    //jsonWriter.Close();
                    //sw.Close();
                    using (FileStream fs = File.Create("gegevens.Json"))
                    {
                    }


                }

                var jsonString = JsonConvert.SerializeObject(testwerknemers, Formatting.Indented);
                File.WriteAllText("gegevens.Json", jsonString);
                MessageBox.Show(jsonString.ToString());

            }


        }
        public class User
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime Birthday { get; set; }
        }
        public class WeatherForecastWithPOCOs
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            public string SummaryField;
            public IList<DateTimeOffset> DatesAvailable { get; set; }
            public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
            public string[] SummaryWords { get; set; }
        }

        public class HighLowTemps
        {
            public int High { get; set; }
            public int Low { get; set; }
        }
        public void JsonSerialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            sw.Close();

        }
        public object JsonDeserlialize(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(sr);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                sr.Close();
            }

            return obj.ToObject(dataType);
        }
    }
}
