using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SpawnerStone m_spawnerStone;
        [SerializeField] private float m_delay =.5f;
        [SerializeField] private float m_delayMax = 3f;
        [SerializeField] private float m_delayMin = .5f;
        [SerializeField] private float m_delayStep = .1f;
        private float m_lastSpawnedTime = 0;

        public int score = 0;
        public int hightScore = 0;

        private List<GameObject> m_stones = new List<GameObject>();

        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            GameEvents.onStickHit += OnStickHit;
            score = 0;
        }

        private void OnDisable()
        {
            GameEvents.onStickHit -= OnStickHit;
        }

        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                var stone = m_spawnerStone.Spawn();
                m_stones.Add(stone);
                m_lastSpawnedTime = Time.time;
                
                RefreshDelay();
            }
        }

        private void OnStickHit()
        {
            score++;
            hightScore = Math.Max(hightScore, score);
            Debug.Log($"Score:{score}  Hight score:{hightScore}");
        }

        public void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone);
            }
        }
        

        private void RefreshDelay()
        {
            m_delay = Random.Range(m_delayMin, m_delayMax);
            m_delayMax = Math.Max(m_delayMin, m_delayMax - m_delayStep);
        }

    }
}
