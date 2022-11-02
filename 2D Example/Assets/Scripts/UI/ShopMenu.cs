using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopMenu : MonoBehaviour
{

    static bool isShopOppened = false;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject shopMenuUI;

    [SerializeField] GameObject shopFirstButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isShopOppened)
            {
                CloseShop();
            }
            else
            {
                OpenShop();
            }
        }
    }
    public void OpenShop()
    {
        isShopOppened = true;
        shopMenuUI.SetActive(true);

        //Freeze time.
        Time.timeScale = 0f; 
        EventSystem.current.SetSelectedGameObject(shopFirstButton);
        playerController.DisableMovement();
    }

    public void CloseShop()
    {
        shopMenuUI.SetActive(false);

        //Resume time.
        Time.timeScale = 1f;
        isShopOppened = false;
        playerController.EnableMovement();
    }


}
