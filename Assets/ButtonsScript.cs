using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public GameObject quitButton;
    public bool quitButtonActive;

    // Start is called before the first frame update
    void Start()
    {
        quitButtonActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && quitButtonActive == false)
        {
            quitButton.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && quitButtonActive == true)
        {
            quitButton.SetActive(true);
        }
    }

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
