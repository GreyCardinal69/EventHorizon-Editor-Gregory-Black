using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class SoundTrackSerializable
    {
        [DefaultValue( "" )]
        public string Audio;
    }
}