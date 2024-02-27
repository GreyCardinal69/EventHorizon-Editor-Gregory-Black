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
    public enum CellType
    {
        [TooltipText( "Nothing." )]
        Empty = '0',
        [TooltipText( "Red layout slots used for weapons." )]
        Weapon = '4',
        [TooltipText( "Blue layout slots used primarily for armor and drones." )]
        Blue = '1',
        [TooltipText( "Green layout slots used for a wide variety of modules." )]
        Green = '2',
        [TooltipText( "Neggas call me THE MAYEZ." )]
        Cyan = '3',
        [TooltipText( "Yellow layout slots usually used for engines." )]
        Engine = '5',
        [TooltipText( "A custom slot type." )]
        Custom = '*',
	}
}
