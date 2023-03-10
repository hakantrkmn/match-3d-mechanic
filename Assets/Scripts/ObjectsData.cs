using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ObjectsData", menuName = "ScriptableObjects/ObjectsData", order = 5)]
public class ObjectsData : ScriptableObject
{
    public List<ObjectDatas> objectDatasList;
}
