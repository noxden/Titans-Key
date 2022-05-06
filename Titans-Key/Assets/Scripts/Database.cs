//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  19-04-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Database : MonoBehaviour
{
    #region Singleton-Setup
    public static Database Instance { set; get; }

    private void Awake()    //Awake() is run even before Start()
    {
        if (Instance == null)   //< With this if-structure it is IMPOSSIBLE to create more than one instance
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); //< Referring to the gameObject, this singleton script (class) is attached to
        }
        else
        {
            Destroy(this.gameObject);   //< If you somehow still get to create a new singleton gameobject regardless, destroy the new one
        }

        //> Making sure that the lists don't have empty slots
        ActionID.RemoveAll(e => e == null);
        EffectID.RemoveAll(e => e == null);
    }
    #endregion

    public List<Action> ActionID;
    public List<Effect> EffectID;

    //> searches through the given list and returns the corresponding ID, if no list is specified, it searches all and returns the first match.
    public int getActionID(string name)
    {
        for (int i = 0; i < ActionID.Count; i++)
        {
            if (ActionID[i].displayName == name)
                return i;
        }
        Debug.LogWarning($"ActionID does not contain \"{name}\", returning -1.", this.gameObject);
        
        if (ActionID.Count < 1)
            Debug.LogError("There are no entries in ActionID.");
        return -1;
    }

    public int getEffectID(string name)
    {
        for (int i = 0; i < EffectID.Count; i++)
        {
            if (EffectID[i].displayName == name)
                return i;
        }
        Debug.LogWarning($"EffectID does not contain \"{name}\", returning -1.", this.gameObject);
        
        if (EffectID.Count < 1)
            Debug.LogError("There are no entries in EffectID.");
        return -1;
    }

}