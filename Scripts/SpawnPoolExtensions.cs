using PathologicalGames;
using UnityEngine;

namespace Hushigoeuf.PathologicalGames
{
    /// <summary>
    /// Простые методы для упрощенной работы с PoolManager.
    /// Источник: http://poolmanager.path-o-logical.com/
    /// </summary>
    public static class SpawnPoolExtensions
    {
        public static Transform HGGetPrefabTransform(this SpawnPool pool, int prefabIndex = 0)
        {
            foreach (var prefab in pool.prefabs.Values)
            {
                if (prefabIndex == 0) return prefab;
                prefabIndex--;
            }

            return null;
        }

        public static GameObject HGGetPrefab(this SpawnPool pool, int prefabIndex = 0) =>
            pool.HGGetPrefabTransform(prefabIndex)?.gameObject;

        public static Transform HGSpawn(this SpawnPool pool, int prefabIndex = 0)
        {
            var prefab = pool.HGGetPrefabTransform(prefabIndex);
            if (prefab != null)
                return pool.Spawn(prefab);
            return null;
        }

        public static T HGSpawn<T>(this SpawnPool pool, int prefabIndex = 0) where T : Component =>
            pool.HGSpawn(prefabIndex)?.gameObject.GetComponent<T>();
    }
}