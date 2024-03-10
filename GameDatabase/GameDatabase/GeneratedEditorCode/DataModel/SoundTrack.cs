using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
    public class SoundTrack
    {
        public static SoundTrack Create( SoundTrackSerializable serializable, Database database )
        {
            if ( serializable == null )
            {
                return SoundTrack.DefaultValue;
            }
            return new SoundTrack( serializable, database );
        }

        public SoundTrack()
        {
        }

        private SoundTrack( SoundTrackSerializable serializable, Database database )
        {
            this.Audio = serializable.Audio;
        }

        public SoundTrackSerializable Serialize()
        {
            return new SoundTrackSerializable
            {
                Audio = this.Audio
            };
        }

        public static SoundTrack DefaultValue { get; private set; }

        public string Audio;
    }
}