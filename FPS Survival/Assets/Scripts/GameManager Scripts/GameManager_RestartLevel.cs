using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {
        private GameManager_Master gameManager_Master;

        void OnEnable()
        {
            SetInitialReferences();
            gameManager_Master.RestartLevelEvent += RestartLevel;
        }

        void OnDisable()
        {
            gameManager_Master.RestartLevelEvent -= RestartLevel;
        }

        void SetInitialReferences()
        {
            gameManager_Master = GetComponent<GameManager_Master>();
        }

        void RestartLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}

