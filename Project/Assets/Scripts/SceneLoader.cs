using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField]
    string FollowupScene;

	void Start () {
        SceneManager.LoadScene(FollowupScene);
	}
}
