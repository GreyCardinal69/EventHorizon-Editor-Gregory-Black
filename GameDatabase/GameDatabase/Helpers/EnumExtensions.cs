using EditorDatabase.Enums;
using System;
using System.Reflection;
using static EditorDatabase.Property;

namespace GameDatabase.GameDatabase.Helpers
{
    public static class EnumExtensions
    {
        public static string GetTooltipText<T>( this T enumValue ) where T : Enum
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField( enumValue.ToString() );
            TooltipText[] attributes = ( TooltipText[] ) fieldInfo.GetCustomAttributes( typeof( TooltipText ), false );
            if ( attributes.Length > 0 )
            {
                return attributes[0].Text;
            }
            return null;
        }

        public static string GetTooltipTextFromString( string enumValueString )
        {
            if ( Enum.TryParse( enumValueString, out DifficultyClass difficulty ) )
            {
                return difficulty.GetTooltipText();
            }
            return null;
        }
    }
}