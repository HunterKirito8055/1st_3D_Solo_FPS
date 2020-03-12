using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace s3
{
    public class GameManager_TogglePause : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        private bool isPaused;
        void OnEnable()
        {
            SetInitialReference();
            gameManagerMaster.MenuToggleEvent += TogglePause;
            gameManagerMaster.InvertoryUIToggleEvent += TogglePause;
        }

        void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePause;
            gameManagerMaster.InvertoryUIToggleEvent -= TogglePause;
        }

        void SetInitialReference()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void TogglePause()
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }

            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }

        }
    }
}
