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
    public partial class NodeTransition
    {
        partial void OnDataDeserialized( NodeTransitionSerializable serializable, Database database );
        partial void OnDataSerialized( ref NodeTransitionSerializable serializable );

        public static NodeTransition Create( NodeTransitionSerializable serializable, Database database )
        {
            if ( serializable == null ) return DefaultValue;
            return new NodeTransition( serializable, database );
        }

        public NodeTransition() { }

        public NodeTransition( NodeTransitionSerializable serializable, Database database )
        {
            TargetNode = new NumericValue<int>( serializable.TargetNode, 1, 1000 );
            Requirement.Value = DataModel.Requirement.Create( serializable.Requirement, database );
            Weight = new NumericValue<float>( serializable.Weight, 0f, 1000f );
            OnDataDeserialized( serializable, database );
        }

        public NodeTransitionSerializable Serialize()
        {
            var serializable = new NodeTransitionSerializable();
            serializable.TargetNode = TargetNode.Value;
            serializable.Requirement = Requirement.Value?.Serialize();
            serializable.Weight = Weight.Value;
            OnDataSerialized( ref serializable );
            return serializable;
        }

        public NumericValue<int> TargetNode = new NumericValue<int>( 0, 1, 1000 );
        public ObjectWrapper<Requirement> Requirement = new ObjectWrapper<Requirement>( DataModel.Requirement.DefaultValue );
        public NumericValue<float> Weight = new NumericValue<float>( 0, 0f, 1000f );

        public static NodeTransition DefaultValue { get; set; }
    }
}
