using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudOffset : MonoBehaviour
{
    [SerializeField]
    float Speed, StartX, Travel = 5.12f, CloudSpeed = 0.005f, Offset = .5f;
    [SerializeField]
    GameObject Cam;
    void Start()
    {
        Cam = GameObject.Find("Upper LCD");
        StartX = transform.position.x;
    }

    void Update()
    {
        transform.Translate((Vector2.left * Speed) * Time.deltaTime);
        if(transform.position.x <= StartX - Travel)
        {
            transform.position = new Vector3(StartX, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Cam.transform.position.y - Offset, CloudSpeed), transform.position.z);
    }
}
