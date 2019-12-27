using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneImages : MonoBehaviour
{
    public Sprite[] sprites;

    private Image image;

    private int i;

    //Gets image component
    private void Start()
    {
        image = GetComponent<Image>();
    }

    //Changes image in the array to the next one.
    public void ChangeImage()
    {
        i++;
        image.sprite = sprites[i];
    }
}
