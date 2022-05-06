//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  05-05-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Convert Actions and Effects into Abstracts
public abstract class Action : MonoBehaviour
{
    public string UID;
    public string displayName;
    public string description;
    public bool available = true;
    public int costActionPoints;
    public int costHealthPoints;
    public int costInitiativePoints;
    public int baseDamage;

    public virtual void use(Character user, Character target)
    {
        Debug.Log($"{user.name} used Ability \"{this.displayName}\", targeting {target.name}.");
    }
}