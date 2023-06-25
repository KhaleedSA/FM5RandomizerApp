using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace FM5Randomizer.RandomizerSetting;

public class UserSetting
{
    private static readonly PropertyInfo[] _propertyInfo = typeof(SettingProperties).GetProperties();
    public static void ReadWriteSetting(string savePath)
    {
        if (File.Exists($@"{savePath}\{nameof(RandomizerSetting)}.xml"))
        {
            XElement xelement = XElement.Load($@"{savePath}\{nameof(RandomizerSetting)}.xml");
            IEnumerable<XElement> elementInfo = xelement.Elements();

            // Read XML
            for (int i = 0; i < elementInfo.Count(); i++)
            {
                if (elementInfo.ElementAt(i).Name.LocalName == _propertyInfo[i].Name)
                {
                    var result = GetElementValue(elementInfo.ElementAt(i));
                    _propertyInfo.ElementAt(i).SetValue(null, result);
                }
            }
            return;
        }

        XmlWriterSettings settings = new()
        {
            Indent = true,
            IndentChars = ("    "),
            CloseOutput = true,
            OmitXmlDeclaration = true
        };

        using (XmlWriter writer = XmlWriter.Create($@"{nameof(RandomizerSetting)}.xml", settings))
        {
            writer.WriteStartElement(nameof(UserSetting));

            // Write XML
            foreach (PropertyInfo info in _propertyInfo)
            {
                writer.WriteStartElement(info.Name, $"{info?.GetValue(null, null).ToString()?.ToLower()}");
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Flush();
        }

        Console.WriteLine($"File [{nameof(RandomizerSetting)}.xml] has been Created");
    }

    private static bool GetElementValue(XElement element)
    {
        try
        {
            bool result = XmlConvert.ToBoolean(element.Attribute("xmlns").Value);
            return result;
        }
        catch (Exception ex)
        {
            throw ex.GetBaseException();
        }
    }
}