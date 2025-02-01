//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Model;
using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
    public partial class NodeAction
    {
        partial void OnDataDeserialized( NodeActionSerializable serializable, Database database );
        partial void OnDataSerialized( ref NodeActionSerializable serializable );

        public static NodeAction Create( NodeActionSerializable serializable, Database database )
        {
            if ( serializable == null ) return DefaultValue;
            return new NodeAction( serializable, database );
        }

        public NodeAction() { }

        public NodeAction( NodeActionSerializable serializable, Database database )
        {
            this.TargetNode = new NumericValue<int>(serializable.TargetNode, 1, 999999);
            Requirement.Value = DataModel.Requirement.Create( serializable.Requirement, database );
            ButtonText = serializable.ButtonText;
            OnDataDeserialized( serializable, database );
        }

        public NodeActionSerializable Serialize()
        {
            var serializable = new NodeActionSerializable();
            serializable.TargetNode = TargetNode.Value;
            serializable.Requirement = Requirement.Value?.Serialize();
            serializable.ButtonText = ButtonText;
            OnDataSerialized( ref serializable );
            return serializable;
        }

        public NumericValue<int> TargetNode = new NumericValue<int>(0, 1, 999999);
        public ObjectWrapper<Requirement> Requirement = new ObjectWrapper<Requirement>( DataModel.Requirement.DefaultValue );
        public string ButtonText;

        public static NodeAction DefaultValue { get; set; }
    }
}
