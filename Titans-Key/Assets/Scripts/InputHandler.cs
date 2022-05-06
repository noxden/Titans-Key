//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  05-05-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Camera cam;
    private void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //     if (Physics.Raycast(ray, out RaycastHit hit))
        //     {
        //         if (hit.collider.gameObject.GetComponent<Character>() != null)
        //         {
        //             CombatHandler.Instance.activeCharacter.currentTarget = hit.collider.gameObject.GetComponent<Character>();
        //             Console.Echo($"{CombatHandler.Instance.activeCharacter.name} is now targeting {CombatHandler.Instance.activeCharacter.currentTarget.name}.");
        //         }
        //     }
        //     //CombatHandler.Instance.nextTurn();
        // }
    }

    public void SpawnNewCharacter()
    {
        int iniValue = Random.Range(0, 50);
        GameObject go = new GameObject();
        Character component = go.AddComponent<Character>();
        component.Constr(name: $"Char {iniValue}", initiative: iniValue);
        //Character newChar = new Character(default, default, default, iniValue);
    }
}
