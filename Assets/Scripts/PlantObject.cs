using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class PlantObject : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;
    public ActionType actionType;

    [Header("Only UI")]
    public bool stackble = true;

    [Header("Both")]
    public Sprite image;
    public string planName;
    public Sprite[] plantStages;
    public float timeBtwStages ;
    public float price;



}

public enum ItemType
{
    SeedPlant,
}

public enum ActionType
{
    Plant
}
