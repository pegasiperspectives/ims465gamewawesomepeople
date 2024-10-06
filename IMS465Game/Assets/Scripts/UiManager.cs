using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    Player P;

    [Header("Displays")]
    [SerializeField] private TextMeshProUGUI HealthAmount;

    [Header("Health Amount Style")]
    [SerializeField] bool divide;
    [SerializeField] bool percentage;

    int currentHealth = 0;
    int pastHealthAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // connecting scripts
        P = GameObject.Find("Player").GetComponent<Player>();

        if (P != null)
            currentHealth = P.GetHealth();

    }

    // Update is called once per frame
    void Update()
    {
        // if player exists and cursor isn't visible
        if (P != null && pastHealthAmount != currentHealth)
        {
            HealthBarControl();
            pastHealthAmount = currentHealth; // update past health
        }
    }

    /// <summary>
    /// The controller for everything the health bar does
    /// </summary>
    private void HealthBarControl()
    {
        // gets the player health
        int currentHealth = P.GetHealth();
        int maxHealth = P.GetMaxHealth();

        // gets the precentage of health the player has
        float healthAmount = ((float)currentHealth / maxHealth) * 100;

        //different styles of text
        if (divide)
            HealthAmount.text = "Health: " + currentHealth + "/" + maxHealth; // shows it in a 1/10 format
        else if (percentage)
            HealthAmount.text = "Health: " + (int)healthAmount + "%"; // shows it in a 10% format
        else
            HealthAmount.text = "Health: " + currentHealth.ToString(); // shows just a 1 format
    }
}
