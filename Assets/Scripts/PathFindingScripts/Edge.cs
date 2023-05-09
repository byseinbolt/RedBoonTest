using System;
using UnityEngine;

namespace PathFindingScripts
{
    [Serializable]
    public struct Edge
    {
        [SerializeField]
        public Rectangle First;
        
        [SerializeField]
        public Rectangle Second;
        
        [SerializeField]
        public Vector3 Start;
        
        [SerializeField]
        public Vector3 End;
    }
}