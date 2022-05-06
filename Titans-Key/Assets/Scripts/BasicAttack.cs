//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  05-05-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Action
{
    /* PARENT REFERENCE
    public string UID;
    public string displayName;
    public string description;
    public bool available;
    public int costActionPoints;
    public int costHealthPoints;
    public int costInitiativePoints;
    public int damage;

    public void use(Character user, Character target)
    {
        Debug.Log($"{user} used Ability \"{this.displayName}\", targeting {target}");
    }
    */

   // TODO: If e.g. baseDamage is updated after start, the description will not update accordingly.
    private void Start()
    {
        UID = "basicattack";
        displayName = "Attack";
        costActionPoints = 0;
        costHealthPoints = 0;
        costInitiativePoints = 1;
        baseDamage = 10;
        description = $"You attack the target, dealing {baseDamage} damage to them.";
    }

    public override void use(Character user, Character target)
    {
        Debug.Log($"{displayName} ({UID}) \n{description}\n");
        base.use(user, target);
        Console.Echo($"{user.name} has attacked {target.name}, dealing {baseDamage} damage!");
        target.modifyHealthPoints(-baseDamage);
    }   
}
