using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private TraversalManager TM;

    private GameObject finalPos;

    [Header("Stairs")]
    [Tooltip("HAve the stairs move up or down"), SerializeField]
    private bool moveUp;

    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("Game Manager").GetComponent<TraversalManager>();

        finalPos = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!moveUp)
            {
                if (collision.transform.position.x + .1f > transform.position.x && collision.transform.position.y + .5f > transform.position.y)
                    TM.stairsMove(collision.gameObject, finalPos);
            }
            else
            {
                if (collision.transform.position.x - .2f < transform.position.x && collision.transform.position.y + .3f > transform.position.y)
                    TM.stairsMove(collision.gameObject, finalPos);
            }

        }
    }
}
