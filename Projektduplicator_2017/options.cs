using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Projektduplicator_2017
{
    public partial class options : Form
    {
        private bool idliste;
        public options()
        {
            
            InitializeComponent();
            var idliste = false;
            if (Properties.Settings.Default.country2 == "de")
            {
                CultureInfo ci = new CultureInfo("de");
                getRes(ci);
            }
            else if (Properties.Settings.Default.country2 == "en")
            {
                CultureInfo ci = new CultureInfo("en");
                getRes(ci);

            }
            else if (Properties.Settings.Default.country2 == "fr")
            {
                CultureInfo ci = new CultureInfo("fr");
                getRes(ci);

            }
            else if (Properties.Settings.Default.country2 == "nl")
            {
                CultureInfo ci = new CultureInfo("nl");
                getRes(ci);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                var objResult = folderBrowserDialog1.ShowDialog(this);
                if (objResult == DialogResult.OK)
                {
                    label1.Text = folderBrowserDialog1.SelectedPath;

                }
                else
                {

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                var objResult2 = folderBrowserDialog2.ShowDialog(this);
                if (objResult2 == DialogResult.OK)
                {
                    label5.Text = folderBrowserDialog2.SelectedPath;
                }
                else
                {

                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
            Properties.Settings.Default.delfkt = true;
            }
            else if (!checkBox1.Checked)
            {
            Properties.Settings.Default.delfkt = false;
            }
            Properties.Settings.Default.backup2 = label5.Text;
            Properties.Settings.Default.pathNos = label1.Text;

            if (idliste == true)
            {
                Properties.Settings.Default.id_code = textBox1.Text;
            }
            Properties.Settings.Default.pathNosDup_alt = Properties.Settings.Default.pathNos;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.konkuerzel = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void options_Load(object sender, EventArgs e)
        {
            textBox2.Text = Properties.Settings.Default.konkuerzel;
            label6.Text = Properties.Settings.Default.respath;
        }

        private void getRes(CultureInfo ci)
        {
            ResourceManager rm = new ResourceManager("Projektduplicator_2017.optionres", typeof(Form1).Assembly);
            this.Text = rm.GetString("opt_1", ci);
            label3.Text = rm.GetString("opt_2", ci);
            label4.Text = rm.GetString("opt_3", ci);
            checkBox1.Text = rm.GetString("opt_4", ci);
            button2.Text = rm.GetString("opt_5", ci);
            button4.Text = rm.GetString("opt_9", ci);
            button1.Text = rm.GetString("opt_6", ci);
            button3.Text = rm.GetString("opt_7", ci);
            label2.Text = rm.GetString("opt_8", ci);
            Properties.Settings.Default.Save();

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var idliste = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                {
                    var objResult = folderBrowserDialog3.ShowDialog(this);
                    if (objResult == DialogResult.OK)
                    {
                        label6.Text = folderBrowserDialog3.SelectedPath;

                    }
                    else
                    {

                    }
                }
            }
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.respath = label6.Text;
            Properties.Settings.Default.respath2 = label6.Text + "\\" + "Resourcen" + "\\";
            Properties.Settings.Default.Save();

        }
    }
}
