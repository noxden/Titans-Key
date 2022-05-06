//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  06-05-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Token : MonoBehaviour
{
    public Character linkedCharacter;
    private Image image;
    private Text text;

    void Start()
    {
        //> Does not require a failsafe "if", because the "Image" component is defined as required at the top of this script
        image = GetComponent<Image>();
        image.sprite = linkedCharacter.appearance;

        if (GetComponentInChildren<Text>() == null)  //< Guard clause
        {
            Console.Echo($"Tokenhandler could not find \"Text\" component. Failed to display character name on Token {this.gameObject}", this.gameObject);
            return;
        }
        text = GetComponentInChildren<Text>();
        text.text = linkedCharacter.name;
    }

    public void onButtonPressed()
    {
        CombatHandler.Instance.activeCharacter.setCurrentTarget(this.linkedCharacter);
    }

}
