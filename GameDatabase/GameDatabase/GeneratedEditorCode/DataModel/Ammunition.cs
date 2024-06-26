//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;
using System.Linq;

namespace EditorDatabase.DataModel
{
    public partial class Ammunition
	{
		partial void OnDataDeserialized(AmmunitionSerializable serializable, Database database);
		partial void OnDataSerialized(ref AmmunitionSerializable serializable);


		public Ammunition(AmmunitionSerializable serializable, Database database)
		{
			try
			{
				Id = new ItemId<Ammunition>(serializable.Id, serializable.FileName);
				Body = new BulletBody(serializable.Body, database);
				Triggers = serializable.Triggers?.Select(item => new BulletTrigger(item, database)).ToArray();
				ImpactType = serializable.ImpactType;
                Controller.Value = DataModel.BulletController.Create( serializable.Controller, database );
                Effects = serializable.Effects?.Select(item => new ImpactEffect(item, database)).ToArray();
			}
			catch (DatabaseException e)
			{
				throw new DatabaseException(this.GetType() + ": deserialization failed. " + serializable.FileName + " (" + serializable.Id + ")", e);
			}
			OnDataDeserialized(serializable, database);
		}

		public void Save(AmmunitionSerializable serializable)
		{
            serializable.Controller = Controller.Value?.Serialize();
            serializable.Body = Body.Serialize();
			if (Triggers == null || Triggers.Length == 0)
			    serializable.Triggers = null;
			else
			    serializable.Triggers = Triggers.Select(item => item.Serialize()).ToArray();
			serializable.ImpactType = ImpactType;
			if (Effects == null || Effects.Length == 0)
			    serializable.Effects = null;
			else
			    serializable.Effects = Effects.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<Ammunition> Id;

		public BulletBody Body = new BulletBody();
		public BulletTrigger[] Triggers;
		public BulletImpactType ImpactType;
		public ImpactEffect[] Effects;
        public ObjectWrapper<BulletController> Controller = new ObjectWrapper<BulletController>( EditorDatabase.DataModel.BulletController.DefaultValue );
        public static Ammunition DefaultValue { get; private set; }
	}
}
