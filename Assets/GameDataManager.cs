using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    public Objects currentMovingObj;

    private void OnEnable()
    {
        EventManager.ObjectClicked += SetCurrentMovingObject;
    }

    private void OnDisable()
    {
        EventManager.ObjectClicked -= SetCurrentMovingObject;
    }

    private void SetCurrentMovingObject(Objects obj)
    {
        currentMovingObj = obj;
    }
}
