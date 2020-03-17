using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace s3
{
    public class GameManager_TogglePlayer : MonoBehaviour
    {
        public MouseControl lookRoot;
        private GameManager_Master gameManager_Master;

        void OnEnable()
        {
            SetInitialReferences();
            gameManager_Master.MenuToggleEvent += TogglePlayerController;
            gameManager_Master.InvertoryUIToggleEvent += TogglePlayerController;
        }

        void OnDisable()
        {
            gameManager_Master.MenuToggleEvent -= TogglePlayerController;
            gameManager_Master.InvertoryUIToggleEvent -= TogglePlayerController;
        }

        void SetInitialReferences()
        {
            gameManager_Master = GetComponent<GameManager_Master>();

        }

        void TogglePlayerController()
        {
            if(lookRoot!=null)
            {
                lookRoot.enabled = !lookRoot.enabled;
            }
        }

    }
}

