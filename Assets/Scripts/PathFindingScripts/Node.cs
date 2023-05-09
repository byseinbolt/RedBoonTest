using UnityEngine;

namespace PathFindingScripts
{
    public class Node
    {
        public float GCost { get; set; }
        public float FCost { get; set; }
        public Node Parent { get; set; }
        public Vector3 WorldPosition { get;}
        public int X { get;}
        public int Y { get;}
        
        public bool Walkable { get; }
        
        public Node(Vector3 worldPosition, int x, int y, bool walkable)
        {
            WorldPosition = worldPosition;
            X = x;
            Y = y;
            Walkable = walkable;
        }
        
    }
}