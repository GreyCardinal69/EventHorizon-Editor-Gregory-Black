using DatabaseMigration.v1.Enums;
using System;
using System.ComponentModel;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class ShipVisualEffectsSerializable
    {

        public ToggleState LeaveWreck;


        public int CustomExplosionEffect;


        [DefaultValue("")]
        public string CustomExplosionSound;
    }
}