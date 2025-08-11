namespace PriceBook_Data
{
    public class Settings
    {
        public Settings()
        {
            string fileName = Environment.CurrentDirectory + "\\" + "Settings.txt";
            StreamReader reader = new StreamReader(fileName);
            string wholeFile = reader.ReadToEnd();
            string[] settingLines = wholeFile.Split('\n');

            foreach (string t in settingLines)
            {
                if (t.Length == 0) continue; // handle random blank lines within the file.
                if (t.Substring(0, 1) == "#")
                {
                    continue;
                } // pound represents a comment

                string[] currentSetting = t.Split(',');
                currentSetting[0] = currentSetting[0].Trim();
                switch (currentSetting[0])
                {
                    case "ConnectionString":
                        ConnectionString = currentSetting[1];
                        break;
                }
            }

        }

        public string ConnectionString { get; private set; }


    }
}