using System;
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
        
        [SerializeField]
        private Transform _seeker;

        [SerializeField]
        private Transform _target;

        // [Header("Test")]
        // [SerializeField]
        // private bool _shouldFind;

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
            // _seeker.position = new Vector3(_config.Start.x, 0, _config.Start.y);
            // _target.position = new Vector3(_config.End.x, 0, _config.End.y);
            //
            // _planeCreator.CreatePlanes(_config.Edges);
            //
            // var gridRectangle = _planeCreator.GetGridWorldSize();
            // _gridCreator.transform.position = new Vector3(gridRectangle.Max.x / 2f, 0, gridRectangle.Max.y / 2f);
            // _gridCreator.Initialize(gridRectangle);
            // _gridCreator.CreateGrid();
            //
            //
            // _aStar.Initialize(_gridCreator);
            // _aStar.FindPath(_seeker.position, _target.position);
        }

        // private void Update()
        // {
        //     if (_shouldFind)
        //     {
        //         _aStar.FindPath(_seeker.position, _target.position);
        //     }
        //     
        // }
    }
}