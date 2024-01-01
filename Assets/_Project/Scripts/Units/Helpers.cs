using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Helpers 
    {
        public static void Quitgame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
     }
}
