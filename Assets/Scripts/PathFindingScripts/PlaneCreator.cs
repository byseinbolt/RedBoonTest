using System.Collections.Generic;
using UnityEngine;

namespace PathFindingScripts
{
    public class PlaneCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _planePrefab;
    
        private readonly List<Rectangle> _drewRectangles = new List<Rectangle>();

        public void CreatePlanes(IEnumerable<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (!_drewRectangles.Contains(edge.First))
                {
                    CreatePlane(edge.First);
                    _drewRectangles.Add(edge.First);
                }

                if (!_drewRectangles.Contains(edge.Second))
                {
                    CreatePlane(edge.Second);
                    _drewRectangles.Add(edge.Second);
                }
            }
        }
        
        public Rectangle GetGridWorldSize()
        {
            var minX = float.MaxValue;
            var maxX = float.MinValue;
            var minY = float.MaxValue;
            var maxY = float.MinValue;
        
            foreach (var drewRectangle in _drewRectangles)
            {
                if (drewRectangle.Min.x < minX)
                {
                    minX = drewRectangle.Min.x;
                }
    
                if (drewRectangle.Min.y < minY)
                {
                    minY = drewRectangle.Min.y;
                }
    
                if (drewRectangle.Max.x > maxX)
                {
                    maxX = drewRectangle.Max.x;
                }
    
                if (drewRectangle.Max.y > maxY)
                {
                    maxY = drewRectangle.Max.y;
                }
            }

            var min = new Vector2(minX, minX);
            var max = new Vector2(maxX, maxY);
            var rectangle = new Rectangle(min, max);
            return rectangle;
        }

        private void CreatePlane(Rectangle rectangle)
        {
            var plane = Instantiate(_planePrefab);

            var planeSize = rectangle.Max - rectangle.Min;

            var scale = new Vector3(planeSize.x / 10, 0, planeSize.y / 10);
            plane.transform.localScale = scale;

            var positionX = rectangle.Min.x + planeSize.x / 2;
            var positionY = rectangle.Min.y + planeSize.y / 2;
            var position = new Vector3(positionX, 0, positionY);
            plane.transform.position = position;
        
            plane.AddComponent<BoxCollider>();
        }
    }
}