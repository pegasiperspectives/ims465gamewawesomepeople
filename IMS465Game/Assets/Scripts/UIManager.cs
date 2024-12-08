using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject playPanel;
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void PlayGame() {
        playPanel.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseGame() {
        pause.SetActive(false);
        playPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
