using UnityEngine;

namespace Golf
{
    public class SpawnerStone : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] m_prefabs;
        
        public void Spawn()
        {
            GameObject prefab = GetRandomPrefab();

            if (prefab == null)
            {
                return;
            }

            Instantiate(prefab, transform.position, Quaternion.identity);
        }

        private GameObject GetRandomPrefab()
        {
            if (m_prefabs.Length == 0)
            {
                return null;
            }

            int index = Random.Range(0, m_prefabs.Length);
            return m_prefabs[index];
        }

    }
}