using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbingLogic : MonoBehaviour
{
    public Transform playerLAxeTransform;
    public Transform playerRAxeTransform;
    private Vector3 pickaxeOnCollidePosition;
    private Vector3 playerOnCollidePosition;
    public ClimberHand RightHand;
    public ClimberHand LeftHand;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LeftHand.TouchedCount > 0)
        {
            RightHand.grabbing = false;
            LeftHand.grabbing = true;
            pickaxeOnCollidePosition = playerLAxeTransform.position;
            playerOnCollidePosition = gameObject.transform.position;
        }
        if (RightHand.TouchedCount > 0)
        {
            LeftHand.grabbing = false;
            RightHand.grabbing = true;
            pickaxeOnCollidePosition = playerRAxeTransform.position;
            playerOnCollidePosition = gameObject.transform.position;
        }

        if (LeftHand.grabbing)
        {
            gameObject.transform.position = playerOnCollidePosition + (pickaxeOnCollidePosition - playerLAxeTransform.position);
        }
        if (RightHand.grabbing)
        {
            gameObject.transform.position = playerOnCollidePosition + (pickaxeOnCollidePosition - playerRAxeTransform.position);
        }
    }
}
