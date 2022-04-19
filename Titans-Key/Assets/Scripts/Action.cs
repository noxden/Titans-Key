using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Convert Actions and Effects into ScriptableObjects
public class Action : MonoBehaviour
{
    public string UID;
    public string displayName;
    public string description;
    public bool available;
    public int costActionPoints;
    public int costHealthPoints;
    public int costInitiativePoints;
    public int damage;

    public void use(Character user, Character target)
    {
        Debug.Log($"{user} used Ability \"{this.displayName}\", targeting {target}");
    }
}