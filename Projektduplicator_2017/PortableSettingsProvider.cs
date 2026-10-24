using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

public class PortableSettingsProvider : SettingsProvider
{
  private string APPNODE = Assembly.GetExecutingAssembly().GetName().Name + ".Properties.Settings";
  private const string XMLROOT = "configuration";
  private const string CONFIGNODE = "configSections";
  private const string GROUPNODE = "sectionGroup";
  private const string USERNODE = "userSettings";
  private XmlDocument xmlDoc;

  public override string ApplicationName
  {
    get
    {
      return Assembly.GetExecutingAssembly().GetName().Name;
    }
    set
    {
    }
  }

  private XmlDocument XMLConfig
  {
    get
    {
      if (this.xmlDoc == null)
      {
        this.xmlDoc = new XmlDocument();
        try
        {
          this.xmlDoc.Load(Path.Combine(this.GetAppPath(), this.GetSettingsFilename()));
        }
        catch (Exception)
        {
          this.xmlDoc.AppendChild((XmlNode) this.xmlDoc.CreateXmlDeclaration("1.0", "utf-8", (string) null));
          this.xmlDoc.AppendChild((XmlNode) this.xmlDoc.CreateElement("configuration"));
          XmlElement element1 = this.xmlDoc.CreateElement("configSections");
          this.xmlDoc.DocumentElement.PrependChild((XmlNode) element1);
          XmlElement element2 = this.xmlDoc.CreateElement("sectionGroup");
          element2.SetAttribute("name", "userSettings");
          element2.SetAttribute("type", "System.Configuration.UserSettingsGroup");
          element1.AppendChild((XmlNode) element2);
          XmlElement element3 = this.xmlDoc.CreateElement("section");
          element3.SetAttribute("name", this.APPNODE);
          element3.SetAttribute("type", "System.Configuration.ClientSettingsSection");
          element2.AppendChild((XmlNode) element3);
          XmlElement element4 = this.xmlDoc.CreateElement("userSettings");
          this.xmlDoc.DocumentElement.AppendChild((XmlNode) element4);
          XmlElement element5 = this.xmlDoc.CreateElement(this.APPNODE);
          element4.AppendChild((XmlNode) element5);
        }
      }
      return this.xmlDoc;
    }
  }

  public override void Initialize(string name, NameValueCollection config)
  {
    base.Initialize(this.ApplicationName, config);
  }

  public virtual string GetSettingsFilename()
  {
    return "pdup_settings.xml";
  }

  public virtual string GetAppPath()
  {
    return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
  }

  public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext sContext, SettingsPropertyCollection settingsColl)
  {
    SettingsPropertyValueCollection propertyValueCollection = new SettingsPropertyValueCollection();
    foreach (SettingsProperty settingsProperty in settingsColl)
      propertyValueCollection.Add(new SettingsPropertyValue(settingsProperty)
      {
        IsDirty = false,
        SerializedValue = this.GetSetting(settingsProperty)
      });
    return propertyValueCollection;
  }

  public override void SetPropertyValues(SettingsContext sContext, SettingsPropertyValueCollection settingsColl)
  {
    foreach (SettingsPropertyValue setProp in settingsColl)
      this.SetSetting(setProp);
    try
    {
      this.XMLConfig.Save(Path.Combine(this.GetAppPath(), this.GetSettingsFilename()));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, "Fehler beim Schreiben der Konfiguration auf Disk", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private object GetSetting(SettingsProperty setProp)
  {
    object obj;
    try
    {
      if (setProp.SerializeAs.ToString() == "String")
                {
                return (object) this.XMLConfig.SelectSingleNode("//setting[@name='" + setProp.Name + "']").FirstChild.InnerText;
                }

            string @string = setProp.PropertyType.ToString();
      string[] strArray = (string[]) new XmlSerializer(typeof (string[])).Deserialize((XmlReader) new XmlTextReader(this.XMLConfig.SelectSingleNode("//setting[@name='" + setProp.Name + "']").FirstChild.InnerXml, XmlNodeType.Element, (XmlParserContext) null));
      switch (@string)
      {
        case "System.Collections.Specialized.StringCollection":
          StringCollection stringCollection = new StringCollection();
          stringCollection.AddRange(strArray);
          return (object) stringCollection;
        default:
          return (object) "";
      }
    }
    catch (Exception)
    {
      if (setProp.DefaultValue != null)
      {
        if (setProp.SerializeAs.ToString() == "String")
        {
          obj = (object) setProp.DefaultValue.ToString();
        }
        else
        {
          string @string = setProp.PropertyType.ToString();
          string[] strArray = (string[]) new XmlSerializer(typeof (string[])).Deserialize((XmlReader) new XmlTextReader(setProp.DefaultValue.ToString(), XmlNodeType.Element, (XmlParserContext) null));
          switch (@string)
          {
            case "System.Collections.Specialized.StringCollection":
              StringCollection stringCollection = new StringCollection();
              stringCollection.AddRange(strArray);
              return (object) stringCollection;
            default:
              return (object) "";
          }
        }
      }
      else
        obj = (object) "";
    }
    return obj;
  }

  private void SetSetting(SettingsPropertyValue setProp)
  {
    XmlNode xmlNode1;
    try
    {
      xmlNode1 = this.XMLConfig.SelectSingleNode("//setting[@name='" + setProp.Name + "']").FirstChild;
    }
    catch (Exception)
    {
      xmlNode1 = (XmlNode) null;
    }
    if (xmlNode1 != null)
    {
      if (setProp.Property.SerializeAs.ToString() == "String")
        xmlNode1.InnerText = setProp.SerializedValue.ToString();
      else
        xmlNode1.InnerXml = setProp.SerializedValue.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
    }
    else
    {
      XmlNode xmlNode2 = this.XMLConfig.SelectSingleNode("//" + this.APPNODE);
      XmlElement element1 = this.xmlDoc.CreateElement("setting");
      element1.SetAttribute("name", setProp.Name);
      if (setProp.Property.SerializeAs.ToString() == "String")
        element1.SetAttribute("serializeAs", "String");
      else
        element1.SetAttribute("serializeAs", "Xml");
      xmlNode2.AppendChild((XmlNode) element1);
      XmlElement element2 = this.xmlDoc.CreateElement("value");
      if (setProp.Property.SerializeAs.ToString() == "String")
        element2.InnerText = setProp.SerializedValue.ToString();
      else
        element2.InnerXml = setProp.SerializedValue.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
      element1.AppendChild((XmlNode) element2);
    }
  }
}
