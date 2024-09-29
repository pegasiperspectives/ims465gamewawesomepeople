using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 respawnPos;

    [Header("Movement")]
    [Tooltip("Change how fast the Player moves"), Min(0), SerializeField] 
    private float speed = 1f;

    [Tooltip("How far up the player can move"), SerializeField] 
    private float UpLimit = -1;
    [Tooltip("How far down the player can move"), SerializeField]
    private float DownLimit = -2;

    [Header("Health")]
    [Tooltip("The max amount of health the player has"), Min(0), SerializeField]
    private int maxHealth;
    [Tooltip("The current amount of health the player has"), Min(0), SerializeField]
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // sets respawn postion
        respawnPos = transform.position;

        /*SetCurrentHealth(6);
        DamagePlayer(0);
        DamagePlayer(3);
        DamagePlayer(5);*/
    }

    // Update is called once per frame
    void Update()
    {
        // gets the movement working
        Movement();
    }

    //----------------------------------------------------------------------------------------------------------------------
    // Get and Set

    /// <summary>
    /// Gets the health of the player
    /// </summary>
    /// <returns> currentHealth </returns>
    public int GetHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Sets the maximum health of the player
    /// </summary>
    /// <param name="newAmount"> The new max to the health </param>
    public void SetMaxHealth(int newAmount)
    {
        maxHealth = newAmount;

        // avoids maxHealth being negative
        if (maxHealth <= 0)
            maxHealth = 0;
    }

    /// <summary>
    /// Sets the current health of the player
    /// </summary>
    /// <param name="newAmount"> the new amount of player health </param>
    public void SetCurrentHealth(int newAmount)
    {
        // make sure you don't set the health above the maximum amount
        if (maxHealth >= newAmount)
            currentHealth = newAmount;
        else
            currentHealth = maxHealth;
    }

    //----------------------------------------------------------------------------------------------------------------------
    // Movement

    /// <summary>
    /// Movement of the Player
    /// </summary>
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 -> 1 horizontal input movement
        float verticalInput = 0; // 0 to set standing still

        // vetical input movement
        if (transform.position.y <= UpLimit && transform.position.y >= DownLimit) // if in the middle and all good
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                verticalInput = -1;

                if (Input.GetKey(KeyCode.W))
                {
                    verticalInput = 0;
                }
            }
        }
        else if (transform.position.y > UpLimit && transform.position.y >= DownLimit) // if too high
        {
            if (Input.GetKey(KeyCode.S))
            {
                verticalInput = -1;
            }
        }
        else if (transform.position.y <= UpLimit && transform.position.y < DownLimit) // if too low
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.S)) // if not moving
        {
            verticalInput = 0;
        }

        // allows for the horizontal and vertical movement
        transform.Translate(Vector2.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector2.up * speed/2 * verticalInput * Time.deltaTime);
    }

    //----------------------------------------------------------------------------------------------------------------------
    // Damage

    private void DamagePlayer(int damageAmount)
    {
        // avoid negatives
        if (damageAmount <= 0)
            damageAmount = 0; // no damage taken
        else
        {
            currentHealth = currentHealth - damageAmount; // set damage taken

            // avoid negatives
            if (currentHealth < 0)
                currentHealth = 0;
        }

        // if dead
        if (currentHealth == 0)
        {
            Respawn();
            currentHealth = maxHealth;
        }

        Debug.Log(GetHealth());
    }


    /// <summary>
    /// Respawns the player
    /// </summary>
    private void Respawn()
    {
        transform.position = respawnPos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("We colidied with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Item"))
        {
            Item itemSript = gameObject.GetComponent<Item>();

            if (itemSript != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    itemSript.pickUp();
                }
            }
        }
    }


}
