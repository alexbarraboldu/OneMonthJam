using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public Slider Music;
    public Slider SFX;

    // Start is called before the first frame update
    void Start()
    {
        Music.value = AudioManager.Instance.GetVolume("MenuMusic");
        SFX.value = AudioManager.Instance.GetVolume("Fly"); //0.238

    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.Instance.Regulate("MenuMusic", Music.value);
        AudioManager.Instance.Regulate("GameMusic", Music.value);
        if (SFX.value < 0.238f)
        {
            AudioManager.Instance.Regulate("Fly", SFX.value);
        }else if (SFX.value < 0.100f)
        {
            AudioManager.Instance.Regulate("Disparo", SFX.value);
        }else if (SFX.value < 0.200f)
        {
            AudioManager.Instance.Regulate("PowerUp", SFX.value);
        }
        

    }

    public void FullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
