using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public string UID;
    public string displayName;
    public string description;
    public bool active;
    public Character affectedCharacter;
    public int remainingDuration;

    public void begin()
    {
        Debug.Log($"Effect \"{this.displayName}\" began on {affectedCharacter}.");
    }

    public void trigger()
    {
        Debug.Log($"Effect \"{this.displayName}\" was triggered on {affectedCharacter}.");
    }

    public void end()
    {
        Debug.Log($"Effect \"{this.displayName}\" ended on {affectedCharacter}.");
    }

    public void updateDuration()
    {
        // Is triggered by a gameEvent
    }
}