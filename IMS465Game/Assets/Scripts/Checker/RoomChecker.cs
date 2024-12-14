using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChecker : MonoBehaviour
{
    private CameraManager CM;

    // Start is called before the first frame update
    void Start()
    {
        CM = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If colliding with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            CM.CameraPosition(transform.position);
        }
    }
}
