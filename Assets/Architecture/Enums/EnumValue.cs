using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Architecture.Enums
{
    [CreateAssetMenu(fileName = "New Enum Value", menuName = "Architecture/Enum Value")]
    public class EnumValue : ScriptableObject
    {
        public string Name;
    }
}
