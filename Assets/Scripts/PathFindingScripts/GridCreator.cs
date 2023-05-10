using System.Collections.Generic;
using UnityEngine;

namespace PathFindingScripts
{
    public class GridCreator : MonoBehaviour
    {
        private Vector2 _gridWorldSize;
        private Node[,] _grid;
    
        private float _nodeDiameter;
        private float _nodeRadius;
    
        private int _nodeCountX;
        private int _nodeCountY;

        public List<Node> Path; // todo: Для теста отрисовки пути

        public void Initialize(Rectangle gridRectangle)
        {
            _gridWorldSize = new Vector2(gridRectangle.Max.x, gridRectangle.Max.y);
            _nodeRadius = 0.2f;
        
            _nodeDiameter = _nodeRadius * 2;
            _nodeCountX = Mathf.RoundToInt(_gridWorldSize.x / _nodeDiameter);
            _nodeCountY = Mathf.RoundToInt(_gridWorldSize.y / _nodeDiameter);
        }

        public void CreateGrid()
        {
            _grid = new Node[_nodeCountX, _nodeCountY];

            var worldBottomLeft = GetWorldBottomLeft();

            for (var x = 0; x < _nodeCountX; x++)
            {
                for (var y = 0; y < _nodeCountY; y++)
                {
                    var worldPoint = GetNodeWorldPoint(worldBottomLeft, x, y);
                    var walkable = Physics.CheckSphere(worldPoint, _nodeRadius);
                
                    _grid[x, y] = new Node(worldPoint, x, y, walkable);
                }
            }
        }

        private Vector3 GetNodeWorldPoint(Vector3 worldBottomLeft, int x, int y)
        {
            return worldBottomLeft + Vector3.right * (x * _nodeDiameter + _nodeRadius) +
                   Vector3.forward * (y * _nodeDiameter + _nodeRadius);
        }

        private Vector3 GetWorldBottomLeft()
        {
            return transform.position - Vector3.right * _gridWorldSize.x / 2 -
                   Vector3.forward * _gridWorldSize.y / 2;
        }

        public List<Node> GetNeighbours(Node node)
        {
            var neighbours = new List<Node>();

            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    var checkX = node.X + x;
                    var checkY = node.Y + y;

                    var isInArrayX = checkX >= 0 && checkX < _nodeCountX;
                    var isInArrayY = checkY >= 0 && checkY < _nodeCountY;
                    if (isInArrayX && isInArrayY)
                    {
                        neighbours.Add(_grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        public Node NodeFromWorldPoint(Vector3 worldPosition)
        {
            var percentX = worldPosition.x  / _gridWorldSize.x;
            var percentY = worldPosition.z  / _gridWorldSize.y;
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);
            
            var x = Mathf.RoundToInt((_nodeCountX - 1) * percentX);
            var y = Mathf.RoundToInt((_nodeCountY - 1) * percentY);
            return _grid[x, y];
        }
        
        private void OnDrawGizmos()
        {
            if (_grid == null) return;

            foreach (var node in _grid)
            {
                Gizmos.color = node.Walkable ? Color.white : Color.red;
                
                if (Path != null)
                {
                    if (Path.Contains(node))
                    {
                        Gizmos.color = Color.green;
                    }
                }
                Gizmos.DrawCube(node.WorldPosition, Vector3.one * (_nodeDiameter - 0.1f));
            }
        }
    }
}