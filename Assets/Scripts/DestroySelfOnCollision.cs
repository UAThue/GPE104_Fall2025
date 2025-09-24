using UnityEngine;

public class DestroySelfOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
