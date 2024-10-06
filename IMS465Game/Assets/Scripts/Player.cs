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

        // sets full health at start
        SetCurrentHealth(maxHealth);

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
    /// Gets the max health of the player
    /// </summary>
    /// <returns> maxHealth </returns>
    public int GetMaxHealth()
    {
        return maxHealth;
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
        float verticalInput = VerticalInput(); // -1 -> 1 vetical input movement

        // allows for running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // allows for the horizontal and vertical movement
            transform.Translate(Vector2.right * speed * 2 * horizontalInput * Time.deltaTime);
            transform.Translate(Vector2.up * (speed / 2) * 2 * verticalInput * Time.deltaTime); // running
        }
        else
        {
            // allows for the horizontal and vertical movement
            transform.Translate(Vector2.right * speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector2.up * (speed / 2) * verticalInput * Time.deltaTime); // walking
        }
    }

    /// <summary>
    /// The verticalInput of moving up and down. Used to limit vertical movement
    /// </summary>
    /// <returns> -1 if moving down, 1 if moving up, 0 if not moving </returns>
    private int VerticalInput()
    {
        if (transform.position.y <= UpLimit && transform.position.y >= DownLimit) // if in the middle and all good
        {
            if (Input.GetKey(KeyCode.W)) // up
            {
                return 1;
            }

            if (Input.GetKey(KeyCode.S)) // down
            {
                if (Input.GetKey(KeyCode.W)) // both are pressed
                {
                    return 0;
                }

                return -1;
            }
        }
        else if (transform.position.y > UpLimit && transform.position.y >= DownLimit) // if too high
        {
            if (Input.GetKey(KeyCode.S))
            {
                return -1;
            }
        }
        else if (transform.position.y <= UpLimit && transform.position.y < DownLimit) // if too low
        {
            if (Input.GetKey(KeyCode.W))
            {
                return 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.S)) // if not moving
        {
            return 0;
        }

        return 0;
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
