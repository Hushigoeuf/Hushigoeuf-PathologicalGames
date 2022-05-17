using PathologicalGames;
using UnityEngine;

namespace Hushigoeuf.PathologicalGames
{
    /// <summary>
    /// Простые методы для упрощенной работы с PoolManager.
    /// Источник: http://poolmanager.path-o-logical.com/
    /// </summary>
    public static class HG_PG_SpawnPoolExtensions
    {
        /// <summary>
        /// Возвращает Transform префаба из SpawnPool.
        /// </summary>
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

        /// <summary>
        /// Создает копию заданного префаба из SpawnPool и возвращает Transform этой копии.
        /// </summary>
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