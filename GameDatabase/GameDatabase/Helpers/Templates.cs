using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EditorDatabase
{
    public class Templates
    {
        private readonly Dictionary<string, SerializableTemplate> _templates = new Dictionary<string, SerializableTemplate>();

        public IEnumerable<SerializableTemplate> Data { get { return _templates.Values; } }

        public SerializableTemplate Get( string path )
        {
            return _templates[path];
        }

        public void Load( string _path )
        {
            var _serializer = new EditorDatabase.Storage.JsonSerializer();
            var info = new DirectoryInfo( _path );
            foreach ( var fileInfo in info.GetFiles( "*", SearchOption.AllDirectories ) )
            {
                var file = fileInfo.FullName;
                var path = file.Substring( info.FullName.Length + 1 );
                if ( fileInfo.Extension.Equals( ".template", StringComparison.OrdinalIgnoreCase ) )
                {
                    var data = File.ReadAllText( file );
                    try
                    {
                        var item = _serializer.FromJson<SerializableTemplate>( data );
                        item.FileName = fileInfo.FullName.Replace( _path, "" );
                        _templates.Add( item.Name, item );
                    }
                    catch ( Exception )
                    {

                    }
                }
            }
        }
    }

    [Serializable]
    public class SerializableTemplate
    {
        public string Name;
        public SerializableTemplateItem[] Items;
        public int Id;
        public string NameDialog;
        public string IdDialog;

        [JsonIgnore]
        public string FileName;

        [JsonIgnore]
        public string FilePath;
    }

    [Serializable]
    public class SerializableTemplateItem
    {
        public string Filename;
        public string Type;
        public Newtonsoft.Json.Linq.JObject Content;
        public SerializableTemplateItem[] Items;
    }
}