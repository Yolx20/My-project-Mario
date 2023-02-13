using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
     
    public void playGame(int num)
    {
        Application.LoadLevel(num);
         
    }

    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
