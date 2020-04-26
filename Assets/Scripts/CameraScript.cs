using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Position = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Position.x = Player.transform.position.x;
        Position.y = Player.transform.position.y;
        Position.z = transform.position.z;
        transform.position = Position;
    }
}
