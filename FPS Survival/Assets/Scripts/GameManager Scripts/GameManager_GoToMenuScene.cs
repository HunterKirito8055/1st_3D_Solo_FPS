using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_GoToMenuScene : MonoBehaviour
    {
        private GameManager_Master gameManager_Master;

        void OnEnable()
        {
            SetInitialReferences();
            gameManager_Master.GoToMenuSceneEvent += GoToMenuScene;
        }

        void OnDisable()
        {
            gameManager_Master.GoToMenuSceneEvent -= GoToMenuScene;
        }

        void SetInitialReferences()
        {
            gameManager_Master = GetComponent<GameManager_Master>();
        }

        void GoToMenuScene()
        {
            Application.LoadLevel(0);
        }
    }
}

