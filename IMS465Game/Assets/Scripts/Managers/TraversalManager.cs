using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class TraversalManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doorMove(GameObject Player, bool left)
    {
        Vector2 pos = Player.transform.position;

        if (!left)
        {
            pos = new Vector2(pos.x + 3.25f, pos.y);
            Player.transform.position = pos;
        }
        else
        {
            pos = new Vector2(pos.x - 3.25f, pos.y);
            Player.transform.position = pos;
        }
    }

    public void stairsMove(GameObject Player, GameObject finalPos)
    {
        Player P = GameObject.Find("Player").GetComponent<Player>();

        if (P != null)
        {
            if (Player.transform.position.y < finalPos.transform.position.y)
            {
                float topLimit = P.GetYWalkLimitTop() + 10;
                float bottomLimit = P.GetYWalkLimitBottom() + 10;

                P.SetYWalkLimits(topLimit, bottomLimit);
            }
            else if (Player.transform.position.y > finalPos.transform.position.y)
            {
                float topLimit = P.GetYWalkLimitTop() - 10;
                float bottomLimit = P.GetYWalkLimitBottom() - 19;

                P.SetYWalkLimits(topLimit, bottomLimit);
            }
        }

        Player.transform.position = finalPos.transform.position;
    }
}
