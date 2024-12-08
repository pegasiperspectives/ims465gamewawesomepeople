using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private TraversalManager TM;

    private GameObject finalPos;

    [Header("Stairs")]
    [Tooltip("Have the stairs move up or down"), SerializeField]
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
                if (collision.transform.position.x + .1f > transform.position.x && collision.transform.position.y + 4f > transform.position.y)
                    TM.stairsMove(collision.gameObject, finalPos);
            }
            else
            {
                Debug.Log("Player y pos: " + (collision.transform.position.y + 2f));
                Debug.Log("Stairs y pos: " + transform.position.y);

                if (collision.transform.position.x - .2f < transform.position.x && collision.transform.position.y + 2.2f > transform.position.y)
                    TM.stairsMove(collision.gameObject, finalPos);
            }

        }
    }
}
