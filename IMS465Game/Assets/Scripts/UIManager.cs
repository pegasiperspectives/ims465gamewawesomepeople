using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject playPanel;
    public GameObject pause;
    public GameObject creepyScreen;

    public bool startedGame;

    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
        startedGame = true;
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
        StartCoroutine(FlashCat());
    }

    public void PauseGame() {
        pause.SetActive(false);
        playPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public IEnumerator FlashCat() {
         if (playPanel.activeSelf == false && startedGame == true) {
            creepyScreen.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            creepyScreen.SetActive(false);
            startedGame = false;
        }
    }
}
