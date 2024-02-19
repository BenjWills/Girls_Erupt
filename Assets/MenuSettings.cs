using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public static List<TextMeshProUGUI> text;
    public Slider textSlider;
    private float sliderValue;
    public static List<float> defaultTextSize;

    public TMP_Dropdown dropdown;
    public TMP_FontAsset[] fontSelection;
    public TMP_FontAsset currentFont;

    private bool settingsOpen;
    public GameObject settingsTitle;
    public GameObject slider;
    public GameObject sliderTitle;
    public GameObject fontDropdown;
    public GameObject menuTitle;
    public GameObject playButton;
    public GameObject quitButton;

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
        for (int i = 0; i < text.Count; i++)
        {
            text[i].font = currentFont;
        }
        sliderValue = textSlider.value;
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
            text[i].font = fontSelection[dropdown.value];
            currentFont = text[i].font;
        }
    }

    //This is called when the settings button is pressed
    public void SettingsButtonPressed()
    {
        settingsOpen = !settingsOpen;

        if (settingsOpen == false)
        {
            settingsTitle.SetActive(false);
            sliderTitle.SetActive(false);
            slider.SetActive(false);
            fontDropdown.SetActive(false);
            menuTitle.SetActive(true);
            playButton.SetActive(true);
            quitButton.SetActive(true);
        }
        else
        {
            settingsTitle.SetActive(true);
            sliderTitle.SetActive(true);
            slider.SetActive(true);
            fontDropdown.SetActive(true);
            menuTitle.SetActive(false);
            playButton.SetActive(false);
            quitButton.SetActive(false);
        }
    }
}
