using UnityEngine;

public class ClimberHand : MonoBehaviour
{
    public int TouchedCount;
    public bool grabbing;
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
        axe = gameObject.transform;
    }
}