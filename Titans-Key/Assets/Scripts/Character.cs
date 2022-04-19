using System.Collections.Generic;
using UnityEngine;

public enum Affiliation { Ally, Enemy }

public class Character : MonoBehaviour
{
    public void constructor(string _name = "Default Name", int _healthPointsMax = 0, int _actionPointsMax = 0, int _initiative = 0, List<Action> _AvailableActions = null, List<Effect> _ActiveEffects = null)
    {
        name             = _name;
        healthPointsMax  = _healthPointsMax;
        actionPointsMax  = _actionPointsMax;
        initiative       = _initiative;
        AvailableActions = _AvailableActions;
        ActiveEffects    = _ActiveEffects;
    }

    public new string name;
    public int healthPointsMax;
    public int healthPointsCurrent;
    public int actionPointsMax;
    public int actionPointsCurrent;
    public int initiative;
    List<Action> AvailableActions;
    List<Effect> ActiveEffects;

    private void Awake()
    {
        gameObject.tag = "Character";
    }

    private void Start()
    {
        this.gameObject.name = this.name;      //< Change gameobject's name to this character's name on startup
        healthPointsCurrent = healthPointsMax;
        actionPointsCurrent = actionPointsMax;
    }

    public void useAction(int actionID, Character selectedTarget)
    {
        Character self = this;  //< Not necessary, but I like it. This way, the character can refer to itself with "self".
        Database.Instance.ActionID[actionID].use(self, selectedTarget);
    }

    public int getEffectIndex(int effectID)
    {
        return ActiveEffects.IndexOf(Database.Instance.EffectID[effectID]);
    }
}