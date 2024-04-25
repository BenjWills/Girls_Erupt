using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    public Slider textSlider;
    public List<float> defaultTextSize = new List<float>();
    public List<float> ppTextSize = new List<float>();
    public List<string> ppTextSizeString = new List<string>();
    public float textSliderValue;

    public TMP_Dropdown dropdown;
    public TMP_FontAsset[] fontSelection;
    public TMP_FontAsset currentFont;
    public int currentFontNumb;

    public GameObject allCanvas;
    public GameObject settingsMenu;
    public GameObject mainMenu;

    public GameObject iGMenu;
    public Canvas pauseMenu;
    public GameObject phoneUI;

    public InputManagerScript inputManagerScript;
    public InGameMenuSettings iGMenuSettings;

    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public CinemachineVirtualCamera mainMenuCam;
    public CinemachineVirtualCamera gameCam;

    public bool isPlaying;
    public bool inSettings;

    public Transform gameCamLookAt;

    public GameObject player;

    public BaseStates currentState;
    public readonly MenuState ms = new MenuState();
    public readonly GameState gs = new GameState();
    public readonly SettingsState ss = new SettingsState();

    private void Awake()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        mainMenuCam = GameObject.FindGameObjectWithTag("Main Menu Cam").GetComponent<CinemachineVirtualCamera>();
        gameCam = GameObject.FindGameObjectWithTag("Game Cam").GetComponent<CinemachineVirtualCamera>();
        inputManagerScript = GameObject.Find("Player").GetComponent<InputManagerScript>();
        iGMenuSettings = GameObject.FindGameObjectWithTag("In Game Menu Settings").GetComponent<InGameMenuSettings>();
        iGMenu = GameObject.FindGameObjectWithTag("In Game Menu");
        player = GameObject.Find("Player");
        phoneUI = GameObject.Find("Phone");

        Canvas[] menuObject = Resources.FindObjectsOfTypeAll<Canvas>();
        TMP_Dropdown[] dropdownObject = Resources.FindObjectsOfTypeAll<TMP_Dropdown>();

        for (int i = 0; i < menuObject.Length; i++)
        {
            if (menuObject[i].tag == "Pause Menu")
            {
                pauseMenu = menuObject[i];
            }
        }
        for (int i = 0; i < dropdownObject.Length; i++)
        {
            if (dropdownObject[i].name == "Settings Font Dropdown")
            {
                dropdown = dropdownObject[i];
            }
        }

        text = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();

        cameras.Add(mainMenuCam);
        cameras.Add(gameCam);

        for (int i = 0; i < text.Length; i++)
        {
            defaultTextSize.Add(text[i].fontSize);
        }

        isPlaying = false;

        inputManagerScript.enabled = false;
        iGMenuSettings.enabled = false;

        TransitionToState(ms);

        for (int i = 0; i < text.Length; i++)
        {
            text[i].font = fontSelection[PlayerPrefs.GetInt("Text Font")];
        }

        int tempPPTextSizeCount = PlayerPrefs.GetInt("Text Size Count");
        for (int i = 0; i < tempPPTextSizeCount; i++)
        {
            ppTextSizeString.Add(PlayerPrefs.GetString("Text Size_" + i));
        }

        for (int i = 0; i < text.Length; i++)
        {
            text[i].fontSize = float.Parse(ppTextSizeString[i]);
        }
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(BaseStates state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void SettingsOpenClose()
    {
        inSettings = !inSettings;
    }

    public void PlayGame()
    {
        isPlaying = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Break();
    }

    public void TextSliderChange()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textSliderValue = textSlider.value;
            text[i].fontSize = defaultTextSize[i] * textSliderValue;
            ppTextSize.Add(text[i].fontSize);

            ppTextSizeString[i] = ppTextSize[i].ToString();
            for (int i2 = 0; i2 < ppTextSizeString.Count; i2++)
            {
                PlayerPrefs.SetString("Text Size_" + i2, ppTextSizeString[i2]);
            }
            PlayerPrefs.SetInt("Text Size Count", ppTextSize.Count);
        }
    }

    public void FontStyleDropdown()
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (PlayerPrefs.GetInt("Text Font") == 1)
            {
                currentFontNumb = 1;
            }
            else
            {
                currentFontNumb = dropdown.value;
                PlayerPrefs.SetInt("Text Font", currentFontNumb);
            }
            currentFont = fontSelection[PlayerPrefs.GetInt("Text Font")];
            text[i].font = currentFont;
        }
    }
}
