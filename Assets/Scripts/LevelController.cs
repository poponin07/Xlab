using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SpawnerStone m_spawnerStone;
        [SerializeField] private float delay = 1f;
        private bool m_isGameOver;

        private void Start()
        {
            StartCoroutine(StartStoneProc());
        }

        public IEnumerator StartStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay);
                m_spawnerStone.Spawn();
            } while (!m_isGameOver);
            
        }
    }
}