using EditorDatabase.Serializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDatabase.Serializable
{
    [Serializable]
    public class ComponentGroupTagSerializable : SerializableItem
    {

        public int MaxInstallableComponents;
    }
}