using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSphereCast : MonoBehaviour
{
    [SerializeField]
    private float updateInterval;

    [SerializeField]
    private float radius;

    [SerializeField]
    private float range;

    internal delegate void SphereCastHit(RaycastHit hit);

    internal event SphereCastHit OnSphereCastHitEvent;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(IntervalUpdate());
    }

    // Update is called once per frame
    private IEnumerator IntervalUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);

            RaycastHit hit = new RaycastHit();
            Physics.SphereCast(transform.position, radius, transform.forward * range, out hit);

            OnSphereCastHitEvent?.Invoke(hit);
        }
    }
}
