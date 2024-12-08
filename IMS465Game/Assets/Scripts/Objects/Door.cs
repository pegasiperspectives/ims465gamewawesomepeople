using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private TraversalManager TM;

    private GameObject closeDoor;

    private GameObject nobLeft;
    private GameObject nobRight;

    private GameObject openDoorLeft;
    private GameObject openDoorRight;

    [Header("Door")]
    [Tooltip("Have the door open on the right or left side"), SerializeField]
    private bool openRightSide;
    [Tooltip("Is the door locked"), SerializeField]
    private bool locked;
    private bool open;


    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("Game Manager").GetComponent<TraversalManager>();

        closeDoor = transform.GetChild(0).gameObject;

        nobLeft = closeDoor.transform.GetChild(1).gameObject;
        nobRight = closeDoor.transform.GetChild(2).gameObject;

        openDoorLeft = transform.GetChild(1).gameObject;
        openDoorRight = transform.GetChild(2).gameObject;


        if (openRightSide)
        {
            nobLeft.SetActive(false);
            nobRight.SetActive(true);
        }
        else
        {
            nobLeft.SetActive(true);
            nobRight.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (!locked)
            {
                closeDoor.SetActive(false);

                if (openRightSide)
                    openDoorRight.SetActive(true);
                else
                    openDoorLeft.SetActive(true);

                open = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (!locked)
            {
                closeDoor.SetActive(true);

                if (openRightSide)
                    openDoorRight.SetActive(false);
                else
                    openDoorLeft.SetActive(false);
                
                open = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (open)
            {
                Debug.Log("Player y pos: " + (collision.transform.position.y));
                Debug.Log("Door y pos: " + transform.position.y);

                TM.doorMove(collision.gameObject, openRightSide);
            }
        }
    }
}
