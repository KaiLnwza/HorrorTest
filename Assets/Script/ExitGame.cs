using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game is quitting..."); // for testing in the editor
        Application.Quit(); // this actually closes the game (works in build only)
    }
}