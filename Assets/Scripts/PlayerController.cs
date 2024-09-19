using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player m_player;

        private void Start()
        {
            if (m_player == null)
            {
                Debug.Log("Player is null");
            }
        }

        private void Update()
        {
           // m_player.SetDown(Input.GetMouseButton(0));
        }

        public void OnUp()
        {
            m_player.SetDown(false);
        }
        
        public void OnDown()
        {
            m_player.SetDown(true);
        }
    }
}