using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject volumeMenu;

    public GameObject tradingMenu;

    private GameObject currentMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        System.Array.ForEach(new[] { mainMenu, volumeMenu, tradingMenu }, m => m.SetActive(false));
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        currentMenu.SetActive(false);
        currentMenu = mainMenu;
    }

    public void OpenVolumeMenu()
    {
        mainMenu.SetActive(false);
        volumeMenu.SetActive(true);
        currentMenu = volumeMenu;
    }

    public void OpenTradingMenu()
    {
        mainMenu.SetActive(false);
        tradingMenu.SetActive(true);
        currentMenu = tradingMenu;
    }
}
