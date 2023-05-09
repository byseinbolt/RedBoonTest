using System;
using UnityEngine;

namespace PathFindingScripts
{
    [Serializable]
    public struct Rectangle
    {
        [SerializeField]
        public Vector2 Min;
        
        [SerializeField]
        public Vector2 Max;
    }
}
