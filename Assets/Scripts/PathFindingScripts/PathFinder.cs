using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PathFindingScripts
{
    public class PathFinder : IPathFinder
    {
        private readonly PlaneCreator _planeCreator;
        private readonly GridCreator _gridCreator;
        private readonly AStar _aStar;

        public PathFinder(PlaneCreator planeCreator, GridCreator gridCreator, AStar aStar)
        {
            _planeCreator = planeCreator;
            _gridCreator = gridCreator;
            _aStar = aStar;
        }
        
        public IEnumerable<Vector2> GetPath(Vector2 A, Vector2 C, IEnumerable<Edge> edges)
        {
            var startPosition = new Vector3(A.x, 0, A.y);
            var finishPosition = new Vector3(C.x, 0, C.y);
            _planeCreator.CreatePlanes(edges);
            
             var gridRectangle = _planeCreator.GetGridWorldSize();
            _gridCreator.transform.position = new Vector3(gridRectangle.Max.x / 2f, 0, gridRectangle.Max.y / 2f);
            _gridCreator.Initialize(gridRectangle);
            _gridCreator.CreateGrid();
            
            _aStar.Initialize(_gridCreator);
            
            var pathNodes = _aStar.FindPath(startPosition, finishPosition);
            foreach (var pathNode in pathNodes)
            {
                yield return new Vector2(pathNode.X, pathNode.Y);
            }
        }
    }
}
