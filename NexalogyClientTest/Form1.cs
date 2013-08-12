using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using SharpNexalogy;

namespace NexalogyClientTest
{
    public partial class Form1 : Form
    {
        private string _apikey;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var s = new Properties.Settings();
            _apikey = s.ApiKey;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new NexalogyClient(_apikey);
            var result = client.ProjectGetList();

            textBox1.Text = "Project list" + Environment.NewLine + Environment.NewLine;
            foreach (var proj in result.projects)
            {
                textBox1.AppendText(string.Format("     Id: {0}      Name: {1}", proj.id, proj.name) + Environment.NewLine);
            }
            textBox1.AppendText(Environment.NewLine + "Total: " + result.projects.Count + Environment.NewLine);


            textBox1.AppendText(Environment.NewLine + Environment.NewLine + JsonConvert.SerializeObject(result, Formatting.Indented));

        }


        private void button3_Click(object sender, EventArgs e)
        {
            var client = new NexalogyClient(_apikey);
            var result = client.ProjectGet(projectId.Text);

            textBox1.Text = JsonConvert.SerializeObject(result, Formatting.Indented);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var client = new NexalogyClient(_apikey);

            var proj = new SharpNexalogy.Model.Project
                           {
                               name = projectname.Text, 
                               language = "en"
                           };

            var result = client.ProjectCreate(proj);
            textBox1.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var client = new NexalogyClient(_apikey);

            var result = client.ProjectFind();
            textBox1.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var client = new NexalogyClient(_apikey);

            var result = client.LexiconGenerate(lexgenprojId.Text);
            textBox1.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
            
        }

        
    }
}
