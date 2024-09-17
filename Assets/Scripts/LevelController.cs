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

        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            GameEvents.onCollisionStone += GameOver;
            GameEvents.onStickHit += OnStickHit;
        }

        private void OnDisable()
        {
            GameEvents.onCollisionStone -= GameOver;
            GameEvents.onStickHit -= OnStickHit;
        }

        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                m_spawnerStone.Spawn();
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
        
        private void GameOver()
        {
            Debug.Log("Game over!");
            enabled = false;
        }

        private void RefreshDelay()
        {
            m_delay = Random.Range(m_delayMin, m_delayMax);
            m_delayMax = Math.Max(m_delayMin, m_delayMax - m_delayStep);
        }

    }
}
