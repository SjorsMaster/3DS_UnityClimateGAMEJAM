using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerMovement Move;
    List<string> Controls = new List<string>();
    Rigidbody2D rb2D;
    bool paused;
    [SerializeField]
    GameObject canvas1, canvas2;

    void Start()
    {
        Move = GetComponent<PlayerMovement>();
        rb2D = GetComponent<Rigidbody2D>();
        Controls.Add("a");
        Controls.Add("y");
        Controls.Add("b");
        Controls.Add("x");
    }

    void Update()
    {
        if (Input.GetKeyDown(Controls[1]) || Input.GetKeyDown(Controls[0])) //Jump
        {
            Move.Jump();
        }
        if (Input.GetKeyDown(Controls[2]) || Input.GetKeyDown(Controls[3])) //
        {
            //something
        }
        if (Input.GetKeyDown("return")) //
        {
            TogglePause();
        }

    }

    void TogglePause()
    {
        paused = !paused; 
        if (paused)
        {
            Time.timeScale = 0;
        }
        if (!paused)
        {
            Time.timeScale = 1;
        }
        canvas1.SetActive(paused);
        canvas2.SetActive(paused);
    }

    public void Swap()
    {
        Controls.Reverse();
    }
}
