using UnityEngine;
using UnityEngine.UI;

public class ColourblindUISprites : MonoBehaviour
{
    public Sprite protanopiaImage;
    private Image myIMGComponent;

    public Sprite deuteranopiaImage;
    private Image myIMGComponent2;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ToggleBool2") == 1)
        {
            myIMGComponent = this.GetComponent<Image>();
            myIMGComponent.sprite = protanopiaImage;
        }

        if (PlayerPrefs.GetInt("ToggleBool3") == 1)
        {
            myIMGComponent2 = this.GetComponent<Image>();
            myIMGComponent2.sprite = deuteranopiaImage;
        }
    }
}
