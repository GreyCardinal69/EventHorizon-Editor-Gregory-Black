
using EditorDatabase.Enums;
using System;
using System.ComponentModel;

namespace EditorDatabase.Serializable
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
