using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public GameObject player;
    public float offx = 0f;
    public float offy = 25f;
    public float offz = -35f;
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition.x = player.transform.position.x + offx;
        cameraPosition.y = player.transform.position.y + offy;
        cameraPosition.z = player.transform.position.z + offz;

        transform.position = cameraPosition;

    }
}
