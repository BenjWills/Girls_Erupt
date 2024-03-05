using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public bool quitButtonActive;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            Time.timeScale = 1;
        }

        MenuSettings menuSettings = FindFirstObjectByType<MenuSettings>();
        if (menuSettings != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

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

    private void OnLevelWasLoaded(int level)
    {
        text = FindObjectsOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textSlider == null)
        {
            Slider[] sliderArray = Resources.FindObjectsOfTypeAll<Slider>();
            textSlider = sliderArray[0];
        }

        if (dropdown == null)
        {
            TMP_Dropdown[] dropdownArray = Resources.FindObjectsOfTypeAll<TMP_Dropdown>();
            dropdown = dropdownArray[0];
        }

        sliderValue = textSlider.value;

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

        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].fontSize = defaultTextSize[i] * sliderValue;
            textList[i].font = currentFont;
        }
    }
}
