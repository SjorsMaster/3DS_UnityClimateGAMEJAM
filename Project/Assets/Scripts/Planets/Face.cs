using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Face : MonoBehaviour {
    Animator animator;
    Image source;

	void Start () {
        animator = GetComponent<Animator>();
        source = GameObject.Find("InnerBar").GetComponent<Image>();
    }

	void Update () {
        animator.SetFloat("Heat", source.fillAmount);
    }
}
