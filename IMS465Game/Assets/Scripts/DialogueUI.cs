using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{

    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private float typeSpeed = 50;
    [SerializeField] GameObject self;

    private string[] allDialogue = {"That was a strange dream... oh well, I'm hungry. I'm gonna go down to the kitchen for a cookie.",
            "Aw come on, Mom and Dad locked the cupboard again! I bet they hid the key in their room.",
            "Uh... where are Mom and Dad?",
            "Ahhhh-----what was that?!",
            "Ok... I'm fine. The cookies will make this all better, yup. I'm no chicken. I'm going back in.",
            "Yes! I got it! I'm not scared of silly lights! Or darkness!",
            "Yes! The cookies! They're mineeee!",
            "Wait-----what was that crash?",
            "Was that Mom and Dad in the garage? Hey----why do they keep locking all these doors! And why did they put the key so high up on that shelf? I'll need a ladder... wait----right! There's one in the attic!",
            "And there----now I've got a ladder! Time to get the key and see what's in the garage."};



    // Start is called before the first frame update
    void Start()
    {
        SetDialogueText(allDialogue[0], textLabel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDialogueText(string textToType, TMP_Text textLabel)
    {
        StartCoroutine(routine: TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }

    private void closeDialogue() {
        self.SetActive(false);
    }
}