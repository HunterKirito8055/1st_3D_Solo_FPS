using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameManager_Master;

        // Start is called before the first frame update
        void Start()
        {
            SetInitialReference();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInvertoryUIToggleRequest();
        }

        void SetInitialReference()
        {
            gameManager_Master = GetComponent<GameManager_Master>();

            if (toggleInventoryButton == "")
            {
                Debug.LogWarning("Please Type in the name of the button used to toggle the inventory");
                this.enabled = false;

            }
        }

        void CheckForInvertoryUIToggleRequest()
        {
            if (Input.GetButtonUp(toggleInventoryButton) && !gameManager_Master.isMenuON && !gameManager_Master.isGameOver && hasInventory)
            {
                ToggleInventoryUI();
            }
        }

        void ToggleInventoryUI()
        {
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameManager_Master.isInvertoryUIOn = !gameManager_Master.isInvertoryUIOn;
                gameManager_Master.CallEventInventoryUIToggle();
            }
        }
    }

}
