
using rbtools;
using projectduplicator_2017;
using Projektduplicator_2017.Properties;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Projektduplicator.Update;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO.Compression;
using System.Globalization;
using System.Resources;
using System.Drawing;
using System.Drawing.Printing;
using RichTextBoxPrintCtrl;
using System.Text.RegularExpressions;

namespace Projektduplicator_2017
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private string pdfdoc_eng;
        private string pdfdoc_ger;
        private string pdfdoc_fra;
        private string pdfdoc_pol;
        private string desc_eng;
        private string desc_ger;
        private string desc_fra;
        private string desc_pol;
        private string name_eng;
        private string name_ger;
        private string name_fra;
        private string name_pol;
        private string icon;
        private string icon_org;
        private string country;
        private string country_org;
        private string autor;
        private string model_org;
        private string desc;
        private string remark;
        private string org;
        private string splineID;
        private string str;
        private IniFile SettingsJB;
        private IniFile SettingsJB2;
        private IniFile SettingsJB3;
        string NL = Environment.NewLine;
        private string a1;
        private string o1;
        private string b1;
        private string r1;
        private string m01;
        private string m1;
        private string m2;
        private string m3;
        private string m4;
        private string m001;
        private string d1;
        private string d2;
        private string d3;
        private string d4;
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private static string _operationDirNotExist = "Can not find the directory";
        private static string _operationDirNotEmpty = "Directory is not empty";
        private static string _operationSuccess = "success";
        private static string _operationFailed = "failed";
        private string lb1;
        private string m002;
        private string m003;
        private string lb1_h;
        private string lb2;
        private string ml1;
        private string msgb1;
        private string ml2;
        private string ml3;
        private string ml4;
        private string ml5;
        private string ml6;
        private string ml7;
        private string mlu1;
        private string mlu2;
        private string mlu3;
        private string mlu4;
        private string test;
        private int checkPrint;

        public Form1()
        {
            InitializeComponent();

            int Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //this.labelProductName.Text = AssemblyProduct;
            this.labelProductName.Text = "Projektduplicator 2026";
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            this.tabControl1.ShowToolTips = true;
            string version = AssemblyVersion;
            this.Text = String.Format("Projektduplicator 2026 -- Version {0}", version);
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";


            
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
            else if (Properties.Settings.Default.country2 == "")
            {
                CultureInfo ci = new CultureInfo("en");
                getRes(ci);

            }

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            EnsurePathExists(Properties.Settings.Default.backup);
            EnsurePathExists(Properties.Settings.Default.user_backup);
        }

    private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void EnsurePathExists(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {

            }
        }

        private void directoryTreeViewOnDemand1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Properties.Settings.Default.release = false;
            Properties.Settings.Default.Save();

            TreeNode nodeAt = this.directoryTreeViewOnDemand1.GetNodeAt(this.directoryTreeViewOnDemand1.PointToClient(Cursor.Position));


            try
            {
                this.richTextBox1.Clear();
                pdfdoc_eng = "";
                pdfdoc_ger = "";
                pdfdoc_fra = "";
                pdfdoc_pol = "";
                desc_eng = "";
                desc_ger = "";
                desc_fra = "";
                desc_pol = "";
                name_eng = "";
                name_ger = "";
                name_fra = "";
                name_pol = "";
                icon = "";
                icon_org = "";
                country = "";
                country_org = "";
                autor = "";
                org = "";
                splineID = "";
                desc = "";
                remark = "";

                this.listView1.Clear();

                this.listView1.View = View.List;
                Settings.Default.pathNosDup = nodeAt.FullPath;
                Settings.Default.Save();

                if (Directory.Exists(Settings.Default.pathNosDup + "\\" + "Release"))
                {
                    Settings.Default.release = true;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.release = false;
                    Settings.Default.Save();
                }

                if (Directory.Exists(Settings.Default.pathNosDup + "\\" + "UserRelease"))
                {
                    Settings.Default.userrelease = true;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.userrelease = false;
                    Settings.Default.Save();
                }

                this.label1.Text = lb1 + " : " + Settings.Default.pathNosDup;
                this.label2.Text = "";
                this.label3.Text = "";
                inilesen(Settings.Default.pathNosDup);
                prjlesen(Settings.Default.pathNosDup);
                sysinilesen(Settings.Default.pathNosDup);
                this.rtbox_lesen();
                dirlesen(Settings.Default.pathNosDup);
            }
            catch (Exception)
            {
            }
        }
        private void rtbox_lesen()
        {
            richTextBox1.Clear();

            if (Settings.Default.release == true)
            {
                string txt1 = "   Set ist bereits exportiert / Release-Ordner existiert\r\n"+"   "+ "beim Bearbeiten werden die Einträge in der Ini-Datei im\r\n" + "   " + "Release-Ordner auch bearbeitet\r\n" + "   " + "beim Kopieren wird der Release-Ordner ins neuen Projekt nicht mitkopiert";
                int pos = richTextBox1.TextLength;
                richTextBox1.AppendText("  " + Environment.NewLine);
                richTextBox1.AppendText(txt1);
                richTextBox1.Select(pos, txt1.Length);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.AppendText(" " + Environment.NewLine);
                richTextBox1.AppendText(" " + Environment.NewLine);
                richTextBox1.AppendText(" " + Environment.NewLine);
            }
            else
            {
                richTextBox1.AppendText("  " + Environment.NewLine);
            }

            if (Settings.Default.userrelease == true)
            {
                string txt1 = "   Set ist bereits exportiert / UserRelease-Ordner existiert\r\n" + "   " + "beim Bearbeiten werden die Einträge in der Ini-Datei im\r\n" + "   " + "UserRelease-Ordner auch bearbeitet\r\n" + "   " + "beim Kopieren wird der UserRelease-Ordner ins neuen Projekt nicht mitkopiert";
                int pos = richTextBox1.TextLength;
                richTextBox1.AppendText("  " + Environment.NewLine);
                richTextBox1.AppendText(txt1);
                richTextBox1.Select(pos, txt1.Length);
                richTextBox1.SelectionColor = Color.Orange;
                richTextBox1.AppendText(" " + Environment.NewLine);
                richTextBox1.AppendText(" " + Environment.NewLine);
                richTextBox1.AppendText(" " + Environment.NewLine);
            }
            else
            {
                richTextBox1.AppendText("  " + Environment.NewLine);
            }
            richTextBox1.AppendText("   " + m001 + Environment.NewLine);
            richTextBox1.AppendText("  " + Environment.NewLine);
            richTextBox1.AppendText("   " + m002 + " :                 " + Environment.NewLine);
            richTextBox1.AppendText("  " + Environment.NewLine);
            richTextBox1.AppendText("   " + m003 + " :                 " + splineID + Environment.NewLine);
            richTextBox1.AppendText("  " + Environment.NewLine);
            richTextBox1.AppendText("   " + a1 + " :                   " + autor + Environment.NewLine); //a1.Text
            richTextBox1.AppendText("   " + o1 + " :                   " + org + Environment.NewLine); //o1.Text
            richTextBox1.AppendText("   " + b1 + " :                   " + desc + Environment.NewLine); //b1.Text
            richTextBox1.AppendText("   " + r1 + " :                   " + remark + Environment.NewLine); //r1.Text
            richTextBox1.AppendText("  " + Environment.NewLine);
            richTextBox1.AppendText("   " + m01 + " :                   " + model_org + Environment.NewLine); //m01.Text
            richTextBox1.AppendText("   " + m1 + " :                   " + name_eng + Environment.NewLine); //m1.Text
            richTextBox1.AppendText("   " + m2 + " :                   " + name_ger + Environment.NewLine); //m2.Text
            richTextBox1.AppendText("   " + m3 + " :                   " + name_fra + Environment.NewLine); //m3.Text
            richTextBox1.AppendText("   " + m4 + " :                   " + name_pol + Environment.NewLine); //m4.text
            richTextBox1.AppendText("  " + Environment.NewLine);
            richTextBox1.AppendText("   " + d1 + " :                   " + desc_eng + Environment.NewLine); //d1.Text
            richTextBox1.AppendText("   " + d2 + " :                   " + desc_ger + Environment.NewLine); //d2.Text
            richTextBox1.AppendText("   " + d3 + " :                   " + desc_fra + Environment.NewLine); //d3.Text
            richTextBox1.AppendText("   " + d4 + " :                   " + desc_pol + Environment.NewLine); //d4.Text
            richTextBox1.AppendText("  " + Environment.NewLine);
            richTextBox1.AppendText("   " + p1 + " :                   " + pdfdoc_eng + Environment.NewLine); //p1.Text
            richTextBox1.AppendText("   " + p2 + " :                   " + pdfdoc_ger + Environment.NewLine); //p2.Text
            richTextBox1.AppendText("   " + p3 + " :                   " + pdfdoc_fra + Environment.NewLine); //p3.Text
            richTextBox1.AppendText("   " + p4 + " :                   " + pdfdoc_pol + Environment.NewLine); //p4.Text
            richTextBox1.AppendText("  " + Environment.NewLine);
        }
        private void inilesen(string filepath)
        {
            str = filepath.Substring(filepath.LastIndexOf('\\')).Replace("\\", "");
            label2.Text = str;
            SettingsJB = new rbtools.IniFile(filepath + "\\" + str + ".ini");
            richTextBox1.Clear();
            icon = SettingsJB["FileInfo"]["Icon"].Replace("\"", "");
            country = SettingsJB["FileInfo"]["Country"].Replace("\"", "");
            name_ger = SettingsJB["FileInfo"]["Name_GER"].Replace("\"", "");
            name_eng = SettingsJB["FileInfo"]["Name_ENG"].Replace("\"", "");
            name_fra = SettingsJB["FileInfo"]["Name_FRA"].Replace("\"", "");
            name_pol = SettingsJB["FileInfo"]["Name_POL"].Replace("\"", "");
            desc_eng = SettingsJB["FileInfo"]["Description_ENG"].Replace("\"", "");
            desc_ger = SettingsJB["FileInfo"]["Description_GER"].Replace("\"", "");
            desc_fra = SettingsJB["FileInfo"]["Description_FRA"].Replace("\"", "");
            desc_pol = SettingsJB["FileInfo"]["Description_POL"].Replace("\"", "");
            model_org = SettingsJB["FileInfo"]["Creator_Model"].Replace("\"", "");
            pdfdoc_eng = SettingsJB["FileInfo"]["PdfDoc_ENG"].Replace("\"", "");
            pdfdoc_ger = SettingsJB["FileInfo"]["PdfDoc_GER"].Replace("\"", "");
            pdfdoc_fra = SettingsJB["FileInfo"]["PdfDoc_FRA"].Replace("\"", "");
            pdfdoc_pol = SettingsJB["FileInfo"]["PdfDoc_POL"].Replace("\"", "");
        }
        private void prjlesen(string filepath)
        {
            SettingsJB2 = new rbtools.IniFile(filepath + "\\" + str + ".prj");
            autor = SettingsJB2["Settings"]["Author"].Replace("\"", "");
            org = SettingsJB2["Settings"]["Org"].Replace("\"", "");
            desc = SettingsJB2["Settings"]["Desc"].Replace("\"", "");
            remark = SettingsJB2["Settings"]["Remarks"].Replace("\"", "");
        }
        private void sysinilesen(string filepath)
        {
            SettingsJB3 = new rbtools.IniFile(filepath + "\\System.ini");
            splineID = SettingsJB3["Track"]["Id_Code"].Replace("\"", "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\" + "path.txt"))
            {
                if (!this.tabControl1.TabPages.Contains(tabPage3))
                {
                    this.tabControl1.TabPages.Add(this.tabPage3);
                    label1115.Visible = false;
                }
            }
            else
            {
                if (this.tabControl1.TabPages.Contains(tabPage3))
                {
                    this.tabControl1.TabPages.Remove(this.tabPage3);
                    label1115.Text = UpdateText.T("Path.txt fehlt.", "Path.txt not found.", "Path.txt introuvable.", "Path.txt niet gevonden.");
                }
            }

            if (File.Exists(Application.StartupPath + "\\" + "SplineID.txt"))
            {
                if (!this.tabControl1.TabPages.Contains(tabPage6))
                {
                    this.tabControl1.TabPages.Add(this.tabPage6);
                    label1116.Visible = false;
                }
            }
            else
            {
                if (this.tabControl1.TabPages.Contains(tabPage6))
                {
                    this.tabControl1.TabPages.Remove(this.tabPage6);
                    label1116.Text = UpdateText.T("SplineID.txt fehlt.", "SplineID.txt not found.", "SplineID.txt introuvable.", "SplineID.txt niet gevonden.");
                }
            }


            if (File.Exists(Application.StartupPath + "\\" + "info.txt"))
            {
                wt1.Text = File.ReadAllText(Application.StartupPath + "\\" + "info.txt", Encoding.UTF8);
            }
            else
            {
                wt1.Text = UpdateText.T("Info.txt fehlt.", "Info.txt not found.", "Info.txt introuvable.", "Info.txt niet gevonden.");
                label1117.Text = wt1.Text;
            }
            if (Properties.Settings.Default.alternative == true)
            {
                pfadInListeToolStripMenuItem.Enabled = false;
                pfadAufStandardToolStripMenuItem.Enabled = true;
                zuArbeitsbereichToolStripMenuItem.Enabled = false;
            }
            else
            {
                pfadInListeToolStripMenuItem.Enabled = true;
                pfadAufStandardToolStripMenuItem.Enabled = false;
                zuArbeitsbereichToolStripMenuItem.Enabled = true;
            }
            if (System.IO.File.Exists(Application.StartupPath + "\\" + "pdup_settings.xml"))
            {
                label1.Text = " ";
                label2.Text = lb2 + " : " + Properties.Settings.Default.pathNos;
                Properties.Settings.Default.homenos = Properties.Settings.Default.pathNos.Replace("\\" + "Projects", "");
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.backup2))

                {

                    Properties.Settings.Default.backup = Path.Combine(Properties.Settings.Default.backup2, "Backup");

                    Properties.Settings.Default.user_backup = Path.Combine(Properties.Settings.Default.backup2, "User_Backup");

                }
                EnsurePathExists(Properties.Settings.Default.backup);
                EnsurePathExists(Properties.Settings.Default.user_backup);
                Properties.Settings.Default.Save();
            }
            else
            {
                label1.Text = lb1_h;

                using (options dlg = new options())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        directoryTreeViewOnDemand1.BeginInit();
                        directoryTreeViewOnDemand1.EndInit();
                        Properties.Settings.Default.homenos = Properties.Settings.Default.pathNos.Replace("\\" + "Projects", "");
                        if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.backup2))

                        {

                            Properties.Settings.Default.backup = Path.Combine(Properties.Settings.Default.backup2, "Backup");

                            Properties.Settings.Default.user_backup = Path.Combine(Properties.Settings.Default.backup2, "User_Backup");

                        }
                        EnsurePathExists(Properties.Settings.Default.backup);
                        EnsurePathExists(Properties.Settings.Default.user_backup);
                        Properties.Settings.Default.Save();
                        if (Properties.Settings.Default.delfkt == true)
                        {
                            label4.Visible = true;
                            toolStripMenuItem5.Enabled = true;
                        }
                        if (Properties.Settings.Default.delfkt == false)
                        {
                            label4.Visible = false;
                            toolStripMenuItem5.Enabled = false;
                        }
                    }
                }

                directoryTreeViewOnDemand1.BeginInit();
                directoryTreeViewOnDemand1.EndInit();

            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            if (Directory.Exists(Properties.Settings.Default.pathNosDup))
            {
                Process.Start("explorer.exe", Properties.Settings.Default.pathNosDup);
                
            }

        }
        private void dirlesen(string filepath)
        {
            var directoryInfo = new DirectoryInfo(filepath);
            foreach (FileSystemInfo file in directoryInfo.GetFiles(@"*.ini"))
            {
                listView1.Items.Add(file.Name);
            }

            foreach (FileSystemInfo file in directoryInfo.GetFiles(@"*.prj"))
            {
                listView1.Items.Add(file.Name);
            }

            foreach (FileSystemInfo file in directoryInfo.GetFiles(@"*.mdl"))
            {
                listView1.Items.Add(file.Name);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.set_b = true;
            editor ed = new editor();
            if (File.Exists(Properties.Settings.Default.pathNosDup + "\\" + "system.ini"))
            {
                ed.ShowDialog();
                if (ed.Label1Pub == "yes")
                {
                    directoryTreeViewOnDemand1.BeginInit();
                    directoryTreeViewOnDemand1.EndInit();
                }
            }
            else
            {
                MessageBox.Show(ml1, msgb1, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.set_b = false;
            editor ed = new editor();
            if (File.Exists(Properties.Settings.Default.pathNosDup + "\\" + "system.ini"))
            {
                ed.ShowDialog();
                if (ed.Label1Pub == "yes")
                {
                    directoryTreeViewOnDemand1.BeginInit();
                    directoryTreeViewOnDemand1.EndInit();
                }
            }
            else
            {
                MessageBox.Show(ml1, msgb1, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            directoryTreeViewOnDemand1.BeginInit();
            directoryTreeViewOnDemand1.EndInit();
        }

        private void hNSplineIDListeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabPage2 == tabControl1.SelectedTab)
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.user_backup) == true)
                {
                    // True.
                }
                else
                {
                    dataGridView3.Rows.Clear();
                    dataGridView3.Refresh();
                    
                    testclaudia();
                }
            }
            else if (tabPage5 == tabControl1.SelectedTab)
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.backup) == true)
                {
                    // True.
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    testuwe();
                }
            }
            else if (tabPage4 == tabControl1.SelectedTab)
            {
                //wt1.SelectionStart = wt1.Text.Length;
                //wt1.ScrollToCaret();
            }
        }

        #region Assemblyattributaccessoren

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1 & e.ColumnIndex > -1))
            {
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    MessageBox.Show(ml2);
                }
                else
                {
                    string message = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string text22 = message;
                    string caption = ml3;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(@text22);
                        dataGridView2.Rows.Clear();
                        dataGridView2.Refresh();
                        testuwe();

                    }
                }
            }
        }

        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (e.RowIndex > -1 & e.ColumnIndex > -1))
            {
                dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                if (dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    MessageBox.Show(ml2);
                }
                else
                {
                    string message = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string text22 = message;
                    string caption = ml4;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(@text22);
                        dataGridView3.Rows.Clear();
                        dataGridView3.Refresh();
                        testclaudia();

                    }
                }
            }
        }

        private void testuwe()
        {
            foreach (FileInfo file in new DirectoryInfo(Properties.Settings.Default.backup).GetFiles("*.zip", System.IO.SearchOption.AllDirectories))
            {
                this.dataGridView1.Rows.Add((object)(file.FullName));
            }
        }

        private void testclaudia()
        {
            foreach (FileInfo file in new DirectoryInfo(Properties.Settings.Default.user_backup).GetFiles("*.zip", System.IO.SearchOption.AllDirectories))
            {
                this.dataGridView3.Rows.Add((object)(file.FullName));
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close2_h;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.minimize;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.minimize_h;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.config;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.config_h;
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.pathNosDup + "\\" + "system.ini"))
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icons = MessageBoxIcon.Question;
                string message = Properties.Settings.Default.pathNosDup;
                string text22 = message;
                string caption = ml5;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, icons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    FileSystem.DeleteDirectory(Properties.Settings.Default.pathNosDup, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
                    //DeleteDirectory(Properties.Settings.Default.pathNosDup, true, true);
                    directoryTreeViewOnDemand1.BeginInit();
                    directoryTreeViewOnDemand1.EndInit();
                }
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icons = MessageBoxIcon.Error;
                string message = Properties.Settings.Default.pathNosDup;
                string text22 = message;
                string caption = ml6;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, icons);
            }
        }



        public static void DeleteAllSubfolders(string directoryPath)
        {
            foreach (string fileName in System.IO.Directory.GetFiles(directoryPath))
            {
                try
                {
                    System.IO.File.Delete(fileName);
                }
                catch
                {

                }
            }
            foreach (string directoryName in System.IO.Directory.GetDirectories(directoryPath))
            {
                DeleteAllSubfolders(directoryName);
                try
                {
                    System.IO.Directory.Delete(directoryName, true);
                }
                catch
                {

                }
            }
        }

        public static string DeleteDirectory(string directoryPath, bool recursiv, bool deleteFiles)
        {
            string result = _operationFailed;
            if (System.IO.Directory.Exists(directoryPath))
            {
                if (recursiv == false && deleteFiles == false)
                {
                    System.IO.Directory.Delete(directoryPath, false);

                    if (System.IO.Directory.Exists(directoryPath))
                    {
                        result = _operationDirNotEmpty;
                    }
                    else
                    {
                        result = _operationSuccess;
                    }
                }

                if (recursiv == true && deleteFiles == false)
                {
                    System.IO.Directory.Delete(directoryPath, true);

                    if (System.IO.Directory.Exists(directoryPath))
                    {
                        result = _operationDirNotEmpty;
                    }
                    else
                    {
                        result = _operationSuccess;
                    }
                }

                if (recursiv == true && deleteFiles == true)
                {
                    System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(directoryPath);

                    DeleteAllSubfolders(directoryPath);

                    System.IO.Directory.Delete(directoryPath, true);

                    if (System.IO.Directory.Exists(directoryPath))
                    {
                        result = _operationDirNotEmpty;
                    }
                    else
                    {
                        result = _operationSuccess;
                    }
                }

                if (recursiv == false && deleteFiles == true)
                {

                    foreach (string fileName in System.IO.Directory.GetFiles(directoryPath))
                    {
                        try
                        {
                            System.IO.File.Delete(fileName);
                        }
                        catch
                        {

                        }
                    }

                    System.IO.Directory.Delete(directoryPath, false);

                    if (System.IO.Directory.Exists(directoryPath))
                    {
                        result = _operationDirNotEmpty;
                    }
                    else
                    {
                        result = _operationSuccess;
                    }
                }

            }
            else
            {
                result = _operationDirNotExist;
            }
            return result;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (options dlg = new options())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    directoryTreeViewOnDemand1.BeginInit();
                    directoryTreeViewOnDemand1.EndInit();

                    label16.Text = Properties.Settings.Default.backup2;
                    //label16.Text.Trim().EndsWith(@"\");
                    if (label16.Text.EndsWith(@"\"))
                    {
                        label17.Text = Properties.Settings.Default.backup = label16.Text + "Backup";
                        label18.Text = Properties.Settings.Default.user_backup = label16.Text + "User_Backup";
                    }
                    else
                    {
                    label17.Text = Properties.Settings.Default.backup = label16.Text + @"\" + "Backup";
                    label18.Text = Properties.Settings.Default.user_backup = label16.Text + @"\" + "User_Backup";
                    }

                    EnsurePathExists(Properties.Settings.Default.backup);
                    EnsurePathExists(Properties.Settings.Default.user_backup);
                    Properties.Settings.Default.Save();
                    if (Properties.Settings.Default.delfkt == true)
                    {
                        label4.Visible = true;
                        toolStripMenuItem5.Enabled = true;
                    }
                    if (Properties.Settings.Default.delfkt == false)
                    {
                        label4.Visible = false;
                        toolStripMenuItem5.Enabled = false;
                    }
                }
            }

        }

        private void userBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string backupset2 = Settings.Default.pathNosDup.Substring(Settings.Default.pathNosDup.LastIndexOf('\\')).Replace("\\", "");
            string zipPath = Settings.Default.user_backup + "\\" + "snapshot_" + backupset2 + "-" + DateTime.Now.ToString("MM_dd_yyyy_HH-mm") + ".zip";
            System.IO.Compression.ZipFile.CreateFromDirectory(Settings.Default.pathNosDup, zipPath, CompressionLevel.Optimal, true);
            MessageBox.Show(zipPath + ml7);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("de");
            getRes(ci);

            Properties.Settings.Default.country2 = "de";
            Properties.Settings.Default.Save();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en");
            getRes(ci);

            Properties.Settings.Default.country2 = "en";
            Properties.Settings.Default.Save();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("fr");
            getRes(ci);

            Properties.Settings.Default.country2 = "fr";
            Properties.Settings.Default.Save();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("nl");
            getRes(ci);
            Properties.Settings.Default.country2 = "nl";
            Properties.Settings.Default.Save();
        }

        private void getRes(CultureInfo ci)
        {
            ResourceManager rm = new ResourceManager("Projektduplicator_2017.langres", typeof(Form1).Assembly);
            tabPage1.Text = rm.GetString("tabPage1.Text", ci);
            tabPage2.Text = rm.GetString("tabPage2.Text", ci);
            tabPage4.Text = rm.GetString("tabPage4.Text", ci);
            tabPage5.Text = rm.GetString("tabPage5.Text", ci);
            lb1 = rm.GetString("label1.Text", ci);
            label4.Text = rm.GetString("label4.Text", ci);
            label6.Text = rm.GetString("label6.Text", ci);
            toolStripLabel1.Text = rm.GetString("toolStripLabel1.Text", ci);
            toolStripLabel2.Text = rm.GetString("toolStripLabel2.Text", ci);
            dataGridViewTextBoxColumn1.HeaderText = rm.GetString("dataGridViewTextBoxColumn1.HeaderText", ci);
            dataGridViewTextBoxColumn2.HeaderText = rm.GetString("dataGridViewTextBoxColumn2.HeaderText", ci);

            toolStripMenuItem1.Text = rm.GetString("toolStripMenuItem1.Text", ci);
            toolStripMenuItem2.Text = rm.GetString("toolStripMenuItem2.Text", ci);
            toolStripMenuItem3.Text = rm.GetString("toolStripMenuItem3.Text", ci);
            toolStripMenuItem4.Text = rm.GetString("toolStripMenuItem4.Text", ci);
            toolStripMenuItem5.Text = rm.GetString("toolStripMenuItem5.Text", ci);

            toolTip1.SetToolTip(pictureBox1, rm.GetString("pictureBox1.tt", ci));
            toolTip1.SetToolTip(pictureBox2, rm.GetString("pictureBox2.tt", ci));
            toolTip1.SetToolTip(pictureBox3, rm.GetString("pictureBox3.tt", ci));
            toolTip1.SetToolTip(pictureBox5, rm.GetString("pictureBox5.tt", ci));
            toolTip1.SetToolTip(pictureBox6, rm.GetString("pictureBox6.tt", ci));
            toolTip1.SetToolTip(pictureBox7, rm.GetString("pictureBox7.tt", ci));
            toolTip1.SetToolTip(pictureBox8, rm.GetString("pictureBox8.tt", ci));
            a1 = rm.GetString("a1.Text", ci);
            o1 = rm.GetString("o1.Text", ci);
            b1 = rm.GetString("b1.Text", ci);
            r1 = rm.GetString("r1.Text", ci);
            m01 = rm.GetString("m01.Text", ci);
            m001 = rm.GetString("m001", ci);
            m002 = rm.GetString("m002", ci);
            m003 = rm.GetString("m003", ci);
            m1 = rm.GetString("m1.Text", ci);
            m2 = rm.GetString("m2.Text", ci);
            m3 = rm.GetString("m3.Text", ci);
            m4 = rm.GetString("m4.Text", ci);
            d1 = rm.GetString("d1.Text", ci);
            d2 = rm.GetString("d2.Text", ci);
            d3 = rm.GetString("d3.Text", ci);
            d4 = rm.GetString("d4.Text", ci);
            p1 = rm.GetString("p1.Text", ci);
            p2 = rm.GetString("p2.Text", ci);
            p3 = rm.GetString("p3.Text", ci);
            p4 = rm.GetString("p4.Text", ci);
            lb1_h = rm.GetString("label1_h", ci);
            lb2 = rm.GetString("label2.Text", ci);
            ml1 = rm.GetString("mldg1", ci);
            ml2 = rm.GetString("mldg2", ci);
            ml3 = rm.GetString("mldg3", ci);
            ml4 = rm.GetString("mldg4", ci);
            ml5 = rm.GetString("mldg5", ci);
            ml6 = rm.GetString("mldg6", ci);
            ml7 = rm.GetString("mldg7", ci);

            mlu1 = rm.GetString("mldg1_up", ci);
            mlu2 = rm.GetString("mldg2_up", ci);
            mlu3 = rm.GetString("mldg3_up", ci);
            mlu4 = rm.GetString("mldg4_up", ci);
            msgb1 = rm.GetString("msgbox1", ci);
            label8.Text = rm.GetString("label8.Text", ci);
            pfadInListeToolStripMenuItem.Text = rm.GetString("cm_1", ci);
            pfadAufStandardToolStripMenuItem.Text = rm.GetString("cm_2", ci);
            zuArbeitsbereichToolStripMenuItem.Text = rm.GetString("cm_3", ci);
            opmenu1.Text = rm.GetString("mn1_1", ci);
            svmenu1.Text = rm.GetString("mn1_2", ci);
            opmenu2.Text = rm.GetString("mn2_1", ci);
            svmenu2.Text = rm.GetString("mn2_2", ci);
            undomn1.Text = undomn2.Text = rm.GetString("mnedit_1", ci);
            redomn1.Text = redomn2.Text = rm.GetString("mnedit_2", ci);
            cutmn1.Text = cutmn2.Text = rm.GetString("mnedit_3", ci);
            copymn1.Text = copymn2.Text = rm.GetString("mnedit_4", ci);
            pastemn1.Text = pastemn2.Text = rm.GetString("mnedit_5", ci);
            select1.Text = select2.Text = rm.GetString("mnedit_6", ci);
            prnprev1.Text = prnprev2.Text = rm.GetString("mnedit_9", ci);
            pageset1.Text = pageset2.Text = rm.GetString("mnedit_8", ci);
            prtmenu1.Text = prtmenu2.Text = rm.GetString("mnedit_7", ci);
            label13.Text = rm.GetString("lb13_t", ci);
            label14.Text = rm.GetString("lb14_t", ci);
            dtmenu1.Text = dtmenu2.Text = rm.GetString("dt1_1", ci);
            dtmenu3.Text = dtmenu4.Text = rm.GetString("dt1_2", ci);
            tabPage3.Text = rm.GetString("tb3_t", ci);
            tabPage6.Text = rm.GetString("tb6_t", ci);
            Properties.Settings.Default.Save();

        }

        private void pfadAufStandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.alternative = false;
            pfadInListeToolStripMenuItem.Enabled = true;
            pfadAufStandardToolStripMenuItem.Enabled = false;
            zuArbeitsbereichToolStripMenuItem.Enabled = true;
            Settings.Default.pathNosDup_alt = Settings.Default.pathNos;
            Settings.Default.Save();
            directoryTreeViewOnDemand1.BeginInit();
            directoryTreeViewOnDemand1.EndInit();
        }


        private void pfadInListeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Settings.Default.alternative = true;
            pfadInListeToolStripMenuItem.Enabled = false;
            pfadAufStandardToolStripMenuItem.Enabled = true;
            Settings.Default.pathzwi = Settings.Default.pathNosDup;
            Settings.Default.Save();
        }

        private void zuArbeitsbereichToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.alternative = true;
            pfadInListeToolStripMenuItem.Enabled = false;
            pfadAufStandardToolStripMenuItem.Enabled = true;
            zuArbeitsbereichToolStripMenuItem.Enabled = false;
            Settings.Default.pathNosDup_alt = Settings.Default.pathzwi;
            Settings.Default.Save();
            directoryTreeViewOnDemand1.BeginInit();
            directoryTreeViewOnDemand1.EndInit();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string delta = Application.StartupPath + "\\" + "path.txt";
            richTextBox2.Clear();
            StreamReader str3 = new StreamReader(delta);
            richTextBox2.Text = str3.ReadToEnd();
            str3.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            richTextBox3.Undo();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            richTextBox3.Redo();
        }

        private void rückgängigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Undo();
        }

        private void wiederholenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Redo();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void ausschneidenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Cut();
        }

        private void kopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }

        private void einfügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Paste();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            richTextBox3.Cut();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            richTextBox3.Copy();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            richTextBox3.Paste();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            richTextBox3.SelectAll();
        }

        private void alleauswählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectAll();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            StreamReader str5 = new StreamReader(Application.StartupPath + "\\" + "SplineID.txt");
            richTextBox3.Text = str5.ReadToEnd();
            str5.Close();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(Application.StartupPath + "\\" + "SplineID.txt"))
                {
                File.Delete("SplineID.txt");
                }
            StreamWriter str6 = new StreamWriter(Application.StartupPath + "\\" + "SplineID.txt", true);
            str6.Write(richTextBox3.Text);
            str6.Close();
        }

        private void svmenu1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\" + "path.txt"))
            {
                File.Delete("path.txt");
            }
            StreamWriter str4 = new StreamWriter(Application.StartupPath + "\\" + "path.txt", true);
            str4.Write(richTextBox2.Text);
            str4.Close();
        }

        private void prtmenu1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void prtmenu2_Click(object sender, EventArgs e)
        {
            if (printDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private int linesPrinted;
        private string[] lines;

        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = richTextBox2.Print(checkPrint, richTextBox2.TextLength, e);

            // Check for more pages
            if (checkPrint < richTextBox2.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void printDocument2_BeginPrint(object sender, PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = richTextBox3.Print(checkPrint, richTextBox3.TextLength, e);

            // Check for more pages
            if (checkPrint < richTextBox3.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void druckvorschauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Size = new System.Drawing.Size(600, 800);
            printPreviewDialog2.ShowDialog();
        }

        private void seiteEinrichtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pageSetupDialog2.Document = myDocument;
            // Farbeinstellungen des Druckers auf FALSE setzen, 
            // damit die Seite nicht farbig gedruckt wird.
            pageSetupDialog2.Document.DefaultPageSettings.Color = false;
            pageSetupDialog2.ShowDialog();
        }

        private void prnprev1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Size = new System.Drawing.Size(600, 800);
            printPreviewDialog1.ShowDialog();
        }

        private void pageset1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document.DefaultPageSettings.Color = false;
            pageSetupDialog1.ShowDialog();
        }

        private void closePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Modified)
            {
                if (File.Exists(Application.StartupPath + "\\" + "path.txt"))
                {
                    File.Delete("path.txt");
                }
                StreamWriter str4 = new StreamWriter(Application.StartupPath + "\\" + "path.txt", true);
                str4.Write(richTextBox2.Text);
                str4.Close();
                richTextBox2.SelectAll();
                richTextBox2.Clear();
            }
            else
            {
                richTextBox2.SelectAll();
                richTextBox2.Clear();
            }
        }

        private void schliessenSplineIDtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Modified)
            {
                if (File.Exists(Application.StartupPath + "\\" + "SplineID.txt"))
                {
                    File.Delete("SplineID.txt");
                }
                StreamWriter str4 = new StreamWriter(Application.StartupPath + "\\" + "SplineID.txt", true);
                str4.Write(richTextBox3.Text);
                str4.Close();
                richTextBox3.SelectAll();
                richTextBox3.Clear();

            }
            else
            {
                richTextBox3.SelectAll();
                richTextBox3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ShowGithubUpdate();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ShowGithubUpdate();
        }

        private void ShowGithubUpdate()
        {
            if (Application.OpenForms.Cast<Form>().Any(form => form != this) ||
                richTextBox2.Modified || richTextBox3.Modified)
            {
                MessageBox.Show(this, UpdateText.T(
                    "Bitte offene Editoren schließen und Änderungen an Path.txt oder SplineID.txt zuerst speichern. Einstellungen und Projekte bleiben erhalten.",
                    "Close open editors and save changes to Path.txt or SplineID.txt first. Settings and projects will be preserved.",
                    "Fermer les éditeurs et enregistrer les modifications de Path.txt ou SplineID.txt au préalable. Les paramètres et projets seront conservés.", "Sluit geopende editors en sla wijzigingen in Path.txt of SplineID.txt eerst op. Instellingen en projecten blijven behouden."));
                return;
            }
            using (var dialog = new GithubUpdateForm())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK || dialog.PreparedJob == null) return;
                try
                {
                    Properties.Settings.Default.Save();
                    var job = dialog.PreparedJob;
                    job.InstallDirectory = Application.StartupPath;
                    job.BackupDirectory = Path.Combine(Path.GetDirectoryName(job.ZipPath), "backup");
                    job.Language = Properties.Settings.Default.country2;
                    using (var process = Process.GetCurrentProcess())
                    {
                        job.ProcessId = process.Id;
                        job.ProcessStartTicks = process.StartTime.ToUniversalTime().Ticks;
                    }
                    string directory = Path.GetDirectoryName(job.ZipPath);
                    string settings = Path.Combine(Application.StartupPath, "pdup_settings.xml");
                    if (File.Exists(settings)) File.Copy(settings, Path.Combine(directory, "pdup_settings.xml"));
                    string helper = Path.Combine(directory, "Projektduplicator.Updater.exe");
                    File.Copy(Path.Combine(Application.StartupPath, "Projektduplicator.Updater.exe"), helper);
                    string jobFile = Path.Combine(directory, "job.json");
                    UpdateCore.WriteJob(jobFile, job);
                    Process.Start(new ProcessStartInfo(helper, "\"" + jobFile + "\"") { UseShellExecute = true });
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, UpdateText.T("Installation konnte nicht gestartet werden. Die Anwendung bleibt geöffnet.",
                        "Could not start installation. The application remains open.",
                        "Impossible de démarrer l’installation. Le programme reste ouvert.", "De installatie kon niet worden gestart. Het programma blijft geopend."));
                }
            }
        }
    }
}


