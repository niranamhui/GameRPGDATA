using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollControler : MonoBehaviour
{

    Rigidbody rd;


    public Inventory inventory;

    public GameObject Hand;
    public InventorySlot iSlot;
    private IInventoryItem mCurrentItem = null;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
    }
    void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInventoryItem item = inventory.ItemTop();
            print("Used item" + item);
            if (item != null)
            {
                if(mCurrentItem != null)
                {
                  DropCurrentItem();
                }
                inventory.UseItem(item);
                inventory.RemoveItem(item);
                
            }
        }

        else if (Input.GetKeyDown(KeyCode.G))
        {
            if(mCurrentItem != null)
            {
                DropCurrentItem();
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        //if(item != null && inventory.mItems.Count < 5)
        if (item != null)
        {
            inventory.AddItem(item);
            item.OnPickup();
        }
    }

    private void SetItemActive(IInventoryItem item, bool active)
    {
        GameObject currentItem = (item as MonoBehaviour).gameObject;
        currentItem.SetActive(active);
        currentItem.transform.parent = active ? Hand.transform : null;
    }
    private void Inventory_ItemUsed(object sender,InventoryEventArgs e)
    {
        if(mCurrentItem != null)
        {
            SetItemActive(mCurrentItem, false);
        }
        IInventoryItem item = e.Item;
        SetItemActive(item, true);
        mCurrentItem = e.Item;
    }

    public void DropCurrentItem()
    {
        GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;

        Rigidbody rbItem = goItem.AddComponent<Rigidbody>();
        if(rbItem != null)
        {
            rbItem.AddForce(transform.forward * 20.5f, ForceMode.Impulse);
            Invoke("DoDropItem", 5.0f);
        }
    }

    public void DoDropItem()
    {
        Destroy((mCurrentItem as MonoBehaviour).GetComponent<Rigidbody>());
        mCurrentItem = null;
    }
}
