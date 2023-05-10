using System.Collections.Generic;
using UnityEngine;

namespace PathFindingScripts
{
    [CreateAssetMenu(menuName = "PathFinderConfig", fileName = "PathFinderConfig")]
    public class PathFinderConfig : ScriptableObject
    {
        public IEnumerable<Edge> Edges => _edges;
        
        public Vector3 Start => _start;
        
        public Vector3 End => _end;
        
        [SerializeField]
        private List<Edge> _edges;

        [SerializeField]
        private Vector3 _start;
        
        [SerializeField]
        private Vector3 _end;
    }
}