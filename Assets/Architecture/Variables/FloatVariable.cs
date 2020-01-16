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
    [CreateAssetMenu(fileName = "New Float Variable", menuName = "Architecture/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;

        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }

}