using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    //Skins
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
    public Sprite lvl4;
    public Sprite lvl5;

    public int lvl;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = lvl1;
    }
    
    public void upgradeSkin()
    {
        switch (lvl)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = lvl1;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = lvl2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = lvl3;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = lvl4;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = lvl5;
                break;
            default:
                break;
        }
    }
}
