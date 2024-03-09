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
    public float[] defaultTextSize;
    public float textSliderValue;

    public TMP_Dropdown dropdown;
    public TMP_FontAsset[] fontSelection;
    public TMP_FontAsset currentFont;
    public int currentFontNumb;

    public GameObject settingsMenu;
    public GameObject mainMenu;
    public GameObject pauseMenu;

    public GameObject inputManagerScript;
    public InGameMenuSettings iGMenuSettings;

    public List<CinemachineVirtualCamera> cameras;
    public CinemachineVirtualCamera mainMenuCam;
    public CinemachineVirtualCamera gameCam;

    public bool isPlaying;
    public bool inSettings;

    public BaseStates currentState;
    public readonly MenuState ms = new MenuState();
    public readonly GameState gs = new GameState();
    public readonly SettingsState ss = new SettingsState();

    private void Awake()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuCam = GameObject.FindGameObjectWithTag("Main Menu Cam").GetComponent<CinemachineVirtualCamera>();
        gameCam = GameObject.FindGameObjectWithTag("Game Cam").GetComponent<CinemachineVirtualCamera>();
        inputManagerScript = GameObject.FindGameObjectWithTag("Input Manager");
        iGMenuSettings = GameObject.FindGameObjectWithTag("In Game Menu Settings").GetComponent<InGameMenuSettings>();
        pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");

        text = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();

        cameras.Add(mainMenuCam);
        cameras.Add(gameCam);

        textSliderValue = textSlider.value;
        for (int i = 0; i < text.Length; i++)
        {
            defaultTextSize[i] = text[i].fontSize;
        }

        isPlaying = false;

        inputManagerScript.SetActive(false);
        iGMenuSettings.enabled = false;

        TransitionToState(ms);
    }

    // Update is called once per frame
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

    //This is called when the dropdown is changed
    public void FontStyleDropdown()
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentFont = fontSelection[currentFontNumb];
            currentFontNumb = dropdown.value;
        }
    }
}
