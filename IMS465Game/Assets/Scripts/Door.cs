using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject closedoor;
    private GameObject opendoor;

    BoxCollider2D hitDoor;

    [SerializeField] bool needsKey;

    public Key keyScript;
    // Start is called before the first frame update
    void Start()
    {
        hitDoor = gameObject.transform.GetComponent<BoxCollider2D>();
        closedoor = transform.GetChild(0).gameObject;
        opendoor = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //when you run into a door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyScript.hasKey == true && needsKey == true)
        {
            closedoor.SetActive(false);
            openDoorNoCollider();
        }
        else
        {
            openDoorNoCollider();
        }
    }

    //when you pass through a door
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            closedoor.SetActive(true);
            if (hitDoor != null)
            {
                hitDoor.enabled = true;
                Debug.Log("door returned from the spirit realm");
            }
        }
    }

    private void openDoorNoCollider()
    {
        opendoor.SetActive(true);
        if (hitDoor != null)
        {
            hitDoor.enabled = false;
            Debug.Log("door is in the spirit realm");
        }
    }
}
