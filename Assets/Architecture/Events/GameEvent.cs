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
 
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Architecture/Game Event", order = 1)]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> eventListeners =
            new List<GameEventListener>();

        public void Raise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
