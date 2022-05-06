using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public GameObject tokenPrefab;
    private List<Character> initiativeList;

    // TODO: Should be called by CombatHandler through an event instead of being closely linked.
    // TODO: Currently creates each token twice as CombatHandler.fillInitiativeTracker() is called twice...
    public void addToken(Character character)
    {
        GameObject newToken = Instantiate(tokenPrefab);
        newToken.transform.SetParent(this.gameObject.transform);
        newToken.GetComponent<Token>().linkedCharacter = character;
    }
}
