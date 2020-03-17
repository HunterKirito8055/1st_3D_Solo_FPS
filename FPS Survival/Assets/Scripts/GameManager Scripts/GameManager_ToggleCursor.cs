using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_ToggleCursor : MonoBehaviour
    {
        private GameManager_Master gameManager_Master;
        private bool isCursorLocked = true;

        void OnEnable()
        {
            SetInitialReference();
            gameManager_Master.MenuToggleEvent += ToggleCursorState;
            gameManager_Master.InvertoryUIToggleEvent += ToggleCursorState;
        }

        void OnDisable()
        {
            gameManager_Master.MenuToggleEvent -= ToggleCursorState;
            gameManager_Master.InvertoryUIToggleEvent -= ToggleCursorState;
        }

        // Update is called once per frame
        void Update()
        {
            CheckCursorShouldBeLocked();
        }

        void SetInitialReference()
        {
            gameManager_Master = GetComponent<GameManager_Master>();
        }

        void ToggleCursorState()
        {
            isCursorLocked = !isCursorLocked;
        }

        void CheckCursorShouldBeLocked()
        {
            if(isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}

