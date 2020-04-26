using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = PlayerManager.Instance.lvl1;
        
    }
}
