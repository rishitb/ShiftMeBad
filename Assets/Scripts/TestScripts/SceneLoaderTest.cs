using UnityEngine;
using System.Collections;

public class SceneLoaderTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(loading());
        GameState.currentScore = 10;
        Debug.Log(GameState.currentScore);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator loading()
    {
        yield return new WaitForSeconds(2);
        GameState.resetLevel();
    }
}
