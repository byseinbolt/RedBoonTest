using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PathFindingScripts
{
    [Serializable]
    public struct Edge
    {
        public Rectangle First => _first;
        public Rectangle Second => _second;

        public Vector3 Start => _start;
        public Vector3 End => _end;
        
        [SerializeField]
        private Rectangle _first;
        
        [SerializeField]
        private Rectangle _second;
        
        [SerializeField]
        private Vector3 _start;
        
        [SerializeField]
        private Vector3 _end;
    }
}