using System;
using System.Collections.Generic;
using UnityEngine;

namespace PathFindingScripts
{
    public class AStar : MonoBehaviour
    {
        private List<Node> _openList;
        private HashSet<Node> _closedList;

        private GridCreator _gridCreator;

        public void Initialize(GridCreator gridCreator)
        {
            _gridCreator = gridCreator;
        }

        public List<Node> FindPath(Vector3 startPosition, Vector3 endPosition)
        {
            var startNode = _gridCreator.NodeFromWorldPoint(startPosition);
            var endNode = _gridCreator.NodeFromWorldPoint(endPosition);

            _openList = new List<Node> {startNode};
            _closedList = new HashSet<Node>();
            
            startNode.GCost = 0;
            startNode.FCost = Heuristic(startNode, endNode);

            while (_openList.Count > 0)
            {
                var currentNode = GetLowestFCostNode();
                if (currentNode == endNode)
                {
                    return GetPath(endNode);
                    
                }

                _openList.Remove(currentNode);
                _closedList.Add(currentNode);

                foreach (var neighbor in _gridCreator.GetNeighbours(currentNode))
                {
                    if (_closedList.Contains(neighbor) || !neighbor.Walkable) continue;

                    var tentativeGCost = currentNode.GCost + Distance(currentNode, neighbor);

                    if (!_openList.Contains(neighbor) || tentativeGCost < neighbor.GCost)
                    {
                        neighbor.Parent = currentNode;
                        neighbor.GCost = tentativeGCost;
                        neighbor.FCost = neighbor.GCost + Heuristic(neighbor, endNode);

                        if (!_openList.Contains(neighbor))
                        {
                            _openList.Add(neighbor);
                        }
                    }
                }
            }

            return new List<Node>();
        }

        private Node GetLowestFCostNode()
        {
            var lowestNode = _openList[0];
            for (var i = 1; i < _openList.Count; i++)
            {
                if (_openList[i].FCost < lowestNode.FCost)
                {
                    lowestNode = _openList[i];
                }
            }

            return lowestNode;
        }

        private float Heuristic(Node node1, Node node2)
        {
            var absX = Mathf.Abs(node1.X - node2.X);
            var absY = Mathf.Abs(node1.Y - node2.Y);

            return absX + absY;
        }

        private float Distance(Node node1, Node node2)
        {
            var powX = Mathf.Pow(node1.X - node2.X, 2);
            var powY = Mathf.Pow(node1.Y - node2.Y, 2);

            return Mathf.Sqrt(powX + powY);
        }

        public List<Node> GetPath(Node endNode)
        {
            var path = new List<Node>();
            var currentNode = endNode;
            while (currentNode != null)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            // todo: Для теста
            _gridCreator.Path = path;

            return path;
        }
    }
}