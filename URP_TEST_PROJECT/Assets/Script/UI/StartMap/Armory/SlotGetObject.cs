using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;

public class SlotGetObject : MonoBehaviour, IDropHandler
{
    private GetAndDragItem slotItem;
    [SerializeField] private ItemType itemType;
    [SerializeField] private GameObject buildField;
    [SerializeField] private bool isRightWeapon = false;
    
    private GameObject spawnObject;
    private void Update()
    {
        if(slotItem==null)
        {
            if (spawnObject != null)
            {
                Destroy(spawnObject);
            }
        }
    }
    

    public void OnDrop(PointerEventData eventData)
    {
        slotItem = GetAndDragItem.GetObjectComponent();
        if (slotItem.CompareObject(itemType))
        {
            slotItem.ObjectInSlot(true);
            AddItemToSlot();
        }
        else
        {
            slotItem.ObjectInSlot(false); 
        }
    }

    private void AddItemToSlot()
    {
        if (this.transform.childCount > 0)
        {
            Destroy(this.transform.GetChild(0).gameObject);

        }
        else
        {
            slotItem.transform.SetParent(this.transform, true);
            slotItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
            RespawnSlotItem.RespawnItem(ref spawnObject, ref buildField, itemType, slotItem, isRightWeapon);
        }
    }

    
}
