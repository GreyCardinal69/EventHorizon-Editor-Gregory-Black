using System;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class MusicPlaylistSerializable : SerializableItem
    {
        public SoundTrackSerializable[] MainMenuMusic;

        public SoundTrackSerializable[] GalaxyMapMusic;

        public SoundTrackSerializable[] CombatMusic;

        public SoundTrackSerializable[] ExplorationMusic;
    }
}