using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CombatHandler : MonoBehaviour
{
    public static CombatHandler Instance { set; get; }

    private void Awake()    //Awake() is run even before Start()
    {
        if (Instance == null)   //< With this if-structure it is IMPOSSIBLE to create more than one instance
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);   //< If you somehow still get to create a new singleton gameobject regardless, destroy the new one
        }
    }

    public int turn;
    public int round;
    public List<Character> InitiativeTracker;
    public Character activeCharacter;

    public void Start()
    {
        //> General tests
        Console.Echo($"Hello, I am {this.name} and this is an echo test!", this.gameObject);
        Debug.Log($"ActionID for \"Swurb\" is {Database.Instance.getActionID("Swurb")}", Database.Instance);

        //> Those two will be set to 1 be the method calls afterwards
        round = 0;
        turn = 0;

        fillInitiativeTracker();    //< Must be called once before nextTurn to fill the InitiativeTracker
        nextTurn();
    }

    public void fillInitiativeTracker()
    {
        InitiativeTracker.Clear();
        //foreach (Character character in GameObject.FindObjectsOfType<Character>())
        foreach (Character character in GameObject.FindObjectsOfType<Character>())
        {
            InitiativeTracker.Add(character);   //Debug.Log($"Found: {character}", character.gameObject);
        }
        InitiativeTracker.Sort((b, a) => a.initiative.CompareTo(b.initiative));  // Performs an unstable sort (If two elements are equal, their order might not be preserved).
                                                                                 // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-6.0
        Debug.Log(Console.CharacterListToString(InitiativeTracker));
    }

    public void nextTurn()
    {
        if (turn % InitiativeTracker.Count == 0)
        {
            round += 1;
            turn = 0;
            fillInitiativeTracker();
        }

        activeCharacter = InitiativeTracker[turn % InitiativeTracker.Count];    //< Overwrites activeCharacter with the corresponding character from the initiative list

        turn += 1;  //< Executed after the others, as otherwise their calculations would require a turn-1 everywhere
                    //  if this was the first line to be executed (because of the InitiativeTracker list indexes)
        Console.Echo($"Now in turn {turn} in round {round}, which is {activeCharacter.name}'s turn.", activeCharacter.gameObject);
    }

}