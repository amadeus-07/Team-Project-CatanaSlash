using UnityEngine;

public class FruitExplode : MonoBehaviour
{
    [SerializeField] GameObject whole;
    [SerializeField] GameObject slicesRoot;
    [SerializeField] float force = 4f;
    [SerializeField] float torque = 2f;

    public void Explode()
    {
        whole.SetActive(false);
        slicesRoot.SetActive(true);

        foreach (Rigidbody rb in slicesRoot.transform.GetComponentsInChildren<Rigidbody>())
        {
            rb.transform.SetParent(null);
            Vector3 dir = (rb.transform.position - slicesRoot.transform.position).normalized;
            rb.AddForce(dir * force, ForceMode.Impulse);
            rb.AddTorque(Random.onUnitSphere * torque, ForceMode.Impulse);
        }
    }
}
