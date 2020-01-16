// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

/******************************************************************************
 * Note from me:
 * If you have not watched this presentation, drop everything and watch it now
 * https://youtu.be/raQ3iHhE_Kk
 * 
 * YOU MUST MASTER THIS CONTENT!
 *****************************************************************************/

using UnityEngine;

namespace Architecture.Variables
{
    [CreateAssetMenu(fileName = "New Boolean Variable", menuName = "Architecture/Boolean Variable")]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        [SerializeField]
        private bool value = false;

        public bool Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }

}