using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                int X = int.Parse(textBoxX.Text);
                int Y = int.Parse(textBoxY.Text);
                using(var client = new HttpClient())
                {
                    var context = new FormUrlEncodedContent(new[] { 
                        new KeyValuePair<string, string>("X", X.ToString()),
                        new KeyValuePair<string, string>("Y", Y.ToString())
                    });
                    var response = await client.PostAsync(textBoxURL.Text, context);
                    MessageBox.Show(await response.Content.ReadAsStringAsync(), 
                        response.StatusCode.ToString());
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
