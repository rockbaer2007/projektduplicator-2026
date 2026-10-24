using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JB.IO;

namespace Projektduplicator_2017
    {
    public partial class xfile_change : Form
        {
        private IniFile SettingsJB;
        private string a1;
        private string a2;
        private string a3;
        private string a4;
        private string a5;
        private string a6;
        private string a7;




        public xfile_change()
            {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.startID;
            numericUpDown1.Value = Properties.Settings.Default.aktID;
            label2.Text = Properties.Settings.Default.pathID;
            button3.Enabled = false;

            if (Properties.Settings.Default.country2 == "de")
                {
                CultureInfo ci = new CultureInfo("de");
                getRes(ci);
                //getRes2(ci);
                }
            else if (Properties.Settings.Default.country2 == "en")
                {
                CultureInfo ci = new CultureInfo("en");
                getRes(ci);
                //getRes2(ci);
                }
            else if (Properties.Settings.Default.country2 == "fr")
                {
                CultureInfo ci = new CultureInfo("fr");
                getRes(ci);
                //getRes2(ci);
                }
            else if (Properties.Settings.Default.country2 == "nl")
                {
                CultureInfo ci = new CultureInfo("nl");
                getRes(ci);
                //getRes2(ci);
                }

            }


        private void getRes(CultureInfo ci)
            {
            ResourceManager rm = new ResourceManager("Projektduplicator_2017.langres", typeof(Form1).Assembly);
            a1 = rm.GetString("btn1_xfile", ci);
            a2 = rm.GetString("btn2_xfile", ci);
            a3 = rm.GetString("btn3_xfile", ci);
            a4 = rm.GetString("lbl1_xfile", ci);
            //a5 = rm.GetString("lbl2_xfile", ci);
            a6 = rm.GetString("lbl3_xfile", ci);
            a7 = rm.GetString("lbl4_xfile", ci);
            Properties.Settings.Default.Save();

            }
        private void TextBox1_TextChanged(object sender, EventArgs e)
            {

            }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                e.Handled = true;
                }
            }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
            {
            Properties.Settings.Default.aktID = numericUpDown1.Value;
            Properties.Settings.Default.Save();
            }

        private void Button2_Click(object sender, EventArgs e)
            {
            string txtBoxValue = textBox1.Text;
            Properties.Settings.Default.startID = textBox1.Text;
            Properties.Settings.Default.Save();
            decimal amount;
            bool parsedOk = decimal.TryParse(txtBoxValue, out amount);
            numericUpDown1.Minimum = numericUpDown1.Value = amount;
            }

        private void Button1_Click(object sender, EventArgs e)
            {
            Properties.Settings.Default.aktID = numericUpDown1.Value;
            Properties.Settings.Default.Save();
            button1.Enabled = false;
            DataTable d = new DataTable();
            d.Columns.Add("pfad");
            d.Columns.Add("Id Org");
            d.Columns.Add("ID Neu");
            foreach (FileInfo fale in new DirectoryInfo(Properties.Settings.Default.pathID).GetFiles(@"*.x.ini", System.IO.SearchOption.AllDirectories))
                {
                SettingsJB = new JB.IO.IniFile(fale.FullName);
                string a1 = SettingsJB["Import"]["TextureID"];
                string a2 = " " + numericUpDown1.Value.ToString();
                if (String.IsNullOrEmpty(a1))
                    {

                    }
                else
                    {
                    DataRow drawingTableRow = d.NewRow();
                    drawingTableRow = d.NewRow();
                    drawingTableRow["pfad"] = fale.FullName.ToString();
                    drawingTableRow["Id Org"] = a1;
                    drawingTableRow["ID Neu"] = a2;
                    d.Rows.Add(drawingTableRow);
                    }
                SettingsJB["Import"]["TextureID"] = textBox1.Text;

                if (File.Exists(fale.DirectoryName + "\\" + "Org_ini_entry.txt"))
                    {
                    using (StreamWriter sw = File.AppendText(Properties.Settings.Default.pathID + "\\" + "Org_ini_entry.txt"))
                        {
                        sw.WriteLine(fale.FullName + "\t" + a1);
                        }
                    }
                else
                    {
                    using (StreamWriter sw = File.CreateText(Properties.Settings.Default.pathID + "\\" + "Org_ini_entry.txt"))
                        {
                        sw.WriteLine(fale.FullName + "\t" + a1);
                        }
                    }
                }
            dataGridView1.DataSource = d;
            button3.Enabled = true;
            }

        private void Button3_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void Xfile_change_Load(object sender, EventArgs e)
            {
            button1.Text = a1;
            button2.Text = a2;
            button3.Text = a3;
            label1.Text = a4;
            //label2.Text = a5;
            label3.Text = a6;
            label4.Text = a7;
            }
        }
    }
