namespace GameDatabase
{
    internal class DBESettings
    {
        internal class Theme
        {
            public string BorderColor;
            public string BackgroundColor;
            public string FontColor;
            public string Accent;
            public string Accent2;
            public string Accent3;
        }

        public int ActiveTheme;
        public int ElementsPerPage;
        public Theme[] Themes;
    }
}