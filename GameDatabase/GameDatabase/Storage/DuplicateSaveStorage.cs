using System.IO;

namespace EditorDatabase.Storage
{
    public class DuplicateSaveStorage : DatabaseStorage
    {
        public DuplicateSaveStorage( string path ) : base( path )
        {
        }

        public override void SaveJson( string name, string data )
        {
            var fullName = Path.Combine( _path, name );
            while ( File.Exists( fullName ) )
            {
                name = Path.Combine( Path.GetDirectoryName( name ),
                    Path.GetFileNameWithoutExtension( name ) + "_" + ".json" );
                fullName = Path.Combine( _path, name );
            }

            base.SaveJson( name, data );
        }
    }
}