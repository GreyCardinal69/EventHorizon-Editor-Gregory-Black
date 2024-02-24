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
using System.Security.AccessControl;

namespace EditorDatabase.DataModel
{
	public partial class ShipBuild
	{
		partial void OnDataDeserialized(ShipBuildSerializable serializable, Database database);
		partial void OnDataSerialized(ref ShipBuildSerializable serializable);


		public ShipBuild(ShipBuildSerializable serializable, Database database)
        {
            try
			{
                CustomAI = database.GetBehaviorTreeId( serializable.CustomAI );
                AvailableForPlayer = serializable.AvailableForPlayer;
                AvailableForEnemy = serializable.AvailableForEnemy;
                Id = new ItemId<ShipBuild>(serializable.Id, serializable.FileName);
				Ship = database.GetShipId(serializable.ShipId);
				if (Ship.IsNull)
				    throw new DatabaseException(this.GetType().Name + " (" + serializable.Id + "): Ship cannot be null");
				NotAvailableInGame = serializable.NotAvailableInGame;
				DifficultyClass = serializable.DifficultyClass;
				BuildFaction = database.GetFactionId(serializable.BuildFaction);
				Components = serializable.Components?.Select(item => new InstalledComponent(item, database)).ToArray();
			}
			catch (DatabaseException e)
			{
				throw new DatabaseException(this.GetType() + ": deserialization failed. " + serializable.FileName + " (" + serializable.Id + ")", e);
			}
			OnDataDeserialized(serializable, database);
		}

		public void Save(ShipBuildSerializable serializable)
		{
            serializable.CustomAI = CustomAI.Value;
            serializable.AvailableForPlayer = AvailableForPlayer;
            serializable.AvailableForEnemy = AvailableForEnemy;
            serializable.ShipId = Ship.Value;
			serializable.NotAvailableInGame = NotAvailableInGame;
			serializable.DifficultyClass = DifficultyClass;
			serializable.BuildFaction = BuildFaction.Value;
			if (Components == null || Components.Length == 0)
			    serializable.Components = null;
			else
			    serializable.Components = Components.Select(item => item.Serialize()).ToArray();
			OnDataSerialized(ref serializable);
		}

		public readonly ItemId<ShipBuild> Id;
        public ItemId<BehaviorTreeModel> CustomAI = ItemId<BehaviorTreeModel>.Empty;
        public bool AvailableForPlayer;
        public bool AvailableForEnemy;
        public ItemId<Ship> Ship = ItemId<Ship>.Empty;
		public bool NotAvailableInGame;
		public DifficultyClass DifficultyClass;
		public ItemId<Faction> BuildFaction = ItemId<Faction>.Empty;
		public InstalledComponent[] Components;

		public static ShipBuild DefaultValue { get; private set; }
	}
}
