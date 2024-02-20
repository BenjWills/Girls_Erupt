using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public List<TextMeshProUGUI> text;
    public Slider textSlider;
    public float sliderValue;
    public List<float> defaultTextSize;
    public TextMeshProUGUI[] textToAdd;

    public TMP_Dropdown dropdown;
    public TMP_FontAsset[] fontSelection;
    public TMP_StyleSheet styleSheet;
    public TMP_Style currentFont;
    public string currentFontName;

    private bool settingsOpen;
    public GameObject[] settingsItems;
    public GameObject[] mainMenuItems;
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
    }
    public void AddText(TextMeshProUGUI textNeeded)
    {
        if (!text.Contains(textNeeded))
        {
            text.Add(textNeeded);
            defaultTextSize.Add(textNeeded.fontSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        textToAdd = FindObjectsOfType<TextMeshProUGUI>();

        for (int i = 0; i < textToAdd.Length; i++)
        {
            AddText(textToAdd[i]);
            DontDestroyOnLoad(text[i]);
        }

        for (int i = 0; i < text.Count; i++)
        {
            if (text[i].font != null)
            {
                text[i].fontStyle = currentFont;
            }
        }

        sliderValue = textSlider.value;

        for (int i = 0; i < text.Count; i++)
        {
            text[i].fontSize = defaultTextSize[i] * sliderValue;
        }
    }

    //This is called when the slider value is changed
    public void TextSliderSize()
    {
        for (int i = 0; i < text.Count; i++)
        {
            text[i].fontSize = defaultTextSize[i] * sliderValue;
        }
    }

    //This is called when the dropdown is changed
    public void FontStyleDropdown()
    {
        for (int i = 0; i < text.Count; i++)
        {
            currentFontName = dropdown.template.ToString();
            currentFont = styleSheet.GetStyle(currentFontName);
            
        }
    }

    //This is called when the settings button is pressed
    public void SettingsButtonPressed()
    {
        settingsOpen = !settingsOpen;

        if (settingsOpen == false)
        {
            for (int i = 0; i < settingsItems.Length; i++)
            {
                settingsItems[i].SetActive(false);
            }
            for (int i = 0; i < mainMenuItems.Length; i++)
            {
                mainMenuItems[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < settingsItems.Length; i++)
            {
                settingsItems[i].SetActive(true);
            }
            for (int i = 0; i < mainMenuItems.Length; i++)
            {
                mainMenuItems[i].SetActive(false);
            }
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
