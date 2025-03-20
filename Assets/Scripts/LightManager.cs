using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    //This video was a great help figuring out how to detect the player
    //https://www.youtube.com/watch?v=j1-OyLo77ss
    //Variables for range of light and motion
    public float radius;
    public float angle;

    public float delay;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;



    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (canSeePlayer)
        {
            fieldOfViewCheck();
        } else
        {
            
        }
    }

    private void fieldOfViewCheck()
    {
        //Layermask looks at a perticular Layer to search for objects
        //Then put player on its own Layer, in this case targetMask
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //Only check the first layer of array because there is only the player
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                //Start a raycast, "Physics.Raycast"
                //from the centre of the lightsource, "transform.position"
                //Air the raycast towards player "direction to target"
                //Limit raycast length to "distanceToTarget"
                //Stop Raycast if it collides with "obstructionMask"
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                } else
                {
                    canSeePlayer = false;
                }
            } else
            {
                canSeePlayer = false;
            }
        //If you were previously in view but dropped it, it should be disconected
        } else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
