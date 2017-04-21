using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_effects : MonoBehaviour {

    public Material material;
    public Image image;
    public Texture texture;
    public float offsetSpeed;
    public Vector2 Offsetvalue;

    // Use this for initialization
    private void Awake()
    {
        if(GetComponent<MeshRenderer>() == null)
        {
            image = GetComponent<Image>();
            material = image.material;
        }
        else
        {
            material = GetComponent<MeshRenderer>().material;
        }
    }
    // Update is called once per frame
    private void Update () {
            offsetTexture();
    }

    private void offsetTexture()
    {
        Offsetvalue.y += Time.deltaTime * offsetSpeed;
        if (Offsetvalue.y > 1)
        {
            Offsetvalue.y = 1 - Offsetvalue.y;
        }
        material.mainTextureOffset = Offsetvalue;
    }
      
}
