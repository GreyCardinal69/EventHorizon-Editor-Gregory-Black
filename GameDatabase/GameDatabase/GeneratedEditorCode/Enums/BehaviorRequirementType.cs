//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using static EditorDatabase.Property;

namespace EditorDatabase.Enums
{
	public enum BehaviorRequirementType
	{
		Empty = 0,
		Any = 1,
		All = 2,
		None = 3,
        [TooltipText( "Satisfied if enemy AI level equals to this value" )]
        AiLevel = 5,
        [TooltipText( "Satisfied if enemy AI level is equals or higher than this value" )]
        MinAiLevel = 6,
        SizeClass = 7,
		HasDevice = 10,
		HasDrones = 12,
		HasAnyWeapon = 11,
		CanRepairAllies = 13,
		HasHighRecoilWeapon = 14,
		HasChargeableWeapon = 15,
		HasRemotelyControlledWeapon = 16,
		IsDrone = 50,
		HasKineticResistance = 100,
		[TooltipText("Condition met when EnginePower/sqrt(Mass) > Value")]
		HasHighManeuverability = 101,
    }
}
