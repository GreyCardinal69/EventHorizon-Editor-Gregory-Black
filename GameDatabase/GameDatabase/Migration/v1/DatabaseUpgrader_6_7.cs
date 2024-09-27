using DatabaseMigration.v1.Enums;
using DatabaseMigration.v1.Serializable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace DatabaseMigration.v1
{
    public partial class DatabaseUpgrader
    {
        partial void Migrate_6_7()
        {
            Console.WriteLine( "Database migration: v1.6 -> v1.7" );
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for ( int i = 0; i < this.Content.DeviceList.Count; i++ )
            {
                dictionary.Add( this.Content.DeviceList[i].Id, i );
            }
            DatabaseUpgrader.ComponentGroupTags componentGroupTags = new DatabaseUpgrader.ComponentGroupTags();
            foreach ( ComponentSerializable componentSerializable in this.Content.ComponentList )
            {
                ComponentRestrictionsSerializable restrictions = componentSerializable.Restrictions;
                string text = ( restrictions != null ) ? restrictions.UniqueComponentTag : null;
                int maxComponents = ( componentSerializable.Restrictions != null ) ? componentSerializable.Restrictions.MaxComponentAmount : 0;
                if ( !string.IsNullOrEmpty( text ) )
                {
                    int componentGroupTag = componentGroupTags.Create( text, maxComponents );
                    componentSerializable.Restrictions.ComponentGroupTag = componentGroupTag;
                    componentSerializable.Restrictions.UniqueComponentTag = null;
                }
                else if ( componentSerializable.DeviceId != 0 )
                {
                    int index = 0;
                 /*   if ( !dictionary.TryGetValue( componentSerializable.DeviceId, out index ) )
                    {
                        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler( 22, 2 );
                        defaultInterpolatedStringHandler.AppendLiteral( "Unknown device ID " );
                        defaultInterpolatedStringHandler.AppendFormatted<int>( componentSerializable.DeviceId );
                        defaultInterpolatedStringHandler.AppendLiteral( " in " );
                        defaultInterpolatedStringHandler.AppendFormatted( componentSerializable.FileName );
                        throw new DatabaseException( defaultInterpolatedStringHandler.ToStringAndClear() );
                    }*/
                    DeviceSerializable deviceSerializable = this.Content.DeviceList[index];
                    ComponentRestrictionsSerializable restrictions2 = componentSerializable.Restrictions;
                    int maxComponents2 = ( restrictions2 != null ) ? restrictions2.MaxComponentAmount : 0;
                    int num = 0;
                    switch ( deviceSerializable.DeviceClass )
                    {
                        case DeviceClass.Accelerator:
                        case DeviceClass.Decoy:
                        case DeviceClass.Ghost:
                        case DeviceClass.GravityGenerator:
                        case DeviceClass.PointDefense:
                        case DeviceClass.RepairBot:
                        case DeviceClass.Detonator:
                        case DeviceClass.Teleporter:
                        case DeviceClass.Brake:
                        case DeviceClass.Fortification:
                        case DeviceClass.ToxicWaste:
                            num = componentGroupTags.Create( deviceSerializable.DeviceClass.ToString(), maxComponents2 );
                            break;
                        case DeviceClass.EnergyShield:
                        case DeviceClass.PartialShield:
                            num = componentGroupTags.Create( DeviceClass.EnergyShield.ToString(), maxComponents2 );
                            break;
                        case DeviceClass.Stealth:
                        case DeviceClass.SuperStealth:
                            num = componentGroupTags.Create( DeviceClass.Stealth.ToString(), maxComponents2 );
                            break;
                        case DeviceClass.WormTail:
                            num = componentGroupTags.Create( DeviceClass.WormTail.ToString(), maxComponents2 );
                            break;
                    }
                    if ( num > 0 )
                    {
                        ComponentSerializable componentSerializable2 = componentSerializable;
                        ComponentRestrictionsSerializable componentRestrictionsSerializable;
                        if ( ( componentRestrictionsSerializable = componentSerializable2.Restrictions ) == null )
                        {
                            componentRestrictionsSerializable = ( componentSerializable2.Restrictions = new ComponentRestrictionsSerializable() );
                        }
                        componentRestrictionsSerializable.ComponentGroupTag = num;
                    }
                }
            }
            this.Content.ComponentGroupTagList.AddRange( componentGroupTags.Serialize() );
        }

        private class ComponentGroupTags
        {

            public int Create( string key, int maxComponents )
            {
                ValueTuple<int, int> valueTuple;
                if ( !this._tags.TryGetValue( key, out valueTuple ) )
                {
                    valueTuple = new ValueTuple<int, int>( this._tags.Count + 1, Math.Max( 1, maxComponents ) );
                }
                else if ( valueTuple.Item2 < maxComponents )
                {
                    valueTuple.Item2 = maxComponents;
                }
                this._tags[key] = valueTuple;
                return valueTuple.Item1;
            }


            public IEnumerable<ComponentGroupTagSerializable> Serialize()
            {
                foreach ( KeyValuePair<string, ValueTuple<int, int>> keyValuePair in this._tags )
                {
                    ComponentGroupTagSerializable componentGroupTagSerializable = new ComponentGroupTagSerializable();
                    componentGroupTagSerializable.Id = keyValuePair.Value.Item1;

                    // Use string interpolation or concatenation
                    string formattedFileName = $"Tag_{keyValuePair.Value.Item1}_{DatabaseUpgrader.ComponentGroupTags.RemoveInvalidChars( keyValuePair.Key )}.json";

                    componentGroupTagSerializable.FileName = formattedFileName;
                    componentGroupTagSerializable.MaxInstallableComponents = keyValuePair.Value.Item2;

                    yield return componentGroupTagSerializable;
                }
                Dictionary<string, ValueTuple<int, int>>.Enumerator enumerator = default( Dictionary<string, ValueTuple<int, int>>.Enumerator );
                yield break;
                yield break;
            }


            private static string RemoveInvalidChars( string filename )
            {
                return string.Concat( filename.Split( Path.GetInvalidFileNameChars() ) );
            }
           
            private readonly Dictionary<string, ValueTuple<int, int>> _tags = new Dictionary<string, ValueTuple<int, int>>();
        }
    }
}