using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    int layerMask = ~(1 << 8);

    Animator Anim;
    AudioSource dead, JumpSound;

    [SerializeField]
    float ForceAmmount = 200, WalkSpeed = 10, RayCastLenght = .25f, direC = 1, spawnx, spawny;

    [SerializeField]
    string WalkName="Walk", JumpName = "Jump", MagicName = "Magic", IdleName = "Idle";
    bool Jumping = true, CanWalkL, CanWalkR;

    private void Start()
    {
        JumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        dead = GetComponent<AudioSource>();

        spawnx = transform.position.x;
        spawny = transform.position.y;

        Anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(transform.position.y <= 300)
        {
            dead.Play();
            transform.position = new Vector3(spawnx, spawny, transform.position.z);
        }

        transform.localScale = new Vector2(Mathf.Lerp(transform.localScale.x, direC, .5f), 1);

        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, RayCastLenght, layerMask);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, RayCastLenght, layerMask);
        RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, RayCastLenght / 2, layerMask);

        if (hitL.collider == null)
        {
            if ((Input.GetKey("[4]") || Input.GetKey("left")) /*&& !Anim.GetCurrentAnimatorStateInfo(0).IsName(MagicName)*/)//WalkLeft
            {
                transform.Translate(new Vector2(-1, 0) / WalkSpeed);
                direC = -1;
                if (!Anim.GetCurrentAnimatorStateInfo(0).IsName(JumpName))
                {
                    Anim.Play(WalkName);
                }
            }
        }
        if (hitR.collider == null)
        {
            if ((Input.GetKey("[6]") || Input.GetKey("right")) /*&& !Anim.GetCurrentAnimatorStateInfo(0).IsName(MagicName)*/)//WalkRight
            {
                transform.Translate(new Vector2(1, 0) / WalkSpeed);
                direC = 1;
                if (!Anim.GetCurrentAnimatorStateInfo(0).IsName(JumpName))
                {
                    Anim.Play(WalkName);
                }
            }
        }
        if(!Input.GetKey("[4]") && !Input.GetKey("[6]") && !Input.GetKey("left") && !Input.GetKey("right") && !Jumping && !Anim.GetCurrentAnimatorStateInfo(0).IsName(MagicName))
        {
            Anim.Play(IdleName);
        }

        if (hitD.collider == null)
        {
            Anim.Play(JumpName);
            Jumping = true;
        }
        else
        {
            if (!Anim.GetCurrentAnimatorStateInfo(0).IsName(MagicName) && !Anim.GetCurrentAnimatorStateInfo(0).IsName(WalkName))
            {
                Anim.Play(IdleName);
                Jumping = false;
            }
        }
    }

    public void Jump()
    {
        if (!Jumping /*&& !Anim.GetCurrentAnimatorStateInfo(0).IsName(MagicName)*/)
        {
            JumpSound.Play();
            rb2D.AddForce(Vector2.up * ForceAmmount);
            Jumping = true;
        }
    }

    public void Magic(bool go)
    {
        if (go)
        {
            Anim.Play(MagicName);
        }
        else
        {
            Anim.Play(IdleName);
        }
    }


}
