//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Script by:    Daniel Heilmann (771144)
// Last changed:  05-05-22
//----------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public static class Console
{
    public static void Echo(string input, GameObject source)    //< Displays input string through a defined textbox and in the console
    {
        Debug.Log($"<color=#25B1E4> {input} </color>", source);
        Text textBox = GameObject.Find("DefaultText").GetComponent<Text>();
        textBox.text = input;
    }

    public static void Echo(string input)
    {
        Debug.Log($"<color=#25B1E4> {input} </color>");
        Text textBox = GameObject.Find("DefaultText").GetComponent<Text>();
        textBox.text = input;
    }

    public static string CharacterListToString(List<Character> input)   //< Returns the names of the characters in a character list
    {
        string temp = "";
        foreach (Character character in input)
        {
            temp += $"{character.name}, ";
        }
        temp = temp.Remove(temp.Length - 2);
        return temp;
    }
}