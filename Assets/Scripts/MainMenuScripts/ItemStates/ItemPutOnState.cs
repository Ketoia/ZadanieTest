using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPutOnState : ItemBaseState
{
    bool trigger;
    int wardrobeID;
    //bool allWardrobeIdle;
    public override void EnterState(ItemStateManager item)
    {
        trigger = true;
        wardrobeID = item.wardrobeNumber;
        //EventManager.WardrobeEvent += WardrobeAllIdle;
        EventManager.ItemEvent += LastWardrobeNumber;
        EventManager.StartCountingEvent(1);
    }
    public override void UpdateState(ItemStateManager item)
    {
        if (Input.GetMouseButtonDown(0) && trigger)
        {
            item.transform.localScale = item.startLocalScale;
            item.items.Add(new Vector2(item.wardrobeNumber, item.itemNumber));
            EventManager.StartCountingEvent(-1);
            item.SwitchState(item.movingState);
        }
        if (Input.GetMouseButtonDown(1) && trigger)
        {
            item.transform.localScale = item.startLocalScale;
            item.movingTrigger = false;
            item.items.Add(new Vector2(item.wardrobeNumber, item.itemNumber));
            EventManager.StartCountingEvent(-1);
            if (item.wardrobeNumber != wardrobeID)
            {
                //Debug.Log("??0 " + item.wardrobeNumber + " " + wardrobeID + " " + allWardrobeIdle);
               // allWardrobeIdle = false;
                item.SwitchState(item.idleState);
            }
            else
            {
                item.SwitchState(item.waitingState);
            }
        }
    }

    public void LastWardrobeNumber(int wardrobeID, int itemID)
    {
       // Debug.Log("EVENT ");
        this.wardrobeID = wardrobeID;
    }
    //public void WardrobeAllIdle(int wardrobeID)
    //{
    //    allWardrobeIdle = true;
    //}

    public override void FixedUpdateState(ItemStateManager item)
    {

    }
    public override void OnCollisionEnter(ItemStateManager item, Collider other)
    {
        if (other.gameObject.name == "line")
        {
            trigger = true;
        }
    }
    public override void OnCollisionExit(ItemStateManager item, Collider other)
    {
        if (other.gameObject.name == "line")
        {
            trigger = false;
        }
    }
    public override void ExitState(ItemStateManager item)
    {
        //EventManager.WardrobeEvent -= WardrobeAllIdle;
        EventManager.ItemEvent -= LastWardrobeNumber;
        Debug.Log("Exit");
        //EventManager.StartCountingEvent(-1);
    }
}
