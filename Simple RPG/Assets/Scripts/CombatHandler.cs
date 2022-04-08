using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CombatHandler : Monobehaviour
{
    public static CombatHandler Instance { set; get; }

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

    public int currentTurn;
    public int currentRound;
    public Entity activeEntity;

    private void Start()
    {
        activeEntity = new Entity();
    }

    private void Update()
    {
        
    }
}