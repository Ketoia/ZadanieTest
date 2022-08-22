using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public List<ItemStateManager> allItems = new List<ItemStateManager>();
    // Start is called before the first frame update
    void Start()
    {
        EventManager.WardrobeOverEvent += WardrobeAllItemsAreEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WardrobeAllItemsAreEvent(int wardrobeID)
    {
        bool isAllIdle = true;
        for (int i = 0; i < allItems.Count; i++)
        {
            if (!(allItems[i].currentState == allItems[i].idleState || allItems[i].currentState == allItems[i].putOnState))
            {
                isAllIdle = false;
                break;
            }
        }
        if (isAllIdle)
        {
            EventManager.StartWardroveEvent(wardrobeID);
        }
    }

    private void OnDisable()
    {
        EventManager.WardrobeOverEvent -= WardrobeAllItemsAreEvent;
    }
}
