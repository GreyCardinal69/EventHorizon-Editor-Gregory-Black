//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
    public partial class LocalizationSettings
    {
        partial void OnDataDeserialized( LocalizationSettingsSerializable serializable, Database database );
        partial void OnDataSerialized( ref LocalizationSettingsSerializable serializable );

        public static LocalizationSettings Create( LocalizationSettingsSerializable serializable, Database database )
        {
            if ( serializable == null ) return DefaultValue;
            return new LocalizationSettings( serializable, database );
        }

        public LocalizationSettings( LocalizationSettingsSerializable serializable, Database database )
        {
            CorrosiveDamageText = serializable.CorrosiveDamageText;
            CorrosiveDpsText = serializable.CorrosiveDpsText;
            OnDataDeserialized( serializable, database );
        }

        public void Save( LocalizationSettingsSerializable serializable )
        {
            serializable.CorrosiveDamageText = CorrosiveDamageText;
            serializable.CorrosiveDpsText = CorrosiveDpsText;
            OnDataSerialized( ref serializable );
        }

        public string CorrosiveDamageText;
        public string CorrosiveDpsText;

        public static LocalizationSettings DefaultValue { get; set; }
    }
}
