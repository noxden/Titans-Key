using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //CombatHandler.Instance.nextTurn();
        }
    }

    public void SpawnNewCharacter()
    {
        int iniValue = Random.Range(0, 50);
        GameObject go = new GameObject();
        Character component = go.AddComponent<Character>();
        component.constructor(_name: $"Char {iniValue}", _initiative: iniValue);
        //Character newChar = new Character(default, default, default, iniValue);
    }
}
