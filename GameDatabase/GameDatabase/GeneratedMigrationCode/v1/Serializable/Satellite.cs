//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using DatabaseMigration.v1.Enums;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class SatelliteSerializable : SerializableItem
    {
        public SatelliteSerializable()
        {
            ItemType = ItemType.Satellite;
            FileName = "Satellite.json";
        }

        [DefaultValue( "" )]
        public string Name;
        [DefaultValue( "" )]
        public string ModelImage;
        public float ModelScale;
        public SizeClass SizeClass;
        [DefaultValue( "" )]
        public string Layout;
        public BarrelSerializable[] Barrels;
    }
}
