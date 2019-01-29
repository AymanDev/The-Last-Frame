using UnityEngine;

namespace Enimies
{
    public class EnemySpawner : MonoBehaviour
    {
        public float cellSize = 0.6f;
        public int cellCount = 13;
        public float timer = 2f;

        public GameObject[] enemyPrefabs;

        public bool useY = false;

        private void Start()
        {
            InvokeRepeating("SpawnRandomEnemy", timer, timer);
        }

        private void SpawnRandomEnemy()
        {
            var pos = getRandomPos();
            var randEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            var prefab = enemyPrefabs[randEnemyIndex];
            Instantiate(prefab, transform).transform.position = pos;
        }

        private Vector3 getRandomPos()
        {
            Vector3 randIncreaser;
            if (useY) randIncreaser = new Vector3(0f, Random.Range(0, cellCount) * cellSize);

            else randIncreaser = new Vector3(Random.Range(0, cellCount) * cellSize, 0f);
            return transform.position + randIncreaser;
        }
    }
}