using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdleState : ItemBaseState
{
    int wardrobeID;
    int wardrobeID2 = -2;
    int wardrobeID3 = -3;
    int itemID;
    public override void EnterState(ItemStateManager item)
    {
        item.transform.position = item.transform.parent.position;
        itemID = -1; wardrobeID = -1;
        EventManager.WardrobeEvent += WardrobeAllIdle;
        EventManager.ItemEvent += ItemTiming;
        EventManager.WardrobeOverEvent += WardrobeOver;

    }
    public override void UpdateState(ItemStateManager item)
    {
        if ((wardrobeID == item.wardrobeNumber || (wardrobeID3 == wardrobeID2 && wardrobeID2 == item.wardrobeNumber)) && itemID + 1 == item.itemNumber)
        {
            item.SwitchState(item.showUpState);
        }
    }
    public override void FixedUpdateState(ItemStateManager item)
    {

    }
    public override  void OnCollisionEnter(ItemStateManager item, Collider other)
    {

    }
    public override void OnCollisionExit(ItemStateManager item, Collider other)
    {

    }
    public void WardrobeOver(int wardrobeID)
    {
        wardrobeID3 = wardrobeID; 
    }
    public void WardrobeAllIdle(int wardrobeID)
    {
        // Debug.Log("Tutaj");
        this.wardrobeID = wardrobeID;
        itemID = -1;
        //Debug.Log(itemID + " " + wardrobeID);
    }
    public void ItemTiming(int wardrobeID, int itemID)
    {
        this.itemID = itemID;
        wardrobeID2 = wardrobeID;
    }
    public override void ExitState(ItemStateManager item)
    {
        EventManager.WardrobeEvent -= WardrobeAllIdle;
        EventManager.ItemEvent -= ItemTiming; 
        EventManager.WardrobeOverEvent -= WardrobeOver;
    }
}
