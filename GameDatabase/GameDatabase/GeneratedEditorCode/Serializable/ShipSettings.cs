//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class ShipSettingsSerializable : SerializableItem
    {
        public int ShipExplosionEffect;


        [DefaultValue("")]
        public string ShipExplosionSound;


        public int DroneExplosionEffect;


        [DefaultValue("")]
        public string DroneExplosionSound;
        public bool DisableCellsExpansions;
        public float DefaultWeightPerCell;
        public float MinimumWeightPerCell;
        public float BaseArmorPoints;
        public float ArmorPointsPerCell;
        public float ArmorRepairCooldown;
        public float BaseEnergyPoints;
        public float BaseEnergyRechargeRate;
        public float EnergyRechargeCooldown;
        public float BaseShieldRechargeRate;
        public float ShieldRechargeCooldown;
        public float BaseDroneReconstructionSpeed;
        [DefaultValue( 0.9f )]
        public float ShieldCorrosiveResistance = 0.9f;
        [DefaultValue( 30f )]
        public float MaxVelocity = 30f;
        [DefaultValue( 30f )]
        public float MaxAngularVelocity = 30f;
        [DefaultValue( 300f )]
        public float MaxAcceleration = 300f;
        [DefaultValue( 300f )]
        public float MaxAngularAcceleration = 300f;
    }
}
