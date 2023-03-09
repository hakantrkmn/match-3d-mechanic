using TMPro;
using UnityEngine;
public class UISlotController : MonoBehaviour
{
    public TextMeshProUGUI slotText;
    public SlotStatus status;
    
   

    private void Start()
    {
        slotText.text = "";
    }

    public void FillSlotWithObj(Objects obj)
    {
        slotText.text = obj.type.ToString();
        status.isFilled = true;
        status.slotObj = obj.type;
    }


    public void ClearSlot()
    {
        status.isFilled = false;
        slotText.text = "";
        
    }

}
