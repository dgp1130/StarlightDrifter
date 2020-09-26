using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighter
{
    public class StarFighterMovement : MonoBehaviour
    {
        private Rigidbody body = null!;

        void Start()
        {
            body = GetComponent<Rigidbody>();
            body.AddForce(transform.forward * 10, ForceMode.VelocityChange);
        }
    }
}
