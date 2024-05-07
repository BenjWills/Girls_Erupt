using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Audio;

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
    public Canvas phoneUI;

    public InputManagerScript inputManagerScript;
    public InGameMenuSettings iGMenuSettings;

    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public CinemachineVirtualCamera mainMenuCam;
    public CinemachineVirtualCamera gameCam;

    public bool isPlaying;
    public bool inSettings;

    public Transform gameCamLookAt;

    public GameObject player;

    private float fieldOfVisionValue;
    public Slider sliderFOV;
    public TextMeshProUGUI sliderNumbText;

    public Slider musicSlider;
    public AudioMixer mainMixer;
    public Slider soundSlider;

    const string MIXER_MUSIC = "Music Volume";
    const string MIXER_SOUND = "Sound Volume";

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

        Canvas[] menuObject = Resources.FindObjectsOfTypeAll<Canvas>();
        TMP_Dropdown[] dropdownObject = Resources.FindObjectsOfTypeAll<TMP_Dropdown>();
        Slider[] slider = Resources.FindObjectsOfTypeAll<Slider>();

        for (int i = 0; i < menuObject.Length; i++)
        {
            if (menuObject[i].tag == "Pause Menu")
            {
                pauseMenu = menuObject[i];
            } 
            if (menuObject[i].tag == "Phone")
            {
                phoneUI = menuObject[i];
            }
        }
        for (int i = 0; i < dropdownObject.Length; i++)
        {
            if (dropdownObject[i].name == "Settings Font Dropdown")
            {
                dropdown = dropdownObject[i];
            }
        }
        for (int i = 0; i < slider.Length; i++)
        {
            if (slider[i].name == "Settings Text Size Slider")
            {
                textSlider = slider[i];
            }
            if (slider[i].name == "Music Slider")
            {
                musicSlider = slider[i];
            }
            if (slider[i].name == "Sound Slider")
            {
                soundSlider = slider[i];
            }
            if (slider[i].name == "FOV Slider")
            {
                sliderFOV = slider[i];
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

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundSlider.onValueChanged.AddListener(SetSoundVolume);

        fieldOfVisionValue = sliderFOV.value;
        sliderNumbText.text = "FOV: " + fieldOfVisionValue.ToString();
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

    void SetMusicVolume(float value)
    {
        mainMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetSoundVolume(float value)
    {
        mainMixer.SetFloat(MIXER_SOUND, Mathf.Log10(value) * 20);
    }

    public void SetFOV()
    {
        fieldOfVisionValue = sliderFOV.value;
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].m_Lens.FieldOfView = fieldOfVisionValue;
        }
        sliderNumbText.text = "FOV: " + fieldOfVisionValue.ToString();
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
        }
    }

    public void FontStyleDropdown()
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentFontNumb = dropdown.value;
            currentFont = fontSelection[currentFontNumb];
            text[i].font = currentFont;
        }
    }
}
