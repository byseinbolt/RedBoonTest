using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PathFindingScripts
{
    [Serializable]
    public struct Rectangle
    {
        public Vector2 Min => _min;
        public Vector2 Max => _max;
        
        [SerializeField]
        private Vector2 _min;
        
        [SerializeField]
        private Vector2 _max;

        public Rectangle(Vector2 min, Vector2 max)
        {
            _min = min;
            _max = max;
        }
    }
}
