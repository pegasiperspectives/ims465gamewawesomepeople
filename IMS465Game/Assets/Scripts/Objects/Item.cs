using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject ItemInstructions;

    // Start is called before the first frame update ooga booga
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Allows you to pick up the Item
    /// </summary>
    public void pickUp()
    {
        if (gameObject.activeSelf == true)
            gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows the instructions for the Item
    /// </summary>
    public void showInstructions()
    {
        if (ItemInstructions != null && ItemInstructions.gameObject.activeSelf == false)
            ItemInstructions.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the instructions for the Item
    /// </summary>
    public void hideInstructions()
    {
        if (ItemInstructions != null && ItemInstructions.gameObject.activeSelf == true)
            ItemInstructions.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("We colidied with: " + collision.gameObject.name);

        // If colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            showInstructions();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // when pressing E
            if (Input.GetKey(KeyCode.E))
            {
                hideInstructions();
                pickUp();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            hideInstructions();
        }
    }
}
