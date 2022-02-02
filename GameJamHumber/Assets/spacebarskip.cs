using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spacebarskip : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public Image img;
    bool fading;
    private void Update()
    {
        if(fading == true)
        {
            //Fully fade in Image (1) with the duration of 2
            fading = false;
            img.CrossFadeAlpha(1, .5f, false);
        }
        //If the toggle is false, fade out to nothing (0) the Image with a duration of 2
        if (fading == false)
        {
            fading = true;
            img.CrossFadeAlpha(0, .5f, false);
        }
    }
}
