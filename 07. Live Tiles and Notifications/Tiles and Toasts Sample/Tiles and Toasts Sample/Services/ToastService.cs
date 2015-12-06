using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;


namespace Tiles_and_Toasts_Sample.Services
{
    public class ToastService
    {
        public static XmlDocument CreateToast()
        {
            var xDoc = new XDocument(
                new XElement("toast",
                    new XElement("visual",
                        new XElement("binding", new XAttribute("template", "ToastGeneric"),
                            new XElement("text", "Breaking!"),
                            new XElement("text", "Moscow prepares for lots of snow!")
                            ) // binding
                        ), // visual
                    new XElement("actions",
                        new XElement("action", new XAttribute("activationType", "background"),
                            new XAttribute("content", "I'm ready!"), new XAttribute("arguments", "no")),
                        new XElement("action", new XAttribute("activationType", "background"),
                            new XAttribute("content", "Give me tips"), new XAttribute("arguments", "yes"))
                        ) // actions
                    )
                );
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xDoc.ToString());
            return xmlDoc;
        }

    }
}
