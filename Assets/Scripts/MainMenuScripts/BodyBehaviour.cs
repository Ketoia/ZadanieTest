using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer rend;
    Color baseColor;

    void Start()
    {
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        EventManager.HighlightPartsEvent += HighlighPart;
        rend = transform.GetComponent<MeshRenderer>();
        baseColor = rend.material.color;
    }

    public void HighlighPart(string tagName, bool isBaseColor)
    {
        //Debug.Log("tak dzia³a " + isBaseColor);
        if (transform.gameObject.CompareTag(tagName))
        {
            if (!isBaseColor)
            {
                rend.material.color = Color.yellow;
            }
            else
            {
                rend.material.color = Color.white;
            }
        }
    }
    private void OnDisable()
    {
        EventManager.HighlightPartsEvent -= HighlighPart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
