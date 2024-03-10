using DatabaseMigration.v1.Serializable;
using System;

namespace GameDatabase.GameDatabase.GeneratedMigrationCode.v1.Serializable
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