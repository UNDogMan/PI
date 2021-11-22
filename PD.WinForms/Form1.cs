using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PD.DataCore.Models;

namespace PD.WinForms
{
    public partial class Form1 : Form
    {
        private ServiceProxy service;
        private PhoneDictionaryModel model;

        public Form1()
        {
            InitializeComponent();
            service = new ServiceProxy();

            UpdateListView();
            aSMXToolStripMenuItem_Click(null, null);
        }

        private void UpdateListView()
        {
            var items = service.GetAll();
            listBoxPD.Items.Clear();
            listBoxPD.Items.AddRange(items.ToArray());
        }

        private void aSMXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.UseASMX();
            labelService.Text = $"Service: {Services.ASMX}";
            UpdateListView();
            buttonClear_Click(null, null);
        }

        private void wCFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.UseWCF();
            labelService.Text = $"Service: {Services.WCF}";
            UpdateListView();
            buttonClear_Click(null, null);
        }

        private void listBoxPD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPD.SelectedItem != null) {
                model = (PhoneDictionaryModel)listBoxPD.SelectedItem;
                buttonDelete.Enabled = true;
                buttonUpdate.Enabled = true;

                textBoxPN.Text = model.PhoneNum;
                textBoxSN.Text = model.Surname;

                labelSelected.Text = model.ToString(); }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            model = null;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;

            textBoxPN.Text = "";
            textBoxSN.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBoxPN.Text) && !string.IsNullOrWhiteSpace(textBoxSN.Text))
            {
                service.Add(new PhoneDictionaryModel { PhoneNum = textBoxPN.Text, Surname = textBoxSN.Text });
                UpdateListView();
                buttonClear_Click(null, null);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                service.Delete(model);
                UpdateListView();
                buttonClear_Click(null, null);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxPN.Text) && !string.IsNullOrWhiteSpace(textBoxSN.Text))
            {
                service.Update(new PhoneDictionaryModel { PhoneNum = textBoxPN.Text, Surname = textBoxSN.Text, ID = model.ID });
                UpdateListView();
                buttonClear_Click(null, null);
            }
        }
    }
}
