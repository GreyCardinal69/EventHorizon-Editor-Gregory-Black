﻿using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class BulletControllerSerializable
    {
        public BulletControllerType Type;
        [DefaultValue( 0.1f )]
        public float StartingVelocityModifier = 0.1f;
        public bool IgnoreRotation;
        public bool SmartAim;
    }
}