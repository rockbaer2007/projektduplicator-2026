
using rbtools;
using System;
using System.IO;
using System.Windows.Forms;
using Projektduplicator_2017.Properties;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Linq;
using System.IO.Compression;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;

namespace Projektduplicator_2017
{
    public partial class editor : Form
    {
        #region variablen setzen
        private string str;
        private string mldg;
        private string mldg2;
        private string mldg3;
        private string fileName;
        private string directoryName;
        private string directoryName2;
        private IniFile SettingsJB;
        private IniFile SettingsJB2;
        private IniFile SettingsJB3;
        private IniFile SettingsJB4;
        private IniFile SettingsJB5;
        private IniFile SettingsJB6;
        private string zwi234;
        private string backupset;
        string NL = Environment.NewLine;
        private string message;
        private string caption;
        private string a1;
        private string o1;
        private string b1;
        private string r1;
        private string m01;
        private string m1;
        private string m2;
        private string m3;
        private string m4;
        private string d1;
        private string d2;
        private string d3;
        private string d4;
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string k1;
        private string oh1;
        private string hw1;
        private string hw2;
        private string t1;
        private string t2;
        private string bt1;
        private string bt2;
        private string bt3;
        private string bt4;
        private string btn12;
        private string lb72;
        private string tssl1;
        private string tssl2;
        private string tssl3;
        private string bt5;
        private string bt6;
        private string inf1;
        private string tabP1;
        private string tabP2;
        private string tabP3;
        private string tabP4;
        private string tabP5;
        private string lb101;
        private string lb77;
        private string lb82;
        private string lb86;
        private string gb1;
        private string gb2;
        private string rb1;
        private string rb2;
        private string cb1;
        private string cb3;
        private string lb79;
        private string lb75;
        private string edml1;
        private string edml2;
        private string edml3;
        private string edml4;
        private string edml5;
        private string edml6;
        private string edml7;
        private string edml8;
        private string edml9;
        private string edml10;
        private string edml11;
        private string inf2;
        private string spmsg1;
        private string spmsg2;
        private string spmsg3;
        private string spmsg4;
        private string spmsg5;
        private string edml12;
        private string lb44;
        private string btnadd;
        //private string in1;
        //private string in2;
        //private string in3;
        //private string in4;
        private string in5;
        private string in6;
        private string in7;
        private string in8;
        private string in9;
        private string in10;
        private string in11;
        private string in12;
        private string in13;
        private string in14;
        private string in15;
        private string in16;
        private string in17;
        private string in18;
        private string in19;
        private string in20;
        private string in31;
        private string in32;
        private string in33;
        private string in34;
        private string in35;
        private string in36;
        private string in37;
        private string in38;
        private string in39;
        private string in40;
        private string in41;
        private string in42;
        private string in43;
        private string in44;
        private string in45;
        private string in46;
        private string in47;
        private string in21;
        private string in22;
        private string in23;
        private string in24;
        private string in25;
        private string in26;
        private string in27;
        private string in28;
        private string in29;
        private string in30;
        private string exteep;

        #endregion

        private readonly Func<string, string, string, string> translateText;

        public editor() : this(Translate) { }

        internal editor(Func<string, string, string, string> translator)
        {
            translateText = translator ?? throw new ArgumentNullException(nameof(translator));
            InitializeComponent();
            label47.Text = "no";
            label74.Text = Properties.Settings.Default.id_code;

            if (Properties.Settings.Default.country2 == "de")
            {
                CultureInfo ci = new CultureInfo("de");
                getRes(ci);
                getRes2(ci);
            }
            else if (Properties.Settings.Default.country2 == "en")
            {
                CultureInfo ci = new CultureInfo("en");
                getRes(ci);
                getRes2(ci);
            }
            else if (Properties.Settings.Default.country2 == "fr")
            {
                CultureInfo ci = new CultureInfo("fr");
                getRes(ci);
                getRes2(ci);
            }
            else if (Properties.Settings.Default.country2 == "nl")
            {
                CultureInfo ci = new CultureInfo("nl");
                getRes(ci);
                getRes2(ci);
            }

            if (Properties.Settings.Default.set_b == true)
            {
                this.Text = t1;
                button1.Text = bt1;
                button2.Text = bt2;
                button7.Text = button8.Text = button9.Text = button10.Text = bt4;
                tb1.Enabled = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;

            }
            else
            {
                this.Text = t2;
                button1.Text = bt3;
                button2.Text = bt2;
                tb1.Enabled = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            ApplyEditorLabels();
            //this.tabPage4.ToolTipText = "Auflistung alle in den HN-Projekten verwendeten Spline-ID´s";
            //this.tabPage5.ToolTipText = "Splineliste mit den dem Kon zugeteilten Spline ID´s anzeigen";
            
        }
        private void ApplyEditorLabels()
        {
            label2.Text = m1;
            label3.Text = m2;
            label4.Text = m3;
            label5.Text = m4;
            label6.Text = d1;
            label7.Text = d2;
            label8.Text = d3;
            label9.Text = d4;
            label10.Text = a1;
            label11.Text = o1;
            label12.Text = b1;
            label13.Text = r1;
            label14.Text = k1;
            label16.Text = p1;
            label17.Text = p2;
            label18.Text = p3;
            label19.Text = p4;
            label83.Text = oh1;
            label72.Text = lb72;
            label101.Text = lb101;
            label82.Text = lb82;
            label1186.Text = lb86;
            button3.Text = bt5;
            button11.Text = bt6;
            tabPage1.Text = tabP1;
            tabPage2.Text = tabP2;
            tabPage3.Text = tabP3;
            tabPage4.Text = tabP4;
            tabPage5.Text = tabP5;
            label77.Text = lb77;
            groupBox1.Text = gb1;
            radioButton1.Text = rb1;
            radioButton2.Text = rb2;
            checkBox1.Text = cb1;
            checkBox3.Text = cb3;
            label79.Text = lb79;
            label75.Text = lb75;
            label44.Text = lb44;
            btnadd_path.Text = btnadd;
        }

        #region language resourcen lesen
        private void getRes(CultureInfo ci)
        {
            ResourceManager rm = new ResourceManager("Projektduplicator_2017.langres", typeof(Form1).Assembly);
            a1 = rm.GetString("a1.Text", ci);
            o1 = rm.GetString("o1.Text", ci);
            b1 = rm.GetString("b1.Text", ci);
            r1 = rm.GetString("r1.Text", ci);
            m01 = rm.GetString("m01.Text", ci);
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
            k1 = rm.GetString("label4.Text_option", ci);
            oh1 = rm.GetString("m01.Text", ci);
            hw1 = rm.GetString("edverweis1", ci);
            hw2 = rm.GetString("edverweis2", ci);
            t1 = rm.GetString("ed_t1", ci);
            t2 = rm.GetString("ed_t2", ci);
            bt1 = rm.GetString("ed_b1", ci);
            bt2 = rm.GetString("ed_b2", ci);
            bt3 = rm.GetString("ed_b22", ci);
            bt4 = rm.GetString("ed_saerch", ci);
            btn12 = rm.GetString("btn12.Text", ci);
            lb72 = rm.GetString("ed_lb72", ci);
            tssl1 = rm.GetString("ed_i", ci);
            tssl2 = rm.GetString("ed_in", ci);
            tssl3 = rm.GetString("ed_no", ci);
            bt5 = rm.GetString("ed_tb3", ci);
            bt6 = rm.GetString("ed_bt11", ci);
            inf1 = rm.GetString("ed_info1", ci);
            inf2 = rm.GetString("ed_info2", ci);
            tabP1 = rm.GetString("tabP1", ci);
            tabP2 = rm.GetString("tabP2", ci);
            tabP3 = rm.GetString("tabP3", ci);
            tabP4 = rm.GetString("tabP4", ci);
            tabP5 = rm.GetString("tabP5", ci);
            lb101 = rm.GetString("ed_lb101", ci);
            lb77 = rm.GetString("ed_lb77", ci);
            gb1 = rm.GetString("ed_gb1", ci);
            gb2 = rm.GetString("ed_gb2", ci);
            rb1 = rm.GetString("ed_rb1", ci);
            rb2 = rm.GetString("ed_rb2", ci);
            cb1 = rm.GetString("ed_cb1", ci);
            cb3 = rm.GetString("ed_cb3", ci);
            lb75 = rm.GetString("ed_lb75", ci);
            lb79 = rm.GetString("ed_lb79", ci);
            edml1 = rm.GetString("ed_mldg1", ci);
            edml2 = rm.GetString("ed_mldg2", ci);
            edml3 = rm.GetString("ed_mldg3", ci);
            edml4 = rm.GetString("ed_mldg4", ci);
            edml5 = rm.GetString("ed_mldg5", ci);
            edml6 = rm.GetString("ed_mldg6", ci);
            edml7 = rm.GetString("ed_mldg7", ci);
            edml8 = rm.GetString("ed_mldg8", ci);
            edml9 = rm.GetString("ed_komsg1", ci);
            edml10 = rm.GetString("ed_komsg2", ci);
            edml11 = rm.GetString("ed_komsg3", ci);
            spmsg1 = rm.GetString("ed_spmsg1", ci);
            spmsg2 = rm.GetString("ed_spmsg2", ci);
            spmsg3 = rm.GetString("ed_spmsg3", ci);
            spmsg4 = rm.GetString("ed_spmsg4", ci);
            spmsg5 = rm.GetString("ed_spmsg5", ci);
            edml12 = rm.GetString("ed_kommsg1", ci);
            lb44 = rm.GetString("label44.Text", ci);
            lb82 = rm.GetString("label82.Text", ci);
            lb86 = rm.GetString("label86.Text", ci);
            btnadd = rm.GetString("btnadd_path.Text", ci);
            label22.Text = rm.GetString("ed_lb26", ci);
            tb7.WaterMarkText = tb3.WaterMarkText = rm.GetString("wmtext1", ci);
            tb1a.WaterMarkText = rm.GetString("wmtext2", ci);
            tb14.WaterMarkText = rm.GetString("wmtext3", ci);
            comboBox1.Text = rm.GetString("selexp", ci);
            Properties.Settings.Default.Save();
        
        }
        #endregion

        ResourceManager rm2 = new ResourceManager("Projektduplicator_2017.iconres", typeof(Form1).Assembly);
        //private string i1;
        private string in48;
        private string in49;
        private string in50;
        private string in51;
        private string in52;
        private string in53;
        private string in54;
        private string in55;
        private string in56;
        private string in57;
        private string in58;
        private string in59;
        private string in60;
        private string in61;
        private string in62;
        private string in63;
        private string in64;
        private string in65;
        private string in66;
        private string in67;
        private string in68;
        private string in69;
        private string in70;
        private string in71;
        private string in72;
        private string in73;
        private string in74;
        private string in75;
        private string in76;
        private string in77;
        private string in78;
        private string in79;
        private string in80;
        private string in81;
        private string in82;
        private string in83;
        private string in84;
        private string in85;
        private string in86;
        private string in87;
        private string in88;
        private string in89;
        private string in90;
        private string in91;
        private string in92;
        private string in93;
        private string in94;
        private string in95;
        private string in96;
        private string in97;
        private string in98;
        private string in99;
        private string in100;
        private string in101;
        private string in102;
        private string in103;
        private string in104;
        private string in105;
        private string in106;
        private string in107;
        private string in108;
        private string in109;
        private string in110;
        private string in111;
        private string in112;
        private string in113;
        private string in114;
        private string in115;
        private string in116;
        private string in117;
        private string in118;
        private string in119;
        private string in120;
        private string in121;
        private string in122;
        private string in123;
        private string in124;
        private string in125;
        private string in126;
        private string in127;
        private string in128;
        private string in129;
        private string in130;
        private string in131;
        private string in132;
        private string in133;
        private string in134;
        private string in135;
        private string in136;
        private string in137;
        private string in138;
        private string in139;
        private string in140;
        private string in141;
        private string in142;
        private string in143;
        private string in144;
        private string in145;
        private string in146;
        private string in147;
        private string in148;
        private string in149;
        private string in150;
        private string in151;
        private string in152;
        private string in153;
        private string in154;

        #region icon resourcen einlesen
        private void getRes2(CultureInfo ci)
        {
            
            label23.Text = rm2.GetString("country24", ci);
            label24.Text = rm2.GetString("country25", ci);
            label25.Text = rm2.GetString("country26", ci);
            label26.Text = rm2.GetString("country27", ci);
            label27.Text = rm2.GetString("country28", ci);
            label28.Text = rm2.GetString("country29", ci);
            label29.Text = rm2.GetString("country30", ci);
            label30.Text = rm2.GetString("country32", ci);
            label31.Text = rm2.GetString("country33", ci);
            label32.Text = rm2.GetString("country34", ci);
            label33.Text = rm2.GetString("country35", ci);
            label34.Text = rm2.GetString("country36", ci);
            label35.Text = rm2.GetString("country37", ci);
            label36.Text = rm2.GetString("country38", ci);
            label37.Text = rm2.GetString("country39", ci);
            label38.Text = rm2.GetString("country40", ci);
            label39.Text = rm2.GetString("country41", ci);
            label40.Text = rm2.GetString("country12", ci);
            label41.Text = rm2.GetString("country31", ci);
            label42.Text = rm2.GetString("country42", ci);
            label43.Text = rm2.GetString("country43", ci);
            //label44.Text = rm2.GetString("country43", ci);
            label45.Text = rm2.GetString("country44", ci);
            label46.Text = rm2.GetString("country45", ci);
            //label47.Text = rm2.GetString("country32", ci);
            label48.Text = rm2.GetString("country23", ci);
            label49.Text = rm2.GetString("country22", ci);

            label50.Text = rm2.GetString("country21", ci);
            label51.Text = rm2.GetString("country20", ci);
            label52.Text = rm2.GetString("country19", ci);
            label53.Text = rm2.GetString("country18", ci);
            label54.Text = rm2.GetString("country17", ci);
            label55.Text = rm2.GetString("country16", ci);
            label56.Text = rm2.GetString("country15", ci);
            label57.Text = rm2.GetString("country14", ci);
            label58.Text = rm2.GetString("country13", ci);
            label59.Text = rm2.GetString("country11", ci);

            label60.Text = rm2.GetString("country10", ci);
            label61.Text = rm2.GetString("country9", ci);
            label62.Text = rm2.GetString("country8", ci);
            label63.Text = rm2.GetString("country7", ci);
            label64.Text = rm2.GetString("country6", ci);
            label65.Text = rm2.GetString("country5", ci);
            label66.Text = rm2.GetString("country4", ci);
            label67.Text = rm2.GetString("country3", ci);
            label68.Text = rm2.GetString("country2", ci);
            label69.Text = rm2.GetString("country1", ci);


            in5 = rm2.GetString("i5", ci);
            in6 = rm2.GetString("i6", ci);
            in7 = rm2.GetString("i7", ci);
            in8 = rm2.GetString("i8", ci);
            in9 = rm2.GetString("i9", ci);
            in10 = rm2.GetString("i10", ci);

            in11 = rm2.GetString("i11", ci);
            in12 = rm2.GetString("i12", ci);
            in13 = rm2.GetString("i13", ci);
            in14 = rm2.GetString("i14", ci);
            in15 = rm2.GetString("i15", ci);
            in16 = rm2.GetString("i16", ci);
            in17 = rm2.GetString("i17", ci);
            in18 = rm2.GetString("i18", ci);
            in19 = rm2.GetString("i19", ci);
            in20 = rm2.GetString("i20", ci);

            in21 = rm2.GetString("i21", ci);
            in22 = rm2.GetString("i22", ci);
            in23 = rm2.GetString("i23", ci);
            in24 = rm2.GetString("i24", ci);
            in25 = rm2.GetString("i25", ci);
            in26 = rm2.GetString("i26", ci);
            in27 = rm2.GetString("i27", ci);
            in28 = rm2.GetString("i28", ci);
            in29 = rm2.GetString("i29", ci);
            in30 = rm2.GetString("i30", ci);

            in31 = rm2.GetString("i31", ci);
            in32 = rm2.GetString("i32", ci);
            in33 = rm2.GetString("i33", ci);
            in34 = rm2.GetString("i34", ci);
            in35 = rm2.GetString("i35", ci);
            in36 = rm2.GetString("i36", ci);
            in37 = rm2.GetString("i37", ci);
            in38 = rm2.GetString("i38", ci);
            in39 = rm2.GetString("i39", ci);
            in40 = rm2.GetString("i40", ci);

            in41 = rm2.GetString("i41", ci);
            in42 = rm2.GetString("i42", ci);
            in43 = rm2.GetString("i43", ci);
            in44 = rm2.GetString("i44", ci);
            in45 = rm2.GetString("i45", ci);
            in46 = rm2.GetString("i46", ci);
            in47 = rm2.GetString("i47", ci);
            in48 = rm2.GetString("i48", ci);
            in49 = rm2.GetString("i49", ci);
            in50 = rm2.GetString("i50", ci);

            in51 = rm2.GetString("i51", ci);
            in52 = rm2.GetString("i52", ci);
            in53 = rm2.GetString("i53", ci);
            in54 = rm2.GetString("i54", ci);
            in55 = rm2.GetString("i55", ci);
            in56 = rm2.GetString("i56", ci);
            in57 = rm2.GetString("i57", ci);
            in58 = rm2.GetString("i58", ci);
            in59 = rm2.GetString("i59", ci);
            in60 = rm2.GetString("i60", ci);

            in61 = rm2.GetString("i61", ci);
            in62 = rm2.GetString("i62", ci);
            in63 = rm2.GetString("i63", ci);
            in64 = rm2.GetString("i64", ci);
            in65 = rm2.GetString("i65", ci);
            in66 = rm2.GetString("i66", ci);
            in67 = rm2.GetString("i67", ci);
            in68 = rm2.GetString("i68", ci);
            in69 = rm2.GetString("i69", ci);
            in70 = rm2.GetString("i70", ci);

            in71 = rm2.GetString("i71", ci);
            in72 = rm2.GetString("i72", ci);
            in73 = rm2.GetString("i73", ci);
            in74 = rm2.GetString("i74", ci);
            in75 = rm2.GetString("i75", ci);
            in76 = rm2.GetString("i76", ci);
            in77 = rm2.GetString("i77", ci);
            in78 = rm2.GetString("i78", ci);
            in79 = rm2.GetString("i79", ci);
            in80 = rm2.GetString("i80", ci);

            in81 = rm2.GetString("i81", ci);
            in82 = rm2.GetString("i82", ci);
            in83 = rm2.GetString("i83", ci);
            in84 = rm2.GetString("i84", ci);
            in85 = rm2.GetString("i85", ci);
            in86 = rm2.GetString("i86", ci);
            in87 = rm2.GetString("i87", ci);
            in88 = rm2.GetString("i88", ci);
            in89 = rm2.GetString("i89", ci);
            in90 = rm2.GetString("i90", ci);

            in91 = rm2.GetString("i91", ci);
            in92 = rm2.GetString("i92", ci);
            in93 = rm2.GetString("i93", ci);
            in94 = rm2.GetString("i94", ci);
            in95 = rm2.GetString("i95", ci);
            in96 = rm2.GetString("i96", ci);
            in97 = rm2.GetString("i97", ci);
            in98 = rm2.GetString("i98", ci);
            in99 = rm2.GetString("i99", ci);
            in100 = rm2.GetString("i100", ci);

            in101 = rm2.GetString("i101", ci);
            in102 = rm2.GetString("i102", ci);
            in103 = rm2.GetString("i103", ci);
            in104 = rm2.GetString("i104", ci);
            in105 = rm2.GetString("i105", ci);
            in106 = rm2.GetString("i106", ci);
            in107 = rm2.GetString("i107", ci);
            in108 = rm2.GetString("i108", ci);
            in109 = rm2.GetString("i109", ci);
            in110 = rm2.GetString("i110", ci);

            in101 = rm2.GetString("i101", ci);
            in102 = rm2.GetString("i102", ci);
            in103 = rm2.GetString("i103", ci);
            in104 = rm2.GetString("i104", ci);
            in105 = rm2.GetString("i105", ci);
            in106 = rm2.GetString("i106", ci);
            in107 = rm2.GetString("i107", ci);
            in108 = rm2.GetString("i108", ci);
            in109 = rm2.GetString("i109", ci);
            in110 = rm2.GetString("i110", ci);

            in111 = rm2.GetString("i111", ci);
            in112 = rm2.GetString("i112", ci);
            in113 = rm2.GetString("i113", ci);
            in114 = rm2.GetString("i114", ci);
            in115 = rm2.GetString("i115", ci);
            in116 = rm2.GetString("i116", ci);
            in117 = rm2.GetString("i117", ci);
            in118 = rm2.GetString("i118", ci);
            in119 = rm2.GetString("i119", ci);
            in120 = rm2.GetString("i120", ci);

            in121 = rm2.GetString("i121", ci);
            in122 = rm2.GetString("i122", ci);
            in123 = rm2.GetString("i123", ci);
            in124 = rm2.GetString("i124", ci);
            in125 = rm2.GetString("i125", ci);
            in126 = rm2.GetString("i126", ci);
            in127 = rm2.GetString("i127", ci);
            in128 = rm2.GetString("i128", ci);
            in129 = rm2.GetString("i129", ci);
            in130 = rm2.GetString("i130", ci);

            in131 = rm2.GetString("i131", ci);
            in132 = rm2.GetString("i132", ci);
            in133 = rm2.GetString("i133", ci);
            in134 = rm2.GetString("i134", ci);
            in135 = rm2.GetString("i135", ci);
            in136 = rm2.GetString("i136", ci);
            in137 = rm2.GetString("i137", ci);
            in138 = rm2.GetString("i138", ci);
            in139 = rm2.GetString("i139", ci);
            in140 = rm2.GetString("i140", ci);

            in141 = rm2.GetString("i141", ci);
            in142 = rm2.GetString("i142", ci);
            in143 = rm2.GetString("i143", ci);
            in144 = rm2.GetString("i144", ci);
            in145 = rm2.GetString("i145", ci);
            in146 = rm2.GetString("i146", ci);
            in147 = rm2.GetString("i147", ci);
            in148 = rm2.GetString("i148", ci);
            in149 = rm2.GetString("i149", ci);
            in150 = rm2.GetString("i150", ci);

            in151 = rm2.GetString("i151", ci);
            in152 = rm2.GetString("i152", ci);
            in153 = rm2.GetString("i153", ci);
            in154 = rm2.GetString("i154", ci);

            //Properties.Settings.Default.Save();

        }
        #endregion

        #region lesen
        private void inilesen(string filepath)
        {
            //
            //ini einlesen
            //
            string str = backupset = filepath.Substring(filepath.LastIndexOf('\\')).Replace("\\", "");
            //label2.Text = str;
            tb1.Text = str;
            SettingsJB = new rbtools.IniFile(filepath + "\\" + str + ".ini");
            //richTextBox1.Clear();
            tb19.Text = SettingsJB["FileInfo"]["Icon"].Replace("\"", "");
            tb20.Text = SettingsJB["FileInfo"]["Country"].Replace("\"", "");
            tb2.Text = SettingsJB["FileInfo"]["Name_ENG"].Replace("\"", "");
            tb3.Text = SettingsJB["FileInfo"]["Name_GER"].Replace("\"", "");
            tb4.Text = SettingsJB["FileInfo"]["Name_FRA"].Replace("\"", "");
            tb5.Text = SettingsJB["FileInfo"]["Name_POL"].Replace("\"", "");
            tb6.Text = SettingsJB["FileInfo"]["Description_ENG"].Replace("\"", "");
            tb7.Text = SettingsJB["FileInfo"]["Description_GER"].Replace("\"", "");
            tb8.Text = SettingsJB["FileInfo"]["Description_FRA"].Replace("\"", "");
            tb9.Text = SettingsJB["FileInfo"]["Description_POL"].Replace("\"", "");

            if (String.IsNullOrEmpty(Properties.Settings.Default.konkuerzel))
            {
                tb14.Text = SettingsJB["FileInfo"]["Creator_Model"].Replace("\"", "");
            }
            else
            {
                tb14.Text = Properties.Settings.Default.konkuerzel;
            }





            tb15.Text = SettingsJB["FileInfo"]["PdfDoc_ENG"].Replace("\"", "");
            tb16.Text = SettingsJB["FileInfo"]["PdfDoc_GER"].Replace("\"", "");
            tb17.Text = SettingsJB["FileInfo"]["PdfDoc_FRA"].Replace("\"", "");
            tb18.Text = SettingsJB["FileInfo"]["PdfDoc_POL"].Replace("\"", "");
            tb22.Text = SettingsJB["FileInfo"]["Creator_Original"].Replace("\"", "");
        }

        private static bool CheckCharacter(char tmp)
        {
            string pat = "_";
            int x = pat.IndexOf(tmp);
            if (pat.IndexOf(tmp) < 0)
                return false;
            else
                return true;
        }

        private void prjlesen(string filepath)
        {
            //
            // prj einlesen
            //
            string str = filepath.Substring(filepath.LastIndexOf('\\')).Replace("\\", "");
            tb1.Text = str;
            SettingsJB2 = new rbtools.IniFile(filepath + "\\" + str + ".prj");
            tb10.Text = SettingsJB2["Settings"]["Author"].Replace("\"", "");
            tb11.Text = SettingsJB2["Settings"]["Org"].Replace("\"", "");
            tb12.Text = SettingsJB2["Settings"]["Desc"].Replace("\"", "");
            tb13.Text = SettingsJB2["Settings"]["Remarks"].Replace("\"", "");
            tb1a.Text = SettingsJB2["Settings"]["Version"];
            string s = SettingsJB2["Settings"]["Exp3DMName"].Replace("\"", "");
            tb23.Text= SettingsJB2["NosProject"]["ExportToEEP"].Replace("\"", "");
            string ata = SettingsJB2["NosProject"]["Track"];
            if (ata == "1")
            {
                groupBox1.Visible = true;
                checkBox1.Visible = true;
                tb14a.Enabled = true;
            }
            if (!String.IsNullOrEmpty(s))
            {
                
                if (!String.IsNullOrEmpty(tb14.Text))
                {

                    string t = s;
                    bool b = t.Contains("_");
                    if (b == true)
                    {

                        label76.Visible = false;

                        //string s = "abc";
                        s = s.Substring(0, s.Length - 4);
                        int len = s.Length > 0 ? s.Length - 4 : 0;
                        s = s.Substring(0, len);

                        //s = s.Substring(0, s.Length - 4);
                        //string correctString = s.Replace("_" + tb14.Text, "");
                        string test = tb21.Text = s;
                        string str2 = Convert.ToString(test.Length);
                        label78.Text = str2 + "  " + hw1;
                    }
                    else
                    {
                        tb21.Text = s.Substring(0, s.Length - 4);
                         //= s;
                    }
                }
            }
            else
            {
                tb21.Text = "";
            }

        }

        private void sysinilesen(string filepath)
        {
            //
            // System.ini einlesen
            //
            SettingsJB3 = new rbtools.IniFile(filepath + "\\System.ini");

            {
                string switchdist = SettingsJB3["Track"]["Id_Code"];
                label80.Text = switchdist;
                if (!String.IsNullOrEmpty(switchdist))
                {
                    tb14a.Text = SettingsJB3["Track"]["Id_Code"].Replace("\"", "");
                    string oneway = SettingsJB3["Track"]["OneWay"];
                    if (oneway == "1")
                    {
                        Properties.Settings.Default.oneway = true;
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        Properties.Settings.Default.oneway = false;
                        radioButton2.Checked = true;
                    }
                }
                else
                {
                    groupBox1.Visible = false;
                    checkBox1.Visible = false;
                    tb14a.Enabled = false;
                }

            }
        }
        #endregion

        #region schreiben
        private void inischreiben(string filepath)
        {
            //
            // ini schreiben
            //
            SettingsJB4 = new rbtools.IniFile(filepath + "\\" + tb1.Text + ".ini");
            SettingsJB4["FileInfo"]["Name_ENG"] = "\"" + tb2.Text + "\"";
            SettingsJB4["FileInfo"]["Name_GER"] = "\"" + tb3.Text + "\"";
            SettingsJB4["FileInfo"]["Name_FRA"] = "\"" + tb4.Text + "\"";
            SettingsJB4["FileInfo"]["Name_POL"] = "\"" + tb5.Text + "\"";
            SettingsJB4["FileInfo"]["Description_ENG"] = "\"" + tb6.Text + "\"";
            SettingsJB4["FileInfo"]["Description_GER"] = "\"" + tb7.Text + "\"";
            SettingsJB4["FileInfo"]["Description_FRA"] = "\"" + tb8.Text + "\"";
            SettingsJB4["FileInfo"]["Description_POL"] = "\"" + tb9.Text + "\"";
            SettingsJB4["FileInfo"]["Creator_Model"] = "\"" + tb14.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_ENG"] = "\"" + tb15.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_GER"] = "\"" + tb16.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_FRA"] = "\"" + tb17.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_POL"] = "\"" + tb18.Text + "\"";
            SettingsJB4["FileInfo"]["Icon"] = tb19.Text;
            SettingsJB4["FileInfo"]["Creator_Original"] = "\"" + tb22.Text + "\"";
        }

        private void inischreiben2(string filepath)
        {
            //
            // ini schreiben in Release / UserRelease ordner
                        //
            SettingsJB4 = new rbtools.IniFile(filepath + "\\" + tb1.Text + "_" + tb14.Text + ".ini");
            SettingsJB4["FileInfo"]["Name_ENG"] = "\"" + tb2.Text + "\"";
            SettingsJB4["FileInfo"]["Name_GER"] = "\"" + tb3.Text + "\"";
            SettingsJB4["FileInfo"]["Name_FRA"] = "\"" + tb4.Text + "\"";
            SettingsJB4["FileInfo"]["Name_POL"] = "\"" + tb5.Text + "\"";
            SettingsJB4["FileInfo"]["Description_ENG"] = "\"" + tb6.Text + "\"";
            SettingsJB4["FileInfo"]["Description_GER"] = "\"" + tb7.Text + "\"";
            SettingsJB4["FileInfo"]["Description_FRA"] = "\"" + tb8.Text + "\"";
            SettingsJB4["FileInfo"]["Description_POL"] = "\"" + tb9.Text + "\"";
            SettingsJB4["FileInfo"]["Creator_Model"] = "\"" + tb14.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_ENG"] = "\"" + tb15.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_GER"] = "\"" + tb16.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_FRA"] = "\"" + tb17.Text + "\"";
            SettingsJB4["FileInfo"]["PdfDoc_POL"] = "\"" + tb18.Text + "\"";
            SettingsJB4["FileInfo"]["Icon"] = tb19.Text;
            SettingsJB4["FileInfo"]["Creator_Original"] = "\"" + tb22.Text + "\"";
        }

        private void prjschreiben(string filepath)
        {
            //
            // prj schreiben
            //
            SettingsJB5 = new rbtools.IniFile(filepath + "\\" + tb1.Text + ".prj");
            SettingsJB5["NosProject"]["PrjName"] = "\"" + tb1.Text + "\"";
            SettingsJB5["NosProject"]["ExportToEEP"] = "\"" + tb23.Text + "\"";
            SettingsJB5["Settings"]["Exp3DMName"] = "\"" + tb21.Text + "_" + tb14.Text + ".3dm\"";
            SettingsJB5["Settings"]["Author"] = "\"" + tb10.Text + "\"";
            SettingsJB5["Settings"]["Org"] = "\"" + tb11.Text + "\"";
            SettingsJB5["Settings"]["Desc"] = "\"" + tb12.Text + "\"";
            SettingsJB5["Settings"]["Remarks"] = "\"" + tb13.Text + "\"";
            SettingsJB5["Settings"]["Version"] = tb1a.Text;
            
        }

        private void IDschreiben(string filepath)
        {
            //
            // System.ini Spline-ID schreiben
            //
            SettingsJB6 = new rbtools.IniFile(filepath + "\\" + "system.ini");
            SettingsJB6["Track"]["Id_Code"] = tb14a.Text;
            if (checkBox1.Checked)
            {
                SettingsJB6["Track"]["SwitchDist"] = " 300";
                SettingsJB6["Track"]["OneWay"] = " 1";
            }
            Properties.Settings.Default.id_code = tb14a.Text;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region release ordner löschen
        private void relordner(string klonepath)
        {
            //
            // Release und UserRelease-Ordner löschen, wenn vorhanden
            //
            if (Directory.Exists(klonepath + "\\Release"))
            {
                FileSystem.DeleteDirectory(klonepath + "\\Release", UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

            }
            if (Directory.Exists(klonepath + "\\UserRelease"))
            {
                FileSystem.DeleteDirectory(klonepath + "\\UserRelease", UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
        }
        #endregion

        #region form load
        private void editor_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.release == true)
            {
                pictureBox247.BackColor = Color.Red;
            }
            else
            {
                pictureBox247.BackColor = Color.Empty;
            }

            if (Properties.Settings.Default.userrelease == true)
            {
                pictureBox248.BackColor = Color.Orange;
            }
            else
            {
                pictureBox248.BackColor = Color.Empty;
            }

            int Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            inilesen(Properties.Settings.Default.pathNosDup);
            prjlesen(Properties.Settings.Default.pathNosDup);
            sysinilesen(Properties.Settings.Default.pathNosDup);
            bool checkconnection = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (checkconnection)
            {
                bool checkInternet = new Ping().Send("google.de", 500).Status == IPStatus.Success;
                if (checkInternet)
                {
                    toolStripStatusLabel1.Text = tssl2;
                    toolStripStatusLabel1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                }
                else
                {
                    toolStripStatusLabel1.Text = tssl1;
                    toolStripStatusLabel1.BackColor = Color.Blue;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    button11.Enabled = false;
                    button3.Enabled = false;
                }
            }
            else
            {
                toolStripStatusLabel1.Text = tssl3;
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel1.ForeColor = Color.White;
                button11.Enabled = false;
                button3.Enabled = false;
            }
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\" + "path.txt");
                string line = sr.ReadLine();

                while (line != null)
                {
                    comboBox1.Items.Add(line);
                    line = sr.ReadLine();
                    //
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        #endregion

        #region eingabeauswertung zeichen
        private void tb1a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 57 && e.KeyChar >= 48) || e.KeyChar == 13 || e.KeyChar == 8 || e.KeyChar == 46)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb14a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 57 && e.KeyChar >= 48) || e.KeyChar == 13 || e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Picturebox klicks icon

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }
        
        private void pictureBox108_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox101_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "154";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox105_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "150";
            tabControl1.SelectedTab = tabPage1;
        }

                private void pictureBox106_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "149";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox107_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "148";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox109_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "146";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox111_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "144";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox112_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "143";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox113_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "142";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox114_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "141";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox115_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "140";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox116_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "139";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox117_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "138";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox118_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "137";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox119_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "136";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox120_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "135";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox121_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "134";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox122_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "133";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox123_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "132";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox124_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "131";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox125_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "130";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox126_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "129";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox127_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "128";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox128_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "127";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox129_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "126";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox130_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "125";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox131_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "124";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox132_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "123";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox133_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "122";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox134_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "121";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox135_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "120";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox136_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "119";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox137_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "118";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox138_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "117";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox139_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "116";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox140_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "115";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox141_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "114";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox142_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "113";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox143_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "112";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox144_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "111";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox145_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "110";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox146_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "109";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox147_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "108";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox148_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "107";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox149_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "106";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox150_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "105";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "104";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "103";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "102";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "101";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "100";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "99";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox57_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "98";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "97";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "96";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "95";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "94";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "93";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "92";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "91";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "90";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "89";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "88";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "87";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "86";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "85";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "84";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "83";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox73_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "82";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "81";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "80";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "79";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "78";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "77";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "76";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "75";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "74";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "73";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox83_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "72";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox84_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "71";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox85_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "70";
            tabControl1.SelectedTab = tabPage1;
        }


        private void pictureBox86_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "69";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox87_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "68";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox88_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "67";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox89_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "66";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox90_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "65";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox91_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "64";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox92_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "63";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox93_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "62";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox94_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "61";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox95_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "60";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox96_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "59";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox97_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "58";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox98_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "57";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox99_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "56";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox100_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "55";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox41_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "54";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "53";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "52";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "51";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "50";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "49";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "48";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox48_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "47";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox49_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "46";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "45";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "44";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "43";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "42";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "41";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "40";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "39";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "38";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "37";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox39_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "36";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "35";
            tabControl1.SelectedTab = tabPage1;
        }
        

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "34";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "33";
            tabControl1.SelectedTab = tabPage1;
        }
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "32";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "31";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "30";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "29";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "28";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "27";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "26";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "25";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "24";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "23";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "22";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "21";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "20";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "19";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "18";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "17";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "16";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "15";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "14";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "13";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "12";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "11";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "10";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "9";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "8";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "7";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "6";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Icons = label70.Text = tb19.Text = "5";
            tabControl1.SelectedTab = tabPage1;
        }
        #endregion

        #region Picturbox Mousehover
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label151.Text = in5;
        }

        private void pictureBox49_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox151_MouseLeave(object sender, EventArgs e)
        {
            label151.Text = "";
        }

        private void b5_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in5;
        }

        private void b6_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in6;
        }

        private void b7_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in7;
        }

        private void b8_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in8;
        }

        private void b9_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in9;
        }

        private void b10_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in10;
        }

        private void b11_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in11;
        }

        private void b12_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in12;
        }

        private void b13_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in13;
        }

        private void b14_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in14;
        }

        private void b15_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in15;
        }

        private void b16_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in16;
        }

        private void b17_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in17;
        }

        private void b18_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in18;
        }

        private void b19_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in19;
        }

        private void b20_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in20;
        }

        private void b21_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in21;
        }

        private void b22_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in22;
        }

        private void b23_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in23;
        }

        private void b24_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in24;
        }

        private void b25_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in25;
        }

        private void b26_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in26;
        }

        private void b27_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in27;
        }

        private void b28_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in28;
        }

        private void b29_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in29;
        }

        private void b30_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in30;
        }

        private void b31_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in31;
        }

        private void b32_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in32;
        }

        private void b33_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in33;
        }

        private void b34_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in34;
        }

        private void b35_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in35;
        }

        private void b36_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in36;
        }

        private void b37_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in37;
        }

        private void b38_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in38;
        }

        private void b39_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in39;
        }

        private void b40_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in40;
        }

        private void b41_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in41;
        }

        private void b42_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in42;
        }

        private void b43_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in43;
        }

        private void b44_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in44;
        }

        private void b45_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in45;
        }

        private void b46_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in46;
        }

        private void b47_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in47;
        }

        private void b48_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in48;
        }

        private void b49_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in49;
        }

        private void b50_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in50;
        }

        private void b51_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in51;
        }

        private void b52_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in53;
        }

        private void b53_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in52;
        }

        private void b54_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in54;
        }

        private void b55_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in55;
        }

        private void b56_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in56;
        }

        private void b57_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in57;
        }

        private void b58_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in58;
        }

        private void b59_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in59;
        }

        private void b60_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in60;
        }

        private void b61_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in61;
        }

        private void b62_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in62;
        }

        private void b63_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in63;
        }

        private void b64_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in64;
        }

        private void b65_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in65;
        }

        private void b66_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in66;
        }

        private void b67_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in67;
        }

        private void b68_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in68;
        }

        private void b69_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in69;
        }

        private void b70_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in70;
        }

        private void b71_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in71;
        }

        private void b72_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in72;
        }

        private void b73_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in73;
        }

        private void b74_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in74;
        }

        private void b75_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in75;
        }

        private void b76_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in76;
        }

        private void b77_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in77;
        }

        private void b78_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in78;
        }

        private void b79_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in79;
        }

        private void b80_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in80;
        }

        private void b81_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in81;
        }

        private void b82_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in82;
        }

        private void b83_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in83;
        }

        private void b84_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in84;
        }

        private void b85_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in85;
        }

        private void b86_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in86;
        }

        private void b87_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in87;
        }

        private void b88_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in88;
        }

        private void b89_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in89;
        }

        private void b90_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in90;
        }

        private void b91_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in91;
        }

        private void b92_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in92;
        }

        private void b93_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in93;
        }

        private void b94_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in94;
        }

        private void b95_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in95;
        }

        private void b96_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in96;
        }

        private void b97_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in97;
        }

        private void b98_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in98;
        }

        private void b99_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in99;
        }

        private void b100_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in100;
        }

        private void b101_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in101;
        }

        private void b102_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in102;
        }

        private void b103_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in103;
        }

        private void b104_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in104;
        }

        private void b105_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in105;
        }

        private void b106_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in106;
        }

        private void b107_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in107;
        }

        private void b108_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in108;
        }

        private void b109_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in109;
        }

        private void b110_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in110;
        }

        private void b111_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in111;
        }

        private void b112_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in112;
        }

        private void b113_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in113;
        }

        private void b114_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in114;
        }

        private void b115_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in115;
        }

        private void b116_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in116;
        }

        private void b117_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in117;
        }

        private void b118_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in118;
        }

        private void b119_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in119;
        }

        private void b120_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in120;
        }

        private void b121_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in121;
        }

        private void b122_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in122;
        }

        private void b123_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in123;
        }

        private void b124_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in124;
        }

        private void b125_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in125;
        }

        private void b126_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in126;
        }

        private void b127_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in127;
        }

        private void b128_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in128;
        }

        private void b129_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in129;
        }

        private void b130_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in130;
        }

        private void b131_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in131;
        }

        private void b132_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in132;
        }

        private void b133_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in133;
        }

        private void b134_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in134;
        }

        private void b135_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in135;
        }

        private void b136_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in136;
        }

        private void b137_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in137;
        }

        private void b138_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in138;
        }

        private void b139_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in139;
        }

        private void b140_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in140;
        }

        private void b141_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in141;
        }

        private void b142_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in142;
        }

        private void b143_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in143;
        }

        private void b144_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in144;
        }

        private void b145_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in145;
        }

        private void b146_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in146;
        }

        private void b147_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in147;
        }

        private void b148_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in148;
        }

        private void b149_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in149;
        }

        private void b150_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in150;
        }

        private void b151_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in151;
        }

        private void b152_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in152;
        }

        private void b153_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in153;
        }

        private void b154_MouseHover(object sender, EventArgs e)
        {
            this.label151.Text = in154;
        }

        #endregion

        #region Picturebox klicks flags
        private void pictureBox246_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "A";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox245_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "AUS";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox244_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "BIH";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox243_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "B";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox242_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "BG";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox241_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "BR";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox240_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "CND";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox239_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "CH";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox238_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "RC";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox237_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "CY";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox236_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "CS";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox207_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "CZ";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox235_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "D";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox234_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "DK";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox233_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "EST";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox232_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "E";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox231_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "FIN";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox230_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "F";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox229_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "GB";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox228_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "GR";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox227_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "HR";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox226_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "HU";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox225_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "IRL";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox224_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "I";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox223_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "J";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox222_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "FL";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox221_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "LT";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox220_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "L";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox219_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "LV";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox218_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "NL";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox216_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "P";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox217_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "PL";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox206_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "M";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox215_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "RO";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox214_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "SRB";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox201_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "BIH";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox212_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "S";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox211_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "SLO";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox210_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "TR";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox209_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "UA";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox208_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "USA";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox204_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "MEX";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox203_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "SK";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox202_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "RU";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox205_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "Others";
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox213_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = "IND";
            tabControl1.SelectedTab = tabPage1;
        }
        #endregion

        #region button 1
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            {
                if (String.IsNullOrEmpty(tb23.Text))
                {
                    MessageBox.Show("Bitte Exportpfad festlegen, es ist kein Exportpfad eingetragen" + Environment.NewLine + "Please specify export path, no export path has been entered" + Environment.NewLine + "Veuillez spécifier le chemin d'exportation, aucun chemin d'exportation n'a été saisi" + Environment.NewLine + "Specificeer exportpad, geen exportpad is ingevoerd");
                }
                else
                {
                    if (tb23.Text == @"\Resourcen\")
                    {
                        MessageBox.Show("Bitte Exportpfad festlegen, es ist nur der Standardpfad eingetragen" + Environment.NewLine + "Please specify export path, only the default path is entered" + Environment.NewLine + "Veuillez spécifier le chemin d'exportation, seul le chemin par défaut est entré" + Environment.NewLine + "Geef exportpad op, alleen de standaard pad is ingevoerd");
                    }
                    else
                    {


                        if (string.IsNullOrEmpty(tb14.Text) == true)
                        {
                            mldg = edml1;
                            mldg3 = "";
                            mldg2 = "";
                            MessageBox.Show(mldg + NL + mldg3 + NL + mldg2, edml5);
                        }
                        else
                        {
                            if (Properties.Settings.Default.set_b == true)
                            {
                                //bearbeiten
                                inischreiben(Settings.Default.pathNosDup);
                                if (Properties.Settings.Default.release == true)
                                {
                                    inischreiben2(Settings.Default.pathNosDup + "\\" + "Release");
                                }
                                if (Properties.Settings.Default.userrelease == true)
                                {
                                    inischreiben2(Settings.Default.pathNosDup + "\\" + "UserRelease");
                                }

                                prjschreiben(Settings.Default.pathNosDup);
                                IDschreiben(Settings.Default.pathNosDup);
                                label47.Text = "yes";
                                this.Close();
                            }
                            else
                            {
                                {
                                    mldg = edml2;
                                    mldg3 = edml3;
                                    mldg2 = edml4;
                                    MessageBox.Show(mldg + NL + mldg3 + NL + mldg2, edml5);
                                }
                                string zipPath = Settings.Default.backup + "\\" + backupset + "-" + DateTime.Now.ToString("MM_dd_yyyy_HH-mm-ss") + ".zip";
                                System.IO.Compression.ZipFile.CreateFromDirectory(Settings.Default.pathNosDup, zipPath, CompressionLevel.Optimal, true);

                                str = label71.Text = Path.GetFileNameWithoutExtension(Settings.Default.pathNosDup);
                                directoryName = Path.GetDirectoryName(Settings.Default.pathNosDup);
                                fileName = directoryName + "\\" + tb1.Text;
                                if (Directory.Exists(fileName))
                                {

                                    mldg = edml6;
                                    MessageBox.Show(mldg, edml5);
                                }
                                else
                                {

                                    mldg = edml7;
                                    mldg3 = edml8;
                                    message = mldg3 + NL + "" + NL + lb101 + ": " + tb1.Text;
                                    caption = mldg;
                                    var buttons = MessageBoxButtons.YesNo;
                                    DialogResult result;
                                    result = MessageBox.Show(message, caption, buttons);

                                    if (result == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        {
                                            //
                                            // löschen der alten ini,prj mdl Dateien
                                            //
                                            FileSystem.CopyDirectory(Settings.Default.pathNosDup, directoryName + "\\" + tb1.Text, true);
                                            System.IO.File.Delete(directoryName + "\\" + tb1.Text + "\\" + str + ".ini");
                                            System.IO.File.Delete(directoryName + "\\" + tb1.Text + "\\" + str + ".prj");
                                            System.IO.File.Delete(directoryName + "\\" + tb1.Text + "\\" + str + ".mdl");
                                            directoryName2 = directoryName + "\\" + tb1.Text;
                                            System.IO.File.Copy(Settings.Default.pathNosDup + "\\" + str + ".ini", directoryName2 + "\\" + tb1.Text + ".ini", true);
                                            System.IO.File.Copy(Settings.Default.pathNosDup + "\\" + str + ".prj", directoryName2 + "\\" + tb1.Text + ".prj", true);
                                            System.IO.File.Copy(Settings.Default.pathNosDup + "\\" + str + ".mdl", directoryName2 + "\\" + tb1.Text + ".mdl", true);
                                            System.IO.File.Copy(Settings.Default.pathNosDup + "\\" + "System.ini", directoryName2 + "\\" + "System.ini", true);
                                        }
                                        inischreiben(directoryName2);
                                        prjschreiben(directoryName2);
                                        IDschreiben(directoryName2);
                                        relordner(directoryName2);
                                        label47.Text = "yes";
                                        Cursor.Current = Cursors.Default;
                                        System.IO.DirectoryInfo dir1 = new DirectoryInfo(directoryName2);
                                        var list1 = dir1.GetFiles("*.x.ini", System.IO.SearchOption.AllDirectories);
                                        if (list1.Length > 0)
                                            {
                                            Properties.Settings.Default.pathID = directoryName2;
                                            xfile_change xfc = new xfile_change();
                                            xfc.ShowDialog();
                                            }
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }


                }
            }
        }
        #endregion

        #region ereignisse
        public string Label1Pub
        {
            get { return this.label47.Text; }
            set { this.label47.Text = value; }
        }

        
        private void tb1_TextChanged(object sender, EventArgs e)
        {
            tb21.Text = tb1.Text;
        }



        private void tb21_TextChanged(object sender, EventArgs e)
        {
            if (tb21.Enabled == true)
            {
                string test = tb21.Text;
                bool result = pruefeEingabe(test);
                bool result2 = pruefeEingab2(test);
                //bool result2 = false;
                {
                    if (result | result2 == true)
                    {
                        if (Properties.Settings.Default.nix == true)
                        {
                            // this.dataGridView1.Rows.Add(test, null, null);
                        }
                        else
                        {
                            label84.Text = hw2;
                        }
                    }
                    else
                    {
                        if (Properties.Settings.Default.nix == true)
                        {
                            //this.dataGridView1.Rows.Add(test, null, null);
                        }
                        else
                        {
                            label84.Text = "";
                        }
                    }
                }

                string test33 = tb21.Text;
                string str2 = Convert.ToString(test33.Length);
                //int mn2 = str2
                if (test33.Length >= 24)
                {
                    button1.Enabled = false;
                    label78.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    button1.Enabled = true;
                    label78.ForeColor = System.Drawing.Color.Black;
                }
                if (test33.Length >= 23)
                {
                    label78.ForeColor = System.Drawing.Color.Red;
                    label78.Text = str2 + " " + hw1;
                    //button1.Enabled = false;
                }
                else
                {
                    label78.ForeColor = System.Drawing.Color.Black;
                    label78.Text = str2 + " " + hw1;
                    //button1.Enabled = true;
                }
            }
            //string test = tb21.Text;
            //bool result = pruefeEingabe(test);
            //bool result2 = pruefeEingab2(test);
            ////bool result2 = false;
            //{
            //    if (result | result2 == true)
            //    {
            //        if (Properties.Settings.Default.nix == true)
            //        {
            //            // this.dataGridView1.Rows.Add(test, null, null);
            //        }
            //        else
            //        {
            //            label84.Text = hw2;
            //        }
            //    }
            //    else
            //    {
            //        if (Properties.Settings.Default.nix == true)
            //        {
            //            //this.dataGridView1.Rows.Add(test, null, null);
            //        }
            //        else
            //        {
            //            label84.Text = "";
            //        }
            //    }
            //}

            //string test33 = tb21.Text;
            //string str2 = Convert.ToString(test33.Length);
            ////int mn2 = str2
            //if (test33.Length >= 24)
            //{
            //    button1.Enabled = false;
            //    label78.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    button1.Enabled = true;
            //    label78.ForeColor = System.Drawing.Color.Black;
            //}
            //if (test33.Length >= 23)
            //{
            //    label78.ForeColor = System.Drawing.Color.Red;
            //    label78.Text = str2 + " " + hw1;
            //    //button1.Enabled = false;
            //}
            //else
            //{
            //    label78.ForeColor = System.Drawing.Color.Black;
            //    label78.Text = str2 + " " + hw1;
            //    //button1.Enabled = true;
            //}
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                tb16.Enabled = true;
                tb17.Enabled = true;
                tb18.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
            else
            {
                tb16.Enabled = false;
                tb17.Enabled = false;
                tb18.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
            }
        }
        #endregion

        #region eingabe prüfen
        private bool pruefeEingabe(string tmp)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9 _]+$");

            if (tmp == null)
            {
                return false;
            }
            else
            {
                if (tmp != "" && !pattern.IsMatch(tmp))
                {
                    return true;
                }
                return false;
            }
        }

        private bool pruefeEingab2(string tmp)
        {
            if (tmp == null)
            {
                return false;
            }
            else
            {
                bool result = tmp.Any(x => Char.IsWhiteSpace(x));

                if (result == true)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region button pdf suchen
        private void button7_Click(object sender, EventArgs e)
        {
            if (pdfdlg.ShowDialog() == DialogResult.OK)
            {
                if (checkBox3.Checked == true)
                {
                    tb15.Text = tb16.Text = tb17.Text = tb18.Text = Path.GetFileName(pdfdlg.FileName);
                }
                else
                {
                    tb15.Text = Path.GetFileName(pdfdlg.FileName);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pdfdlg.ShowDialog() == DialogResult.OK)
            {
                tb16.Text = Path.GetFileName(pdfdlg.FileName);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pdfdlg.ShowDialog() == DialogResult.OK)
            {
                tb17.Text = Path.GetFileName(pdfdlg.FileName);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pdfdlg.ShowDialog() == DialogResult.OK)
            {
                tb18.Text = Path.GetFileName(pdfdlg.FileName);
            }
        }
        #endregion

        #region translate
        public static string Translate(string text, string from, string to)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                client.Encoding = Encoding.UTF8;
                string url = "https://translate.google.com/m?sl=" + from + "&tl=" + to + "&q=" + Uri.EscapeDataString(text);
                string page = client.DownloadString(url);
                var match = Regex.Match(page, @"<div[^>]*class=""(?:t0|result-container)""[^>]*>(.*?)</div>", RegexOptions.Singleline);
                if (!match.Success) throw new InvalidDataException("Translation response unavailable.");
                return System.Web.HttpUtility.HtmlDecode(Regex.Replace(match.Groups[1].Value, "<[^>]+>", ""));
            }
        }

        private void TranslateModelFields(TextBox english, TextBox german, TextBox french, TextBox polish, string emptyHint)
        {
            string language = Properties.Settings.Default.country2 == "de" ? "de" : "en";
            string source = language == "de" ? german.Text : english.Text;
            if (string.IsNullOrWhiteSpace(source)) { MessageBox.Show(emptyHint, "Info"); return; }
            try
            {
                var result = ModelTranslation.Run(source, language, translateText);
                english.Text = result.English;
                german.Text = result.German;
                french.Text = result.French;
                polish.Text = result.Polish;
            }
            catch (Exception)
            {
                MessageBox.Show(UpdateText.T("Übersetzung fehlgeschlagen. Die vorhandenen Texte bleiben erhalten.",
                    "Translation failed. Existing texts have been retained.",
                    "La traduction a échoué. Les textes existants ont été conservés.", "De vertaling is mislukt. Bestaande teksten zijn behouden."), "Projektduplicator 2026");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TranslateModelFields(tb6, tb7, tb8, tb9, inf1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TranslateModelFields(tb2, tb3, tb4, tb5, inf2);
        }
        #endregion

        #region internet / netzwerk test
        public static bool CheckInternetConnection()
        {
            Ping ping = new Ping();

            try
            {
                PingReply reply = ping.Send("www.google.de", 100);

                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region hn spline list
        private void spline_einlesen()
        {
            MessageBox.Show(spmsg1 + "," + NL + spmsg2 + NL + spmsg3 + NL + spmsg4, spmsg5, MessageBoxButtons.OK, MessageBoxIcon.Information);

            string path = Application.StartupPath + "\\" + "HN_splineID.txt";
            FileInfo fi = new FileInfo(path);


            {
                foreach (FileInfo fale in new DirectoryInfo(Settings.Default.pathNos).GetFiles(@"system.ini", System.IO.SearchOption.AllDirectories))

                {
                    Ini ini1 = new Ini();
                    if (ini1.Read(fale.FullName.ToString()))
                    {
                        try
                        {
                            zwi234 = ini1["Track"]["Id_Code"].Replace("\"", "");
                        }
                        catch (Exception)
                        {
                            zwi234 = " ";
                        }

                        if (zwi234 != " ")
                        {
                            this.dataGridView1.Rows.Add((object)(fale.DirectoryName + " ".ToString()), zwi234);

                            {
                                using (StreamWriter sw = fi.AppendText())
                                {
                                    sw.WriteLine(fale.DirectoryName + " ".ToString() + "  " + "\t" + "\t" + zwi234);
                                    sw.Flush();
                                }
                            }

                        }
                    }
                }
            }

            using (StreamWriter sw = fi.AppendText())
            {
                sw.WriteLine();
                sw.WriteLine("im HN benutze ID mit Stand vom " + DateTime.Now.ToString(@"dd.MMM.yyyy HH:mm:ss"));
                sw.WriteLine();
                sw.Flush();
            }
        }
        #endregion

        #region kon spline list
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (tabPage1 == tabControl1.SelectedTab)
            {
                label77.Visible = true;
            }
            else if (tabPage2 == tabControl1.SelectedTab)
            {
                label77.Visible = false;
            }
            else if (tabPage3 == tabControl1.SelectedTab)
            {
                label77.Visible = false;
            }
            else if (tabPage4 == tabControl1.SelectedTab)
            {
                label77.Visible = false;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                spline_einlesen();
            }
            else if (tabPage5 == tabControl1.SelectedTab)
            {
                label77.Visible = false;
                if (System.IO.File.Exists(Application.StartupPath + "\\splineid.txt"))
                {

                    {
                        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\splineid.txt", Encoding.UTF8);
                        richTextBox1.Text = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    string mldg = edml9;
                    string mldg3 = edml10;
                    string mldg2 = edml11;
                    MessageBox.Show(mldg + NL + mldg3 + NL + mldg2, edml12);
                }
            }
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    //tb23.Text = string.Empty;
                }
                else
                {
                    tb23.Text = comboBox1.SelectedItem.ToString();
                }
            }

        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {
            tb3.Text = tb3.Text.Replace("_", " ");
        }

        private void btnadd_path_Click(object sender, EventArgs e)
        {
            string hilfe = label85.Text = tb23.Text;
            string uwe = Application.StartupPath + "\\" + "path.txt";
            using (StreamWriter sw = File.AppendText(uwe))
            {
                sw.WriteLine(hilfe);
                sw.Close();
                {
                    comboBox1.Items.Clear(); 
                    StreamReader sr = new StreamReader(uwe);
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        comboBox1.Items.Add(line);
                        line = sr.ReadLine();
                        
                    }
                    sr.Close();
                }
            }
        }

        
    }
}






