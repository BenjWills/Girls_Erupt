using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SliderDontDestroy currentSlider = FindFirstObjectByType<SliderDontDestroy>();

        if (currentSlider != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
