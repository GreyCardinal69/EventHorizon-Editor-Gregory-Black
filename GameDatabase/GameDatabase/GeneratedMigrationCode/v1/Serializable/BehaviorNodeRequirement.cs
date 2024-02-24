﻿using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public class BehaviorNodeRequirementSerializable
    {
        public BehaviorRequirementType Type;
        public DeviceClass DeviceClass;
        public AiDifficultyLevel DifficultyLevel;
        public SizeClass SizeClass;
        [DefaultValue( 1f )]
        public float Value = 1f;
        public BehaviorNodeRequirementSerializable[] Requirements;
    }
}