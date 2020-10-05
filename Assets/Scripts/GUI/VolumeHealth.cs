using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeHealth : MonoBehaviour
{
    public Sprite[] states;
    public Image image;

    public void Start()
    {
        if (image == null) image = GetComponent<Image>();
        
    }

    public void UpdateSprite(float percentage)
    {
        
        int index = Mathf.FloorToInt(percentage * (states.Length-1));
        print(index);
        image.sprite = states[(states.Length-1) - index];
    }
}
