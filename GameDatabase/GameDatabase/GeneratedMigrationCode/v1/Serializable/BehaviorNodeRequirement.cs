using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

namespace DatabaseMigration.v1.Serializable
{
    [Serializable]
    public struct BehaviorNodeRequirement
    {
        public BehaviorRequirementType Type;
        public DeviceClass DeviceClass;
        public AiDifficultyLevel DifficultyLevel;
        public BehaviorNodeRequirement[] Requirements;
    }
}