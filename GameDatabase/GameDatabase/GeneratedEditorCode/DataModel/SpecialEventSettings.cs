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
	public partial class SpecialEventSettings
	{
		partial void OnDataDeserialized(SpecialEventSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref SpecialEventSettingsSerializable serializable);


		public SpecialEventSettings(SpecialEventSettingsSerializable serializable, Database database)
		{
            XmasCombatRules = database.GetCombatRulesId( serializable.XmasCombatRules );
            EnableXmasEvent = serializable.EnableXmasEvent;
			XmasDaysBefore = new NumericValue<int>(serializable.XmasDaysBefore, 0, 30);
			XmasDaysAfter = new NumericValue<int>(serializable.XmasDaysAfter, 0, 30);
			XmasQuest = database.GetQuestId(serializable.XmasQuest);
			EnableEasterEvent = serializable.EnableEasterEvent;
			EasterDaysBefore = new NumericValue<int>(serializable.EasterDaysBefore, 0, 30);
			EasterDaysAfter = new NumericValue<int>(serializable.EasterDaysAfter, 0, 30);
			EasterQuest = database.GetQuestId(serializable.EasterQuest);
			EnableHalloweenEvent = serializable.EnableHalloweenEvent;
			HalloweenDaysBefore = new NumericValue<int>(serializable.HalloweenDaysBefore, 0, 30);
			HalloweenDaysAfter = new NumericValue<int>(serializable.HalloweenDaysAfter, 0, 30);
			HalloweenQuest = database.GetQuestId(serializable.HalloweenQuest);
            ConvertCreditsToSnowflakes = serializable.ConvertCreditsToSnowflakes;
            OnDataDeserialized(serializable, database);
		}

		public void Save(SpecialEventSettingsSerializable serializable)
		{
            serializable.XmasCombatRules = XmasCombatRules.Value;
            serializable.EnableXmasEvent = EnableXmasEvent;
			serializable.XmasDaysBefore = XmasDaysBefore.Value;
			serializable.XmasDaysAfter = XmasDaysAfter.Value;
			serializable.XmasQuest = XmasQuest.Value;
			serializable.EnableEasterEvent = EnableEasterEvent;
			serializable.EasterDaysBefore = EasterDaysBefore.Value;
			serializable.EasterDaysAfter = EasterDaysAfter.Value;
			serializable.EasterQuest = EasterQuest.Value;
			serializable.EnableHalloweenEvent = EnableHalloweenEvent;
			serializable.HalloweenDaysBefore = HalloweenDaysBefore.Value;
			serializable.HalloweenDaysAfter = HalloweenDaysAfter.Value;
			serializable.HalloweenQuest = HalloweenQuest.Value;
            serializable.ConvertCreditsToSnowflakes = ConvertCreditsToSnowflakes;
            OnDataSerialized(ref serializable);
		}
        public ItemId<CombatRules> XmasCombatRules = ItemId<CombatRules>.Empty;
        public bool EnableXmasEvent;
		public NumericValue<int> XmasDaysBefore = new NumericValue<int>(0, 0, 30);
		public NumericValue<int> XmasDaysAfter = new NumericValue<int>(0, 0, 30);
		public ItemId<QuestModel> XmasQuest = ItemId<QuestModel>.Empty;
		public bool EnableEasterEvent;
		public NumericValue<int> EasterDaysBefore = new NumericValue<int>(0, 0, 30);
		public NumericValue<int> EasterDaysAfter = new NumericValue<int>(0, 0, 30);
		public ItemId<QuestModel> EasterQuest = ItemId<QuestModel>.Empty;
		public bool EnableHalloweenEvent;
        public string ConvertCreditsToSnowflakes;
        public NumericValue<int> HalloweenDaysBefore = new NumericValue<int>(0, 0, 30);
		public NumericValue<int> HalloweenDaysAfter = new NumericValue<int>(0, 0, 30);
		public ItemId<QuestModel> HalloweenQuest = ItemId<QuestModel>.Empty;

		public static SpecialEventSettings DefaultValue { get; private set; }
	}
}
