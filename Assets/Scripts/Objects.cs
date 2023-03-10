using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Objects : MonoBehaviour, IClickable
{
    public ObjectTypes type; 
    Color objectColor;
    int point;

    private void Start()
    {
        SetObject();
    }

    public void SetObject()
    {
        var data = Scriptable.ObjectsData();
        foreach (var datas in data.objectDatasList)
        {
            if (datas.type==type)
            {
                objectColor = datas.color;
                point = datas.point;
            }
        }
        

        GetComponent<Renderer>().material.color = objectColor;
    }


    private void OnMouseDown()
    {
        Click();
    }


    public void Click()
    {
        EventManager.ObjectClicked(this);
        ScaleDown();
        GetComponent<Collider>().enabled = false;
    }

    void ScaleDown()
    {
        Sequence clickAction = DOTween.Sequence();
        clickAction.Append(transform.DOScale(0, .5f));
        clickAction.AppendCallback(() => { Destroy(gameObject); });
    }
}