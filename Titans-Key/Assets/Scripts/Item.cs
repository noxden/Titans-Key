//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  19-04-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Weapon, Armor, Consumable}


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Default")]
public class Item : ScriptableObject
{
    public new string name;
    public string description;
    public ItemType type;
    public int power;
}
