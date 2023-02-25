using System;
using UnityEngine;

namespace NoovisphereStudio
{    
    public class CustomPackageAsmdef : ScriptableObject
    {
        public new string name;
        public References[] references;
        public OptionalUnityReferences[] optionalUnityReferences;
        public IncludePlatforms[] includePlatforms;
        public ExcludePlatforms[] excludePlatforms;
        public bool allowUnsafeCode;
        public bool overrideReferences;
        public PrecompiledReferences[] precompiledReferences;
        public bool autoReferenced;
        public DefineConstraints[] defineConstraints;

    }
    [Serializable]
    public class References
    {

    }

    [Serializable]
    public class OptionalUnityReferences
    {

    }

    [Serializable]
    public class IncludePlatforms
    {

    }

    [Serializable]
    public class ExcludePlatforms
    {

    }

    [Serializable]
    public class PrecompiledReferences
    {

    }

    [Serializable]
    public class DefineConstraints
    {

    }
}

