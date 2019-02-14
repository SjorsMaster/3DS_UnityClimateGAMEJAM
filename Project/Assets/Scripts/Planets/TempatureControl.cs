using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempatureControl : MonoBehaviour
{
    PlayerMovement Player;
    [SerializeField]
    Image img;
    [SerializeField]
    Transform Planet, Sun, BGSun;
    float Dist, PastDist, MinDist = 135, MaxDist = 155, Ans = 0, SunZoom;
    bool SetBack;

    public Action<float> HeatTemp;

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        img = GameObject.Find("InnerBar").GetComponent<Image>();
        Planet = GameObject.Find("Planet").GetComponent<Transform>();
        Sun = GameObject.Find("Sun").GetComponent<Transform>();
        BGSun = GameObject.Find("BGSun").GetComponent<Transform>();
    }
    
    void Update()
    {
        Dist = Vector2.Distance(new Vector2(Planet.position.x, Planet.position.y), new Vector2(Sun.position.x, Sun.position.y)) - MinDist;
        if (Mathf.Abs(Dist) != Mathf.Abs(PastDist))
        {
            if (SetBack)
            {
            Player.Magic(true);
            }
            SetBack = false;
            PastDist = Dist;
            Ans = Mathf.Abs((Dist / MaxDist) - 1);
            img.fillAmount = Ans;
            Sun.localScale = new Vector2(Ans, Ans);
            SunZoom = Ans;
            BGSun.localScale = new Vector2(Ans /1f, Ans /1f);
            BGSun.transform.position = new Vector3(BGSun.position.x, BGSun.position.y, -SunZoom + 4);
            TempChange(Ans);
        }
        else if (!SetBack)
        {
            Player.Magic(false);
            SetBack = true;
        }

    }

    void TempChange(float Value)
    {
        HeatTemp(Value);
    }
}
