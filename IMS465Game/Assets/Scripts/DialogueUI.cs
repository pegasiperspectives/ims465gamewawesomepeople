using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{

    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private float typeSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        Run("yay write this please awesome", textLabel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run(string textToType, TMP_Text textLabel) {
        StartCoroutine(routine:TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel) {
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)  {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
