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

        setupITracker();
        nextTurn();
    }

    public void setupITracker()
    {
        //> Turn setup, the rest will be done by NextTurn()
        turn = 0;

        foreach (Character character in GameObject.FindObjectsOfType<Character>())
        {
            InitiativeTracker.Add(character);   //Debug.Log($"Found: {character}", character.gameObject);
        }

        // TODO: Make this sorting code cleaner and prettier
        //*> Option A
        InitiativeTracker.Sort((b, a) => a.initiative.CompareTo(b.initiative));  // Performs an unstable sort (If two elements are equal, their order might not be preserved).
                                                                                 // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-6.0
        Debug.Log(Console.CharacterListToString(InitiativeTracker));
        //Debug.Log(string.Join(", ", InitiativeTracker));  //< An alternative way to print the contents of a list to the console 
    }

    public void nextTurn()
    {
        activeCharacter = InitiativeTracker[turn % InitiativeTracker.Count];    //< Overwrites activeCharacter with the corresponding character from the initiative list
        round = 1 + (int)Mathf.Floor(turn / InitiativeTracker.Count);           //< After everyone on the tracker had their turn, a new round starts    //< later DEPRECATED, as it could not account for newly added characters mid-combat
        turn += 1;                                                              //< Needs to be executed after the others, as their calculations would require a turn-1 everywhere
                                                                                //  if this was the first line to be executed (because of the InitiativeTracker list indexes)
        Console.Echo($"Now in turn {turn}, which is {activeCharacter.name}'s turn in round {round}.", this.gameObject);
    }
}