using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveForward : MonoBehaviour {
    [SerializeField]
    float Speed;
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update () {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        if(transform.position.z > 28)
        {
            SceneManager.LoadScene("Loading");
        }
	}
}
