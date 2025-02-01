using EditorDatabase.Enums;
using EditorDatabase.Model;
using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
    public class ShipVisualEffects
    {
        public static ShipVisualEffects Create(ShipVisualEffectsSerializable serializable, Database database)
        {
            if (serializable == null)
            {
                return ShipVisualEffects.DefaultValue;
            }
            return new ShipVisualEffects(serializable, database);
        }

        public ShipVisualEffects()
        {
        }

        private ShipVisualEffects(ShipVisualEffectsSerializable serializable, Database database)
        {
            this.LeaveWreck = serializable.LeaveWreck;
            this.CustomExplosionEffect = database.GetVisualEffectId(serializable.CustomExplosionEffect);
            this.CustomExplosionSound = serializable.CustomExplosionSound;
        }

        public ShipVisualEffectsSerializable Serialize()
        {
            return new ShipVisualEffectsSerializable
            {
                LeaveWreck = this.LeaveWreck,
                CustomExplosionEffect = this.CustomExplosionEffect.Value,
                CustomExplosionSound = this.CustomExplosionSound
            };
        }

        public static ShipVisualEffects DefaultValue { get; private set; }

        public ToggleState LeaveWreck;

        public ItemId<VisualEffect> CustomExplosionEffect = ItemId<VisualEffect>.Empty;

        public string CustomExplosionSound;
    }
}
