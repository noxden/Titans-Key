using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        Display.Echo($"Hello, I am {this.name} and this is an echo test!", this.gameObject);
        Debug.Log($"ActionID for \"Swurb\" is {Database.Instance.getActionID("Swurb")}", Database.Instance);

        initializeITracker();
        nextTurn();
    }

    // TODO: Find a way to make this sorting work properly
    public void initializeITracker()
    {
        //> Turn setup, the rest will be done by NextTurn()
        turn = 0;

        foreach (Character character in GameObject.FindObjectsOfType<Character>())
        {
            InitiativeTracker.Add(character);   //Debug.Log($"Found: {character}", character.gameObject);
        }

        // TODO: Make this sorting code cleaner and prettier
        #region Sorting Debug Statement (disabled)
        string temp = null;
        foreach (Character character in InitiativeTracker)  //< Confirmatory debug message (Pre-Sort)
        {
            temp += $"{character.initiative}, ";
        }
        temp = temp.Remove(temp.Length - 2);
        Debug.Log($"ITracker before sort: {temp}", this.gameObject);
        temp = null;
        #endregion

        //*> Option 1 ✔️
        InitiativeTracker.Sort((b, a) => a.initiative.CompareTo(b.initiative));  
        // Performs an unstable sort (If two elements are equal, their order might not be preserved).
        // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-6.0

        //*> Option 2 ✔️
        // List<Character> SortedList = InitiativeTracker.OrderByDescending(c => c.initiative).ToList();
        // InitiativeTracker = SortedList;

        //*> Option 3 ✔️
        // InitiativeTracker = InitiativeTracker.OrderByDescending(c => c.initiative).ToList();   //< Implements linq

        //*> Option 4 ✔️
        InitiativeTracker.Sort(new InitiativeComparison()); //< Implements custom Comparer function = extra bulk that I'd rather not have
        InitiativeTracker.Reverse();

        #region Sorting Debug Statement (disabled)
        foreach (Character character in InitiativeTracker)  //< Confirmatory debug message (Post-Sort)
        {
            temp += $"{character.initiative}, ";
        }
        temp = temp.Remove(temp.Length - 2);
        Debug.Log($"ITracker after sort: {temp}", this.gameObject);
        temp = null;
        #endregion
    }

    // TODO Requires further testing, but should be working
    public void nextTurn()
    {
        //> Overwriting activeCharacter with the corresponding character from the initiative list
        activeCharacter = InitiativeTracker[Mathf.Max(turn % InitiativeTracker.Count, 0)];    //> Mathf.Min makes sure that it does not try to access InitiativeTracker[-1], even though that should not be happen anyways
        round = 1+(int)Mathf.Floor(turn / InitiativeTracker.Count);     //> After everyone on the tracker had their turn, a new round starts
        turn += 1;
        Display.Echo($"Now in turn {turn}, which is {activeCharacter.name}'s turn in round {round}.", this.gameObject);
    }

    public class InitiativeComparison : Comparer<Character>
    {
        override public int Compare(Character c1, Character c2)
        {
            return c1.initiative - c2.initiative;
        }
    }
}