using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Paygate.Utility
{
    public class XMLUtility
    {
        /// <summary>
        /// Serialize object ra XML
        /// </summary>
        /// <param name="serializingObject"></param>
        /// <returns></returns>
        public string XmlSerialize(object serializingObject)
        {
            try
            {
                var settings = new XmlWriterSettings
                                   {
                                       OmitXmlDeclaration = true,
                                       Indent = true,
                                       NewLineHandling = NewLineHandling.Replace,
                                       NewLineChars = "\n"
                                   };

                var strWriter = new StringWriter();
                var writer = XmlWriter.Create(strWriter, settings);
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                var serializer = new XmlSerializer(serializingObject.GetType());

                if (writer != null) serializer.Serialize(writer, serializingObject, namespaces);
                return strWriter.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deserialize XML thành object
        /// </summary>
        /// <param name="xml">Nội dung XML</param>
        /// <param name="type">Kiếu object cần Deserialize</param>
        /// <returns>object kết quả sau khi Deserialize</returns>
        public object Deserialize(string xml, Type type)
        {
            try
            {
                var rd = new StringReader(xml);
                var srz = new XmlSerializer(type);
                return srz.Deserialize(rd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
