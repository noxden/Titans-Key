using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DatabaseType { Action, Effect, All }

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
    }
    #endregion

    public List<Action> ActionID;
    public List<Effect> EffectID;

    //> searches through the given list and returns the corresponding ID, if no list is specified, it searches all and returns the first match.
    public int getID(string name, DatabaseType type = DatabaseType.All)
    {
        switch (type)
        {
            case DatabaseType.Action:
                if (ActionID.Count < 1)
                    Debug.LogError("There are no entries in ActionID.");
                for (int i = 0; i < ActionID.Count; i++)
                {
                    if (ActionID[i].displayName == name)
                        return i;
                }
                break;

            case DatabaseType.Effect:
                for (int i = 0; i < EffectID.Count; i++)
                {
                    if (EffectID[i].displayName == name)
                        return i;
                }
                break;

            case DatabaseType.All:
                Debug.LogWarning($"Searching all databases is not recommended. Please specify search scope next time.", this.gameObject);
                for (int i = 0; i < ActionID.Count; i++)
                {
                    if (ActionID[i].displayName == name)
                        return i;
                }
                for (int i = 0; i < EffectID.Count; i++)
                {
                    if (EffectID[i].displayName == name)
                        return i;
                }
                break;
        }

        Debug.LogWarning($"Name \"{name}\" matches no entries of ActionID and EffectID, returning -1.", this.gameObject);
        return -1;
    }
}