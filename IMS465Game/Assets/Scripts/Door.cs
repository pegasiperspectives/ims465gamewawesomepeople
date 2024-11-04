using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject closedoor;
    private GameObject opendoor;

    public Key keyScript;
    // Start is called before the first frame update
    void Start()
    {
        closedoor = transform.GetChild(0).gameObject;
        opendoor = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && keyScript.hasKey == true) {
            closedoor.SetActive(false);
            opendoor.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            closedoor.SetActive(true);
            opendoor.SetActive(false);
        }
    }
}
