﻿using DatabaseMigration.v1.Enums;
using DatabaseMigration.v1.Serializable;
using System;

namespace DatabaseMigration.v1
{
    public partial class DatabaseUpgrader
    {
        partial void Migrate_5_6()
        {
            Console.WriteLine( "Database migration: v1.5 -> v1.6" );

            foreach ( var item in Content.AmmunitionList )
                UpgradeAmmunition( item );
        }

        private static void UpgradeBulletBody( BulletBodySerializable bulletBody )
        {
            switch ( bulletBody.Type )
            {
                case BulletTypeObsolete.Projectile:
                    bulletBody.AiBulletBehavior = AiBulletBehavior.Projectile;
                    break;
                // Static is just a projectile unaffected by parent velocity
                case BulletTypeObsolete.Static:
                    bulletBody.AiBulletBehavior = AiBulletBehavior.Projectile;
                    bulletBody.ParentVelocityEffect = 0;
                    break;
                // Homing types
                case BulletTypeObsolete.Homing:
                    bulletBody.AiBulletBehavior = AiBulletBehavior.Homing;
                    break;
                case BulletTypeObsolete.Magnetic:
                    bulletBody.AiBulletBehavior = AiBulletBehavior.Homing;
                    break;
                // Beam type
                case BulletTypeObsolete.Continuous:
                    bulletBody.AiBulletBehavior = AiBulletBehavior.Beam;
                    bulletBody.AttachedToParent = true;
                    break;
                default:
                    throw new DatabaseException();
            }
        }

        private static void UpgradeAmmunition( AmmunitionSerializable ammunition )
        {
            if ( ammunition.Body == null || ammunition.Body.Type == BulletTypeObsolete.Projectile )
                return;

            UpgradeBulletBody( ammunition.Body );
            ammunition.Controller = new BulletControllerSerializable();

            switch ( ammunition.Body.Type )
            {
                // Projectile and static methods don't have special controllers
                case BulletTypeObsolete.Projectile:
                case BulletTypeObsolete.Static:
                    break;
                // Homing controllers
                case BulletTypeObsolete.Homing:
                    ammunition.Controller.Type = BulletControllerType.Homing;
                    ammunition.Controller.StartingVelocityModifier = 0.1f;
                    break;
                case BulletTypeObsolete.Magnetic:
                    ammunition.Controller.Type = BulletControllerType.Homing;
                    ammunition.Controller.IgnoreRotation = true;
                    break;
                // Beam controller
                case BulletTypeObsolete.Continuous:
                    ammunition.Controller.Type = BulletControllerType.Beam;
                    break;
                default:
                    throw new DatabaseException();
            }
        }
    }
}