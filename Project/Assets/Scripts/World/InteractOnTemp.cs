using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnTemp : MonoBehaviour {
    bool Active;
    [SerializeField]
    float MeltingMinimum = 0.75f, Heat, StartPosX, StartPosY, StartPosZ;
    float ScaleVal, DefaultX, DefaultY;
    
    Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        StartPosX = transform.position.x;
        StartPosY = transform.position.y;
        StartPosZ = transform.position.z;
        DefaultX = transform.localScale.x;
        DefaultY = transform.localScale.y;
        TempatureControl Temp = GameObject.Find("Bar").GetComponent<TempatureControl>();
        Temp.HeatTemp += CheckHeat;        
    }

    void OnBecameVisible()
    {
        Active = true;
        ScaleVal = transform.localScale.y;
    }
    private void OnBecameInvisible()
    {
        Active = false;
        transform.position = new Vector3(StartPosX, StartPosY, StartPosZ);
        transform.localScale = new Vector2(DefaultX, DefaultY);
        if (rig != null)
        {
            rig.gravityScale = 1;
        }
    }

    void Update () {
        if (Active)
        {
            if (transform.localScale.y >= 0 && Heat >= MeltingMinimum)
            {
                ScaleVal -= (Heat - MeltingMinimum) * Time.deltaTime;
                if (rig == null)
                {
                    transform.Translate(Vector2.up * ((Heat - MeltingMinimum) * Time.deltaTime) / 3);
                }
                transform.localScale = new Vector2(DefaultX, ScaleVal);
            }
            if(transform.localScale.y < 0)
            {
                if (rig != null)
                {
                    rig.gravityScale = 0;
                    rig.velocity = new Vector2(0, 0);
                }
                else
                {
                    transform.position = new Vector3(StartPosX, StartPosY, StartPosZ);
                }
                transform.localScale = new Vector2(DefaultX, 0);
            }
        }
	}

    public void CheckHeat(float Value)
    {
        Heat = Value;
    }
}
