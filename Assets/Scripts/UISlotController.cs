using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlotController : MonoBehaviour
{
    public TextMeshProUGUI slotText;
    public SlotStatus status;
    public Image slotImage;
   

    private void Start()
    {
        slotText.text = "";
    }

    public void FillSlotWithObj(ObjectTypes obj)
    {
        foreach (var data in Scriptable.ObjectsData().objectDatasList)
        {
            if (data.type==obj)
            {
                slotText.text = data.type.ToString();
                status.isFilled = true;
                status.slotObj = data.type;
                slotImage.sprite = data.sprite;
            }
        }
        
    }


    public void ClearSlot()
    {
        status.isFilled = false;
        slotText.text = "";
        slotImage.sprite = null;

    }

}
