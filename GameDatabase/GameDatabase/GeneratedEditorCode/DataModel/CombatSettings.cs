﻿using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
    public partial class CombatSettings
    {
        partial void OnDataDeserialized( CombatSettingsSerializable serializable, Database database );
        partial void OnDataSerialized( ref CombatSettingsSerializable serializable );

        public static CombatSettings Create( CombatSettingsSerializable serializable, Database database )
        {
            if ( serializable == null ) return DefaultValue;
            return new CombatSettings( serializable, database );
        }

        private CombatSettings( CombatSettingsSerializable serializable, Database database )
        {
            DefaultCombatRules = database.GetCombatRulesId( serializable.DefaultCombatRules );
            EnemyAI = database.GetBehaviorTreeId( serializable.EnemyAI );
            AutopilotAI = database.GetBehaviorTreeId( serializable.AutopilotAI );
            CloneAI = database.GetBehaviorTreeId( serializable.CloneAI );
            DefensiveDroneAI = database.GetBehaviorTreeId( serializable.DefensiveDroneAI );
            StarbaseAI = database.GetBehaviorTreeId( serializable.StarbaseAI );
            OffensiveDroneAI = database.GetBehaviorTreeId( serializable.OffensiveDroneAI );
            OnDataDeserialized( serializable, database );
        }

        public void Save( CombatSettingsSerializable serializable )
        {
            serializable.DefaultCombatRules = DefaultCombatRules.Value;
            serializable.EnemyAI = EnemyAI.Value;
            serializable.AutopilotAI = AutopilotAI.Value;
            serializable.CloneAI = CloneAI.Value;
            serializable.DefensiveDroneAI = DefensiveDroneAI.Value;
            serializable.OffensiveDroneAI = OffensiveDroneAI.Value;
            serializable.StarbaseAI = StarbaseAI.Value;
            OnDataSerialized( ref serializable );
        }
        public ItemId<CombatRules> DefaultCombatRules = ItemId<CombatRules>.Empty;
        public ItemId<BehaviorTreeModel> EnemyAI = ItemId<BehaviorTreeModel>.Empty;
        public ItemId<BehaviorTreeModel> AutopilotAI = ItemId<BehaviorTreeModel>.Empty;
        public ItemId<BehaviorTreeModel> CloneAI = ItemId<BehaviorTreeModel>.Empty;
        public ItemId<BehaviorTreeModel> DefensiveDroneAI = ItemId<BehaviorTreeModel>.Empty;
        public ItemId<BehaviorTreeModel> OffensiveDroneAI = ItemId<BehaviorTreeModel>.Empty;
        public ItemId<BehaviorTreeModel> StarbaseAI = ItemId<BehaviorTreeModel>.Empty;
        public static CombatSettings DefaultValue { get; private set; }
    }
}