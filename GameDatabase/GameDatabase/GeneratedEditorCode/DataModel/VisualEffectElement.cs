//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
	public partial class VisualEffectElement
	{
		partial void OnDataDeserialized(VisualEffectElementSerializable serializable, Database database);
		partial void OnDataSerialized(ref VisualEffectElementSerializable serializable);

		public VisualEffectElement() {}

		public VisualEffectElement(VisualEffectElementSerializable serializable, Database database)
		{
            ParticleSize = new NumericValue<float>( serializable.ParticleSize, 0.001f, 100f );
            Loop = serializable.Loop;
            Quantity = new NumericValue<int>( serializable.Quantity, 1, 100 );
            Type = serializable.Type;
			Image = serializable.Image;
			ColorMode = serializable.ColorMode;
			Color = Helpers.ColorFromString(serializable.Color);
			Size = new NumericValue<float>(serializable.Size, 0.001f, 100f);
			GrowthRate = new NumericValue<float>(serializable.GrowthRate, -1f, 100f);
			TurnRate = new NumericValue<float>(serializable.TurnRate, -1000f, 1000f);
			StartTime = new NumericValue<float>(serializable.StartTime, 0f, 1000f);
			Lifetime = new NumericValue<float>(serializable.Lifetime, 0f, 1000f);
			OnDataDeserialized(serializable, database);
		}

		public VisualEffectElementSerializable Serialize()
		{
            var serializable = new VisualEffectElementSerializable();
			serializable.Type = Type;
			serializable.Image = Image;
			serializable.ColorMode = ColorMode;
			serializable.Color = Helpers.ColorToString(Color);
			serializable.Size = Size.Value;
			serializable.GrowthRate = GrowthRate.Value;
			serializable.TurnRate = TurnRate.Value;
			serializable.StartTime = StartTime.Value;
			serializable.Lifetime = Lifetime.Value;
            serializable.Quantity = Quantity.Value;
            serializable.ParticleSize = ParticleSize.Value;
            serializable.Loop = Loop;
            OnDataSerialized(ref serializable);
			return serializable;
		}
        public NumericValue<float> ParticleSize = new NumericValue<float>( 0, 0.001f, 100f );
        public VisualEffectType Type;
		public string Image;
		public ColorMode ColorMode;
		public System.Drawing.Color Color;
		public NumericValue<float> Size = new NumericValue<float>(0, 0.001f, 100f);
		public NumericValue<float> GrowthRate = new NumericValue<float>(0, -1f, 100f);
		public NumericValue<float> TurnRate = new NumericValue<float>(0, -1000f, 1000f);
		public NumericValue<float> StartTime = new NumericValue<float>(0, 0f, 1000f);
		public NumericValue<float> Lifetime = new NumericValue<float>(0, 0f, 1000f);
        public bool Loop;
        public NumericValue<int> Quantity = new NumericValue<int>( 0, 1, 100 );
        public static VisualEffectElement DefaultValue { get; private set; }
	}
}
