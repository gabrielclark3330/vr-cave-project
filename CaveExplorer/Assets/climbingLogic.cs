using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbingLogic : MonoBehaviour
{
    public Transform playerLAxeTransform;
    public Transform playerRAxeTransform;
    private Vector3 pickaxeOriginOnCollide;
    private Vector3 playerOriginOnCollide;

    // Start is called before the first frame update
    void Start()
    {
        pickaxeOriginOnCollide = gameObject.transform.position;
        playerOriginOnCollide = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerOriginOnCollide + (pickaxeOriginOnCollide - playerRAxeTransform.position);
        //gameObject.transform.position = playerOriginOnCollide + (pickaxeOriginOnCollide - playerLAxeTransform.position);
    }
}
