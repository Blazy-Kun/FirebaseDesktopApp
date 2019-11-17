using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Data.SqlClient;
using System.Speech.Synthesis;

namespace FirebaseDesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "yxzbHofn64RfZrqjs90U5VUmGGKPSbbNokvpMnPl",
            BasePath = "https://opsc-ice-1551683025489.firebaseio.com/"
        };

        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> a = new List<string>();
            a.Add("Afrikaans");
            a.Add("English");
            a.Add("History");
            a.Add("Information Systems");
            a.Add("Java Programming");
            a.Add("Life Skills");
            a.Add("Life Sciences");
            a.Add("Math");
            a.Add("Music");
            a.Add("Physical Sciences");         
                  
            comboBox1.DataSource = a;



            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("There was some internet error");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /* var res = client.Get($@"books/{textBox1.Text}/{comboBox1.SelectedItem.ToString()}");
             books std = res.ResultAs<books>();
             books stdh = new books()
             {
                 userid = "x",

                 subject = std.subject,

                 amount = "25",

                 level = std.level,

                 tutor = "v",
                 date = std.date,
                 ad = std.ad
             };

             var set = client.Update($@"books/{textBox1.Text}/{comboBox1.SelectedItem.ToString()}", stdh);

             MessageBox.Show("data updated sucessfully!");




             books stdhs = new books()
             {
                 userid = "x",

                 subject = "info",

                 amount = "25",
                 level = std.level,

                 tutor = "v",
                 date = std.date,
                 ad = std.ad
             };

             var sets = client.Update($@"bookss/{textBox1.Text}/{comboBox1.SelectedItem.ToString()}", stdhs);

             MessageBox.Show("data updated sucessfully!");*/
            var res = client.Get($@"books/{textBox1.Text}/{comboBox1.SelectedItem.ToString()}");
            books std = res.ResultAs<books>();
            books stdh = new books()
            {
                userid = textBox1.Text,

                subject = std.subject,

                amount = "25",

                level = std.level,

                tutor = textBox2.Text,
                date = std.date,
                ad = std.ad
            };

            var set = client.Update($@"books/{textBox1.Text}/{comboBox1.SelectedItem.ToString()}", stdh);

            MessageBox.Show("data updated sucessfully!");




            books stdhs = new books()
            {
                userid = textBox1.Text,

                subject = std.subject,

                amount = "25",
                level = std.level,

                tutor = textBox2.Text,
                date = std.date,
                ad = std.ad
            };

            var sets = client.Set($@"bookss/{textBox2.Text}/{comboBox1.SelectedItem.ToString()}", stdhs);

            MessageBox.Show("data updated sucessfully!");

            textBox1.Clear();
            textBox2.Clear();

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -2;     // -10...10

            // Synchronous
            synthesizer.Speak("Tutor assigned ");

            // Asynchronous
          //  synthesizer.SpeakAsync("Hello World");

        }
    }

   

    
}



