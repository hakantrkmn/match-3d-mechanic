using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public List<UISlotController> allSlots;

    private void OnValidate()
    {
        allSlots.Clear();

        foreach (UISlotController slotController in GetComponentsInChildren<UISlotController>())
        {
            allSlots.Add(slotController);
        }
    }

    private void OnEnable()
    {
        EventManager.ObjectClicked += ObjectClicked;
    }

    private void OnDisable()
    {
        EventManager.ObjectClicked -= ObjectClicked;
    }

    private void ObjectClicked(Objects obj)
    {
        var avaibleSlot = FindAvaibleSlot();
        avaibleSlot.FillSlotWithObj(obj);
        CheckForMatch();
    }

    public UISlotController FindAvaibleSlot()
    {
        foreach (var slot in allSlots)
        {
            if (slot.status.isFilled==false)
            {
                return slot;
            }
        }

        return null;
    }

    public void CheckForMatch()
    {
        for (int i = 0; i < allSlots.Count-2; i++)
        {
            if (allSlots[i].status.isFilled)
            {
                if (allSlots[i+1].status.isFilled)
                {
                    if (allSlots[i+2].status.isFilled)
                    {
                        if (allSlots[i].status.slotObj==allSlots[i+1].status.slotObj&&allSlots[i+2].status.slotObj==allSlots[i+1].status.slotObj)
                        {
                            allSlots[i].ClearSlot();
                            allSlots[i+1].ClearSlot();
                            allSlots[i+2].ClearSlot();

                        }
                    }
                }
            }
        }
    }
}
