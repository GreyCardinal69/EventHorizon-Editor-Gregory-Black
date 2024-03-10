using EditorDatabase.Serializable;
using System.Linq;

namespace EditorDatabase.DataModel
{
    public class MusicPlaylist
    {
        public static MusicPlaylist Create( MusicPlaylistSerializable serializable, Database database )
        {
            if ( serializable == null )
            {
                return MusicPlaylist.DefaultValue;
            }
            return new MusicPlaylist( serializable, database );
        }

        public MusicPlaylist( MusicPlaylistSerializable serializable, Database database )
        {
            SoundTrackSerializable[] mainMenuMusic = serializable.MainMenuMusic;
            this.MainMenuMusic = ( ( mainMenuMusic != null ) ? ( from item in mainMenuMusic
                                                                 select SoundTrack.Create( item, database ) ).ToArray<SoundTrack>() : null );
            SoundTrackSerializable[] galaxyMapMusic = serializable.GalaxyMapMusic;
            this.GalaxyMapMusic = ( ( galaxyMapMusic != null ) ? ( from item in galaxyMapMusic
                                                                   select SoundTrack.Create( item, database ) ).ToArray<SoundTrack>() : null );
            SoundTrackSerializable[] combatMusic = serializable.CombatMusic;
            this.CombatMusic = ( ( combatMusic != null ) ? ( from item in combatMusic
                                                             select SoundTrack.Create( item, database ) ).ToArray<SoundTrack>() : null );
            SoundTrackSerializable[] explorationMusic = serializable.ExplorationMusic;
            this.ExplorationMusic = ( ( explorationMusic != null ) ? ( from item in explorationMusic
                                                                       select SoundTrack.Create( item, database ) ).ToArray<SoundTrack>() : null );
        }

        public void Save( MusicPlaylistSerializable serializable )
        {
            if ( this.MainMenuMusic == null || this.MainMenuMusic.Length == 0 )
            {
                serializable.MainMenuMusic = null;
            }
            else
            {
                serializable.MainMenuMusic = ( from item in this.MainMenuMusic
                                               select item.Serialize() ).ToArray<SoundTrackSerializable>();
            }
            if ( this.GalaxyMapMusic == null || this.GalaxyMapMusic.Length == 0 )
            {
                serializable.GalaxyMapMusic = null;
            }
            else
            {
                serializable.GalaxyMapMusic = ( from item in this.GalaxyMapMusic
                                                select item.Serialize() ).ToArray<SoundTrackSerializable>();
            }
            if ( this.CombatMusic == null || this.CombatMusic.Length == 0 )
            {
                serializable.CombatMusic = null;
            }
            else
            {
                serializable.CombatMusic = ( from item in this.CombatMusic
                                             select item.Serialize() ).ToArray<SoundTrackSerializable>();
            }
            if ( this.ExplorationMusic == null || this.ExplorationMusic.Length == 0 )
            {
                serializable.ExplorationMusic = null;
                return;
            }
            serializable.ExplorationMusic = ( from item in this.ExplorationMusic
                                              select item.Serialize() ).ToArray<SoundTrackSerializable>();
        }

        public static MusicPlaylist DefaultValue { get; private set; }

        public SoundTrack[] MainMenuMusic;

        public SoundTrack[] GalaxyMapMusic;

        public SoundTrack[] CombatMusic;

        public SoundTrack[] ExplorationMusic;
    }
}
