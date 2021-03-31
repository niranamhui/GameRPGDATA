using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInventoryItem
{
    public string _name = "item"; //ชื่อของ Item ที่นำ Scripts ไปใส่

    public Sprite _image = null; //ใส่รูปของ Item 
    public Vector3 PickPosition; //ใส่ตำแหน่งของ Item เมื่อStac 
    public Vector3 PickRotation; //ใส่ตำแหน่งการหมุนของ Item เมื่อStac

 
    public string Name
    {
        get { return _name; }
    }

    public Sprite Image
    {
        get { return _image; }
    }

    public InventorySlot Slot
    {
        get;
        set;
    }
    public void OnPickup()
    {
            gameObject.SetActive(false);
    }

    public virtual void OnUse() //มาไว้ที่มือ
    {
        //gameObject.SetActive(true);
        transform.localPosition = PickPosition; //เอาItemมาไว้ที่มือ
        transform.localEulerAngles = PickRotation; // ตำแหน่งการหมุนของ Item
        this.GetComponent<Bullet>().enabled = true;

    }
}
