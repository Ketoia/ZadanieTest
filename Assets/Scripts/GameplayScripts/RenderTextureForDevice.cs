using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureForDevice : MonoBehaviour
{
    // Start is called before the first frame update
    //public RenderTexture renderTexture;
    public Material material;
    public Material shaderMaterial;
    

    public Camera cam;
    void Start()
    {
        RenderTexture renderTexture = new RenderTexture(495,270,8);

        cam.targetTexture = renderTexture;
        cam.Render();

        material.SetTexture("_MainTex", renderTexture);
        Renderer rend = transform.GetComponent<Renderer>();
        rend.material = material;



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        //Rect test = new Rect(Screen.width / 2, Screen.height / 2, 20, 20);
        //GUI.Label(test, "jej");
    }
}
