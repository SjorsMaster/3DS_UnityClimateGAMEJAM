using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportSun : MonoBehaviour
{
    Image Meter;
    bool firstInput;
    private void Start()
    {
        Meter = GameObject.Find("InnerBar").GetComponent<Image>();
    }
    void Update()
    {
        if (firstInput)
        {
            transform.position = Vector2.Lerp(transform.position, Input.mousePosition, 0.1f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            firstInput = true;
        }
    }
}
