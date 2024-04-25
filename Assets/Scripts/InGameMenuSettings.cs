using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameMenuSettings : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public float money;

    public InputManagerScript inputManagerScript;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public bool settingsOpen;
    public bool isPaused = false;

    private GameObject phoneUI;

    private GameObject upgradeCanavas;
    public Transform mannequinTrans;
    public GameObject mannequin;
    public bool addedMannequin;

    private GameObject shopCanvas;
    public float item1;
    public float item1Cost;

    private GameObject inventoryCanvas;
    public TextMeshProUGUI item1Text;

    public TextMeshProUGUI timeText;
    public string[] times;
    public int timeArrayCount;
    private bool timeCoroutineStarted;

    public TextMeshProUGUI dayText;
    public string[] days;
    public int dayCount;
    private float allDayCount;
    public bool isSunday;
    private bool sundayCheckDone;

    private CustomerSpawner customerSpawner;
    private GameController gc;

    private void Start()
    {
        GameObject[] menuObject = Resources.FindObjectsOfTypeAll<GameObject>();
        customerSpawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();

        for (int i = 0; i < menuObject.Length; i++)
        {
            if (menuObject[i].tag == "Upgrade Menu")
            {
                upgradeCanavas = menuObject[i];
            }
            if (menuObject[i].tag == "Shop Menu")
            {
                shopCanvas = menuObject[i];
            }
            if (menuObject[i].tag == "Inventory Menu")
            {
                inventoryCanvas = menuObject[i];
            }
            if (menuObject[i].tag == "Phone UI")
            {
                phoneUI = menuObject[i];
            }
        }
        timeCoroutineStarted = false;
        isSunday = true;
        sundayCheckDone = false;

    }

    private void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        item1Text.text = "Item 1: " + item1.ToString();
        timeText.text = "Time: " + times[timeArrayCount];
        dayText.text = "Day: " + days[dayCount];

        if (allDayCount % 7 == 0 && sundayCheckDone == false)
        {
            isSunday = true;
            sundayCheckDone = true;
        }

        if (timeCoroutineStarted == false && isSunday == false)
        {
            StartCoroutine(Timer());
        }
    }

    public void OpenSettingsMenu()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        settingsOpen = true;
    }

    public void CloseSettingsMenu()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        settingsOpen = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        isPaused = true;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gc.isPlaying = false;
    }

    public void ToUpgradeMenu()
    {
        upgradeCanavas.SetActive(true);
        inventoryCanvas.SetActive(false);
        shopCanvas.SetActive(false);
    }

    public void CloseUpgradeMenu()
    {
        upgradeCanavas.SetActive(false);
    }

    public void AddMannequins()
    {
        if (addedMannequin == false)
        {
            Instantiate(mannequin, mannequinTrans.position, Quaternion.identity);
            addedMannequin = true;
        }
    }

    public void ToShop()
    {
        shopCanvas.SetActive(true);
        upgradeCanavas.SetActive(false);
        inventoryCanvas.SetActive(false);
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
    }

    public void AddItem1()
    {
        if (money >= item1Cost)
        {
            money -= item1Cost;
            item1 += 1;
        }
    }

    public void OpenInventory()
    {
        inventoryCanvas.SetActive(true);
        upgradeCanavas.SetActive(false);
        shopCanvas.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryCanvas.SetActive(false);
    }

    public void OpenPhone()
    {
        phoneUI.SetActive(true);
    }

    public void ClosePhone()
    {
        phoneUI.SetActive(false);
    }

    IEnumerator Timer()
    {
        customerSpawner.StartSpawning();
        timeCoroutineStarted = true;
        yield return new WaitForSeconds(60);
        timeArrayCount += 1;
        if (timeArrayCount == times.Length)
        {
            customerSpawner.currentSpawned = 0;
            sundayCheckDone = false;
            Debug.Log("New Day");
            dayCount += 1;
            allDayCount += 1;
            customerSpawner.canSpawn = true;
            if (dayCount == days.Length)
            {
                dayCount = 0;
            }
            timeArrayCount = 0;
        }
        timeCoroutineStarted = false;
    }
}
