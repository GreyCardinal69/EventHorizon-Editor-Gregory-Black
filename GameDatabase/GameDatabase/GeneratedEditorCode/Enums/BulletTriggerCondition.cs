//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

namespace EditorDatabase.Enums
{
    public enum BulletTriggerCondition
	{
        [TooltipText( "Does nothing." )]
		Undefined,
        [TooltipText( "Triggers on creation of parent ammunition." )]
		Created,
        [TooltipText( "Triggers when ammunition ceases to exist by any means." )]
		Destroyed,
        [TooltipText( "Triggers when the parent ammunition makes contact with a target." )]
		Hit,
        [TooltipText( "Triggers when ammunition is destroyed by Point Defense device." )]
		Disarmed,
        [TooltipText( "Triggers when parent ammo lifetime ends or maximum range is reached." )]
		Expired,
        [TooltipText( "Triggers when control is released over Managable type weapon." )]
		Detonated,
        [TooltipText( "Triggers when parent ammunition reaches and tries to surpass its MaxNestingLevel." )]
		OutOfAmmo,
        [TooltipText( "Triggers repeatedly after specified cooldown time ends." )]
        Cooldown,
    }
}
