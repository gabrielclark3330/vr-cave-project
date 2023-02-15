using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorMovement : MonoBehaviour
{

    public Transform playerTransform;
    public Transform playerLHandTransform;
    public Transform playerRHandTransform;
    private Vector3 pickaxeOrigin;
    private Vector3 playerOrigin;

    // Start is called before the first frame update
    void Start()
    {
        pickaxeOrigin = gameObject.transform.position;
        playerOrigin = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform.position = playerOrigin + (pickaxeOrigin-gameObject.transform.position);
    }
}
