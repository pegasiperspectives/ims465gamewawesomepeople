using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChecker : MonoBehaviour
{
    private CameraManager CM;

    private bool playerIsHere = false;

    // Start is called before the first frame update
    void Start()
    {
        CM = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetPlayerCheck()
    {
        return playerIsHere;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsHere = true;
            CM.CameraPosition(transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsHere = false;
        }
    }
}
