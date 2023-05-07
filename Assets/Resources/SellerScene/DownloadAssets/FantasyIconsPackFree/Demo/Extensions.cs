using System.Collections.Generic;
using UnityEngine;

namespace Resources.DownloadAssets.FantasyIconsPackFree.Demo
{
    public static class Extensions
    {
        public static List<T> Shuffle<T>(this List<T> source)
        {
            source.Sort((i, j) => Random.Range(0, 3) - 1);

            return source;
        }
    }
}