﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameDatabase.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point ShipEditorPosition {
            get {
                return ((global::System.Drawing.Point)(this["ShipEditorPosition"]));
            }
            set {
                this["ShipEditorPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("800, 600")]
        public global::System.Drawing.Size ShipEditorSize {
            get {
                return ((global::System.Drawing.Size)(this["ShipEditorSize"]));
            }
            set {
                this["ShipEditorSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("272")]
        public int ShipEditorHorizontalSplitter {
            get {
                return ((int)(this["ShipEditorHorizontalSplitter"]));
            }
            set {
                this["ShipEditorHorizontalSplitter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("364")]
        public int ShipEditorVerticalSplitter {
            get {
                return ((int)(this["ShipEditorVerticalSplitter"]));
            }
            set {
                this["ShipEditorVerticalSplitter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point EditorPosition {
            get {
                return ((global::System.Drawing.Point)(this["EditorPosition"]));
            }
            set {
                this["EditorPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400, 400")]
        public global::System.Drawing.Size EditorSize {
            get {
                return ((global::System.Drawing.Size)(this["EditorSize"]));
            }
            set {
                this["EditorSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("800, 600")]
        public global::System.Drawing.Size MainSize {
            get {
                return ((global::System.Drawing.Size)(this["MainSize"]));
            }
            set {
                this["MainSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point MainPosition {
            get {
                return ((global::System.Drawing.Point)(this["MainPosition"]));
            }
            set {
                this["MainPosition"] = value;
            }
        }
    }
}