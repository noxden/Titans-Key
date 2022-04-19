using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DatabaseType { Action, Effect, All }

public sealed class Database : MonoBehaviour
{
    public List<Action> ActionID;
    public List<Effect> EffectID;

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
    }
    #endregion

    //> searches through the given list and returns the corresponding ID
    public int getID(string name, DatabaseType type /*= DatabaseType.All*/)     //? I could use this default assignment instead of a function overload
    {
        switch (type)
        {
            case DatabaseType.Action:
                for (int i = 0; i < ActionID.Count; i++)
                {
                    if (ActionID[i].displayName == name)
                    {
                        return i;
                    }
                }
                break;

            case DatabaseType.Effect:
                for (int i = 0; i < EffectID.Count; i++)
                {
                    if (EffectID[i].displayName == name)
                    {
                        return i;
                    }
                }
                break;
            case DatabaseType.All:
                // TODO This needs to be implemented, maybe?
                break;

        }

        Debug.LogWarning($"Name \"{name}\" matches no entries of ActionID and EffectID, returning 0.", this.gameObject);
        return 0;
    }

    // searches through both lists and returns the corresponding ID. Returns error if it finds string in both lists
    public int getID(string name)
    {
        List<int> matchingActions = new List<int>();
        //Debug.Log($"matchingActions has a length of {matchingActions.Count}", this.gameObject);
        for (int i = 0; i < ActionID.Count; i++)
        {
            if (ActionID[i].displayName == name)
            {
                matchingActions.Add(i);
            }
        }
        //Debug.Log($"matchingActions has a length of {matchingActions.Count}", this.gameObject);

        List<int> matchingEffects = new List<int>();
        for (int i = 0; i < EffectID.Count; i++)
        {
            if (EffectID[i].displayName == name)
            {
                matchingEffects.Add(i);
            }
        }

        if (matchingActions.Count > 0 && matchingEffects.Count == 0)
        {
            if (matchingActions.Count > 1)
            {
                Debug.LogWarning($"Name \"{name}\" matches multiple entries in ActionID, returning first match.", this.gameObject);
            }
            return matchingActions[0];
        }
        else if (matchingEffects.Count > 0 && matchingActions.Count == 0)
        {
            if (matchingEffects.Count > 1)
            {
                Debug.LogWarning($"Name \"{name}\" matches multiple entries in EffectID, returning first match.", this.gameObject);
            }
            return matchingEffects[0];
        }
        else if (matchingActions.Count > 0 && matchingEffects.Count > 0)
        {
            Debug.LogWarning($"Name \"{name}\" matches entries in both ActionID and EffectID, returning first match in ActionID.", this.gameObject);
            return matchingActions[0];
        }
        else    //> Fallback if no matches were found
        {
            Debug.LogWarning($"Name \"{name}\" matches no entries of ActionID or EffectID, returning 0.", this.gameObject);
            return -1;
        }
    }
}