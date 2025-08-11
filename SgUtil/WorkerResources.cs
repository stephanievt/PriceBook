using System;
using System.Text;
using System.Xml;

namespace SgUtil
{
    public static class WorkerResources
    {
        private static readonly Random Rnd = new Random();

        public static string BeautifyXml(string xml)
        { //this XmlDocument doc
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }

        public static string GetGuidString()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GetRandomString(int length)
        {
            
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[Rnd.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string GetTopLevelDomain()
        {
            string[] options = new[] { ".com", ".net", ".org" };
            Random random = new Random();
            int index = random.Next(0, options.Length);
            return options[index];
        }

        public static string GetNewEmail()
        {
            return GetRandomString(10) + "@" + GetRandomString(5) + GetTopLevelDomain();

        }

        public static string GetNewPhoneFormatted()
        {
            string wip;
            var chars = "0123456789";
            var stringChars = new char[10];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[Rnd.Next(chars.Length)];
            }

            wip = new string(stringChars);
            return wip;

        }

        public static int GetRandomNumber(int max, bool fromZero = false)
        {
            if (fromZero)
            {
                return Rnd.Next(0, max);
            }

            return Rnd.Next(1, max);  // creates a number between 1 and max

            
        }

        public static string PadStringLeadingZeros(string input, int stringLength)
        {
            return input.PadLeft(stringLength, '0');
        }

        public static string GetSsnForTest()
        {
            string wip = GetRandomNumber(3).ToString() + "-" + GetRandomNumber(2) + "-" + GetRandomNumber(4);
            return wip;
        }

       
    }
}