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
            int counter = 0;

            // Read XML
            foreach (XAttribute attribute in elementInfo.Attributes())
            {
                var result = GetElementValue(attribute);
                _propertyInfo.ElementAt(counter).SetValue(null, result);
                counter++;
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
                if (info?.Name == nameof(SettingProperties.Randomize_SelectionPilot))
                {
                    WriteElement(writer, info, nameof(SettingProperties.SelectionPilot_FixedNumber), 8);
                    continue;
                }

                if (info?.Name == nameof(SettingProperties.Randomize_Skills))
                {
                    WriteElement(writer, info, nameof(SettingProperties.Skills_FixedNumber), 16);
                    continue;
                }

                if (info?.Name == nameof(SettingProperties.Randomize_Items))
                {
                    WriteElement(writer, info, nameof(SettingProperties.Items_FixedNumber), 8);
                    continue;
                }

                if (info?.PropertyType != typeof(byte))
                    WriteElement(writer, info);
            }

            writer.WriteEndElement();
            writer.Flush();
        }

        Console.WriteLine($"File [{nameof(RandomizerSetting)}.xml] has been Created");
    }

    private static void WriteElement(XmlWriter writer, PropertyInfo? info, string? settingProperties = null, byte value = 0)
    {
        writer.WriteStartElement(info.Name);
        writer.WriteAttributeString("Boolean", $"{info?.GetValue(null, null).ToString()?.ToLower()}");

        if (settingProperties != null && value != 0)
            writer.WriteAttributeString(settingProperties, $"{value}");
        writer.WriteEndElement();
    }

    private static object GetElementValue(XAttribute attribute)
    {
        try
        {
            string xName = attribute.Name.LocalName;

            if (xName == "Boolean")
                return Convert.ToBoolean(attribute.Value);
            else
                return Convert.ToByte(attribute.Value);
        }
        catch (Exception ex)
        {
            throw ex.GetBaseException();
        }
    }
}