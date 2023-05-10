using System.Collections.Generic;
using UnityEngine;

namespace PathFindingScripts
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private PathFinderConfig _config;

        [SerializeField]
        private PlaneCreator _planeCreator;

        [SerializeField]
        private GridCreator _gridCreator;

        [SerializeField]
        private AStar _aStar;
        
        private IEnumerable<Vector2> _path;
        private void Awake()
        {
            IPathFinder pathFinder = new PathFinder(_planeCreator, _gridCreator, _aStar);
            _path = pathFinder.GetPath(_config.Start, _config.End, _config.Edges);
            var count = 1;
            
            foreach (var vector2 in _path)
            {
                Debug.Log($"Точка номер {count}. Координаты: Х = {vector2.x} Y = {vector2.y}");
                count++;
            }
        }
    }
}