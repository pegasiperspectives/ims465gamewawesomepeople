using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{
    private Player P;

    private Transform teleportLocations;
    private int location;

    [Tooltip("The checkers"), SerializeField]
    private GameObject[] checkers;

    [Tooltip("IF the cat should be active from the start"), SerializeField]
    private bool startImediately;

    private bool attackPlayer = false;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        // connecting scripts
        P = GameObject.Find("Player").GetComponent<Player>();

        teleportLocations = GameObject.Find("Cat Locations").transform;

        if (startImediately)
            StartCoroutine(Teleport());
    }

    // Update is called once per frame
    void Update()
    {
        if (attackPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, P.transform.position, .03f);
        }
    }

    public IEnumerator Teleport()
    {
        if (!attackPlayer)
            if (teleportLocations != null)
            {
                location = Random.Range(0, 8);
                transform.position = teleportLocations.GetChild(location).position;
            }
            else
                Debug.LogWarning("Cat Locations not in place");

        if (checkers[location].TryGetComponent<RoomChecker>(out RoomChecker RC))
        {
            attackPlayer = RC.GetPlayerCheck();
        }

        yield return new WaitForSeconds(4f);
        
        StartCoroutine(Teleport());
    }

    private IEnumerator AttackPlayer()
    {
        attacking = true;
        P.DamagePlayer(1);
        yield return new WaitForSeconds(2f);
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!attacking)
                StartCoroutine(AttackPlayer());
        }
    }
}
