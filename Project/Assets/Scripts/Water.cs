using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    [SerializeField]
    float Heat, FreezingMinimum;
    SpriteRenderer SR;
    [SerializeField]
    Sprite TargetSprite, NormalSprite;
    Collider2D C2d;
    bool Active;

    void Start()
    {
        TargetSprite = Resources.Load<Sprite>("IceSprite");
        C2d = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
        NormalSprite = GetComponent<SpriteRenderer>().sprite;
        TempatureControl Temp = GameObject.Find("Bar").GetComponent<TempatureControl>();
        Temp.HeatTemp += CheckHeat;
    }

    void OnBecameVisible()
    {
        Active = true;
    }
    private void OnBecameInvisible()
    {
        Active = false;
    }
    void Update()
    {
        if (Active)
        {
            if (Heat <= FreezingMinimum)
            {
                C2d.enabled = true;
                SR.sprite = TargetSprite;
            }
            else
            {
                C2d.enabled = false;
                SR.sprite = NormalSprite;
            }
        }
    }

    public void CheckHeat(float Value)
    {
        Heat = Value;
    }
}
