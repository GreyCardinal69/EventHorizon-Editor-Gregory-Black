using EditorDatabase.Model;
using EditorDatabase;
using System;
using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
    public class ComponentGroupTag
    {
        public static ComponentGroupTag Create( ComponentGroupTagSerializable serializable, Database database )
        {
            if ( serializable == null )
            {
                return ComponentGroupTag.DefaultValue;
            }
            return new ComponentGroupTag( serializable, database );
        }


        public ComponentGroupTag( ComponentGroupTagSerializable serializable, Database database )
        {
            try
            {
                this.Id = new ItemId<ComponentGroupTag>( serializable.Id, serializable.FileName );
                this.MaxInstallableComponents = new NumericValue<int>( serializable.MaxInstallableComponents, 1, int.MaxValue );
            }
            catch ( DatabaseException inner )
            {
                string[] array = new string[6];
                int num = 0;
                Type type = base.GetType();
                array[num] = ( ( type != null ) ? type.ToString() : null );
                array[1] = ": deserialization failed. ";
                array[2] = serializable.FileName;
                array[3] = " (";
                array[4] = serializable.Id.ToString();
                array[5] = ")";
                throw new DatabaseException( string.Concat( array ), inner );
            }
        }


        public void Save( ComponentGroupTagSerializable serializable )
        {
            serializable.MaxInstallableComponents = this.MaxInstallableComponents.Value;
        }

        public static ComponentGroupTag DefaultValue { get; private set; }


        public readonly ItemId<ComponentGroupTag> Id;


        public NumericValue<int> MaxInstallableComponents = new NumericValue<int>( 0, 1, int.MaxValue );
    }
}