using UnityEngine;
using Valve.VR;

public class ClimberHand : MonoBehaviour
{
    public SteamVR_Input_Sources Hand;
    public int TouchedCount;
    public bool grabbing = false;
    public Transform axe;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount--;
        }
    }

    void Update()
    {
        //axe = gameObject.transform;
    }
}