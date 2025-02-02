namespace GameDatabase
{
    public class DBESettings
    {
        public class Theme
        {
            public string BorderColor;
            public string BackgroundColor;
            public string FontColor;
            public string Accent;
            public string Accent2;
            public string Accent3;
        }

        public bool KeepShipBuildsDefaultValues;
        public int ActiveTheme;
        public int ElementsPerPage;
        public Theme[] Themes;
    }
}