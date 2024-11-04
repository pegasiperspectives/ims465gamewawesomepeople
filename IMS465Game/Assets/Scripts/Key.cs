using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private Vector3 initialScale;
    public bool hasKey = false;


    // Start is called before the first frame update
    void Start()
    {
         initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.SetParent(collision.transform);
            transform.localPosition = new Vector3(-0.4f, -0.25f, 0f);
            transform.localScale = initialScale;
            transform.localRotation = Quaternion.identity;
            hasKey = true;
        }
    }
}
