using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_GameOver : MonoBehaviour
    {
        private GameManager_Master gameManager_Master;
        public GameObject panelGameOver;

        void OnEnable()
        {
            SetInitialReferences();
            gameManager_Master.GameOverEvent += TurnOnGameOverPanel;
        }

        void OnDisable()
        {
            gameManager_Master.GameOverEvent -= TurnOnGameOverPanel;
        }

        void SetInitialReferences()
        {
            gameManager_Master = GetComponent<GameManager_Master>();
        }

        void TurnOnGameOverPanel()
        {
            if(panelGameOver!=null)
            {
                panelGameOver.SetActive(true);
            }
        }
    }

}
