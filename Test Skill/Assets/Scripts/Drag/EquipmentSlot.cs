using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour
{
    // Script ini digunakan sebagai mengatur posisi dari target skill slot biar bisa tepat ditengah
    // Script ini akan otomatis memanggil script DropArea
    // Script yang aku komenkan itu script yang tidak digunakan atau hasil copas yang tidak kuhapus wkwkw

	protected DropArea DropArea;
    //protected DraggableComponent CurrentItem = null;

    //private DisableDropCondition disableDropCondition;
    public Selection selectskill;

    

	protected virtual void Awake()
	{
		DropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
		DropArea.OnDropHandler += OnItemDropped;
        //disableDropCondition = new DisableDropCondition();

        //selectskill = GetComponent<Selection>().selectSkill();
    }

	private void OnItemDropped(DraggableComponent draggable)
	{
        draggable.upgradeButton.SetActive(false);
        
		draggable.transform.position = transform.position;

        //selectskill.selectSkill++;
		//CurrentItem = draggable;
		//DropArea.DropConditions.Add(disableDropCondition);
		//draggable.OnBeginDragHandler += CurrentItemOnBeginDrag;
	}

    //public void Initialize(DraggableComponent currentItem)
    //{
        //if (currentItem == null)
        //{
           //Debug.LogError("Tried to initialize the slot with an null item!");
            //return;
        //}

        //OnItemDropped(currentItem);
    //}

    //Current item is being dragged so we listen for the EndDrag event
    //private void CurrentItemOnBeginDrag(PointerEventData eventData)
    //{
    //CurrentItem.OnEndDragHandler += CurrentItemEndDragHandler;
    //}

    //private void CurrentItemEndDragHandler(PointerEventData eventData, bool dropped)
    //{
    //CurrentItem.OnEndDragHandler -= CurrentItemEndDragHandler;

    //if (!dropped)
    //{
    //return;
    //}

    //DropArea.DropConditions.Remove(disableDropCondition); //We dropped the component in another slot so we can remove the DisableDropCondition
    //CurrentItem.OnBeginDragHandler -= CurrentItemOnBeginDrag; //We make sure to remove this listener as the item is no longer in this slot
    //CurrentItem = null; //We no longer have an item in this slot, so we remove the refference
    //}
}
