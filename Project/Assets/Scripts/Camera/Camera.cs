using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform Target;
    float Speed;

    void Start()
    {
        Target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if ((transform.position.x.ToString("n2") != Target.transform.position.x.ToString("n2")) || (transform.position.y.ToString("n2") != Target.transform.position.y.ToString("n2")))
        {
            Speed += 0.02f / 100;
            transform.position = Vector2.Lerp(transform.position, new Vector2(Target.transform.position.x, Target.transform.position.y), Speed);
        }
        else
        {
            if (Speed > 0.0001)
            {
                Speed -= 0.02f * 10;
            }
        }
        if (Speed > 0.1f)
        {
            Speed = 0.2f;
        }
        if (Speed < 0.0001)
        {
            Speed = 0.0001f;
        }
    } 
}
