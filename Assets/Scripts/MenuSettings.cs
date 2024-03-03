using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuSettings : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    public List<TextMeshProUGUI> textList;
    public Slider textSlider;
    public float sliderValue;
    public List<float> defaultTextSize;
    public TextMeshProUGUI[] textToAdd;

    public TMP_Dropdown dropdown;
    public TMP_FontAsset[] fontSelection;
    public TMP_FontAsset currentFont;
    public int currentFontNumb;

    private bool settingsOpen;
    [SerializeField] private GameObject settingsMenu;
    private GameObject mainMenu;
    public bool quitButtonActive;

    // Start is called before the first frame update
    void Start()
    {
        settingsOpen = false;
        MenuSettings menuSettings = FindFirstObjectByType<MenuSettings>();
        if (menuSettings != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (settingsOpen == true)
        {
            settingsMenu = GameObject.Find("SettingsCanvas");
        }

        mainMenu = GameObject.Find("MainCanvas");

        for (int i = 0; i < text.Length; i++)
        {
            DontDestroyOnLoad(textList[i]);
        }
        text = Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI)) as TextMeshProUGUI[];
        textList.AddRange(text);
    }

    public void AddObjects(TextMeshProUGUI textNeeded)
    {
        if (!textList.Contains(textNeeded))
        {
            textList.Add(textNeeded);
        }
    }

    // Update is called once per frame
    void Update()
    {
        text = FindObjectsOfType<TextMeshProUGUI>();
        for (int i = 0; i < text.Length; i++)
        {
            AddObjects(text[i]);
        }

        for (int i = 0; i < text.Length; i++)
        {
            if (defaultTextSize.Count != text.Length)
            {
                defaultTextSize.Add(text[i].fontSize);
            }
        }

        sliderValue = textSlider.value;

        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].fontSize = defaultTextSize[i] * sliderValue;
            textList[i].font = currentFont;
        }
    }

    //This is called when the slider value is changed
    public void TextSliderSize()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].fontSize = defaultTextSize[i] * sliderValue;
        }
    }

    //This is called when the dropdown is changed
    public void FontStyleDropdown()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            currentFont = fontSelection[currentFontNumb];
            currentFontNumb = dropdown.value; 
        }
    }

    //This is called when the settings button is pressed
    public void SettingsButtonPressed()
    {
        settingsOpen = !settingsOpen;

        if (settingsOpen == false)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    //This is called when play button is pressed
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    //This is called when the quit button is pressed
    public void QuitButtonPressed()
    {
        Debug.Break();
        Application.Quit();
    }
}
