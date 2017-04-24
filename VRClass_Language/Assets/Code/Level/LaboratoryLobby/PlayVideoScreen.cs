using UnityEngine;
using System.Collections;

public class PlayVideoScreen : MonoBehaviour {

    private Renderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        ((MovieTexture)renderer.material.mainTexture).loop = true;
        ((MovieTexture)renderer.material.mainTexture).Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
