using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menuCanvas; // Assign the Canvas in the Inspector

    void Start()
    {
        // Open menu on game load
        menuCanvas.SetActive(true);
    }

    void Update()
    {
        
    }

    public void ToggleMenu()
    {
        // Toggle the menu visibility
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }

    public void QuitGame()
    {
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
