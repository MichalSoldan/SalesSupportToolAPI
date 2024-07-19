using System.IO;
using System.Xml.Serialization;

namespace SFFilter.Common.Helpers
{
    public static class XMLSerializer
    {
        public static DTO Deserialize<DTO>(string input) where DTO : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(DTO));

            using (StringReader sr = new StringReader(input))
            {
                return (DTO)ser.Deserialize(sr);
            }
        }

        public static string Serialize(object dataObject)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataObject.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, dataObject);
                return textWriter.ToString();
            }
        }
    }
}