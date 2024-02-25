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
	public enum ActivationType
    {
        [TooltipText( "The weapon will fire automatically whenever possible." )]
        None,
        [TooltipText( "The weapon will fire only manually." )]
        Manual,
        [TooltipText( "The weapon can be set to fire either manually or automatically." )]
        Mixed,
	}
}
