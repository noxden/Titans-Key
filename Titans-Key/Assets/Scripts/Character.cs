//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  05-05-22
//----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

public enum Affiliation { Ally, Enemy }

public class Character : MonoBehaviour
{
    public void Constr(string name = "Default Name", int healthPointsMax = 0, int actionPointsMax = 0, int initiative = 0, List<Action> AvailableActions = null, List<Effect> ActiveEffects = null)
    {
        this.name = name;
        this.healthPointsMax = healthPointsMax;
        this.actionPointsMax = actionPointsMax;
        this.initiative = initiative;
        this.AvailableActions = AvailableActions;
        this.ActiveEffects = ActiveEffects;
    }


    public Sprite appearance;
    public new string name;
    public int healthPointsMax;
    public int healthPointsCurrent;
    public int actionPointsMax;
    public int actionPointsCurrent;
    public int initiative;
    public Affiliation affiliation;
    public List<Action> AvailableActions;
    public List<Effect> ActiveEffects;
    public Character currentTarget;
    private void Awake()
    {
        gameObject.tag = "Character";
        this.name = gameObject.name;
    }

    private void Start()
    {
        //this.gameObject.name = this.name;      //< Change gameobject's name to this character's name on startup
        healthPointsCurrent = healthPointsMax;
        actionPointsCurrent = actionPointsMax;
    }

    public void useAction(int actionID, Character selectedTarget)
    {
        Character self = this;  //< Not necessary, but I like it. This way, the character can refer to itself with "self".
        Database.Instance.ActionID[actionID].use(self, selectedTarget);
    }

    public bool DEBUGuseAction()
    {
        Character self = this;  //< Not necessary, but I like it. This way, the character can refer to itself with "self".
        if (currentTarget == null || currentTarget.healthPointsCurrent <= 0)
        {
            Console.Echo($"{name} has not targeted anyone yet. Please select a valid target.");
            return false;
        }
        Database.Instance.ActionID[0].use(self, currentTarget);
        currentTarget = null;
        return true;
    }

    //* Setter and Getter functions

    public int getEffectIndex(int effectID)
    {
        return ActiveEffects.IndexOf(Database.Instance.EffectID[effectID]);
    }

    public int modifyHealthPoints(int value)
    {
        healthPointsCurrent = Mathf.Max(healthPointsCurrent + value, 0);
        Console.Echo($"{name} is now at {healthPointsCurrent} health points.");
        return healthPointsCurrent;
    }

    public void setCurrentTarget(Character newTarget)
    {
        if (newTarget.healthPointsCurrent <= 0)
        {
            //Console.Echo($"{newTarget.name} is not a valid target, please choose another one.");
            Console.Echo($"{newTarget.name} is nothing more than a rotting corpse at this point, don't be ridiculous.");
        }

        Console.Echo($"{name} will now target {newTarget.name} with their next action.");
        currentTarget = newTarget;
    }
}