using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP_game_Final_Project
{
    internal class HelperClass
    {
        public static int NumberGenerator(int min, int max)
        {
            Random rnd = new Random();
            int num = rnd.Next(min, max+1);
            return num;
        }
        public static float NumberGenerator(float min, float max)
        {
            Random rnd = new Random();
            float num = rnd.Next((int)min,(int)max+1);
            return num;
        }

        public static void WriteXML(string path, PlayGame PG)
        {
            string? basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\";
            var serializer = new DataContractSerializer(typeof(PlayGame));

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            var writer = XmlWriter.Create(basePath + path, settings);

            serializer.WriteObject(writer, PG);
            writer.Close();

        }



        public static PlayGame ReadXML(string path)
        {

            string? basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\";
            FileStream file = new FileStream(basePath + path, FileMode.Open);
            XmlDictionaryReaderQuotas test = new XmlDictionaryReaderQuotas();
            test.MaxDepth = 10000;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(file, test);
            DataContractSerializer serializer = new(typeof(PlayGame));
            PlayGame SM = (PlayGame)serializer.ReadObject(reader, true);
            reader.Close();
            file.Close();
            return SM;

        }
    }
}
