using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    // Start is called before the first frame update
    public int wardrobeID;
    public List<GameObject> prefabs = new List<GameObject>();
    void Start()
    {
        //EventManager.WardrobeEvent += test;

        MainMenuManager mainMenu = transform.parent.GetComponent<MainMenuManager>();
        List<Vector2> newlist = new List<Vector2>();
        for (int i = 0; i < prefabs.Count; i++)
        {
            Vector3 pos = new Vector3(transform.position.x + i * 3 + 3, transform.position.y, 0);
            GameObject newGM = Instantiate(prefabs[i], transform.position, Quaternion.identity);
            ItemStateManager stateManager = newGM.GetComponent<ItemStateManager>();
            newlist.Add(new Vector2(wardrobeID, i));
            stateManager.items = newlist;
            stateManager.itemCount = prefabs.Count;
            stateManager.itemNumber = i;
            stateManager.wardrobeNumber = wardrobeID;
            newGM.transform.SetParent(transform);
            
            mainMenu.allItems.Add(stateManager);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnMouseOver()
    //{

    //    EventManager.StartWardrobeEvent(wardrobeID);
    //}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "line")
        {
            EventManager.StartWardrobeOverEvent(wardrobeID);
            MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
            renderer.material.color = Color.green;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "line")
        {
            MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
            renderer.material.color = Color.white;
        }
    }
    private void OnDisable()
    {
       // EventManager.WardrobeEvent -= test;
    }
}
