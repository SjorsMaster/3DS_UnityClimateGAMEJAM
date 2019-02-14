using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour {
    [ExecuteInEditMode]

    [SerializeField]
    float OffsetZ = -2;
    Transform Player;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

	void Update () {
        transform.position = new Vector3(Player.position.x, transform.position.y, OffsetZ);
	}
}
