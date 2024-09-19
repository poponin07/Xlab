using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Golf
{

    public class GameplayeState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;
        public GameState gameOverState;
        public TMP_Text scoreText;

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
        }

        private void OnStickHit()
        {
            scoreText.text = $"Score: {levelController.score}";
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            levelController.enabled = true;
            playerController.enabled = true;
            
            GameEvents.onCollisionStone += OnGameOver;
            GameEvents.onStickHit += OnStickHit;
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            
            levelController.enabled = false;
            playerController.enabled = false;
            
            GameEvents.onCollisionStone -= OnGameOver;
        }
    }
}