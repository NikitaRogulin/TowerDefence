using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<CannonProjectile>(out CannonProjectile projectile))
        {
            Destroy(projectile.gameObject);
        }
    }
}
