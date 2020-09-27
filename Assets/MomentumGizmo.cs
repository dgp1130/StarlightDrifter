using UnityEngine;

#nullable enable

namespace StarlightDrifter
{
    [RequireComponent(typeof(Rigidbody))]
    class MomentumGizmo : MonoBehaviour
    {
        private Vector3 pitchAxis => transform.TransformDirection(Vector3.right);
        private Vector3 yawAxis => transform.TransformDirection(Vector3.up);
        private Vector3 rollAxis => transform.TransformDirection(Vector3.forward);

        [SerializeField] private Vector3 momentumGizmosDrawOffset;
        private Vector3 momentumGizmosDrawPoint =>
                transform.position + transform.TransformDirection(momentumGizmosDrawOffset);

        private Rigidbody? body; // May be null in editor.

        public void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        public void OnDrawGizmosSelected()
        {
            if (body == null) return;

            // Draw simple sphere at start point, so it is visible even when everything else is 0.
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(momentumGizmosDrawPoint, 0.1f);

            // Draw velocity vector.
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(momentumGizmosDrawPoint, body.velocity);

            // Draw vectors representing rotational momentum.
            Gizmos.color = Color.red;
            var pitchMagnitude = Vector3.Dot(body.angularVelocity, pitchAxis);
            Gizmos.DrawRay(momentumGizmosDrawPoint, pitchAxis * pitchMagnitude);

            Gizmos.color = Color.green;
            var yawMagnitude = Vector3.Dot(body.angularVelocity, yawAxis);
            Gizmos.DrawRay(momentumGizmosDrawPoint, yawAxis * yawMagnitude);

            Gizmos.color = Color.blue;
            var rollMagnitude = Vector3.Dot(body.angularVelocity, rollAxis);
            Gizmos.DrawRay(momentumGizmosDrawPoint, rollAxis * rollMagnitude);
        }
    }
}
