using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighter
{
    public class StarFighterMovement : MonoBehaviour
    {
        [SerializeField] private StarFighterPilot pilot = null!;

        private Vector3 pitchAxis => transform.TransformDirection(Vector3.left);
        private Vector3 yawAxis => transform.TransformDirection(Vector3.up);
        private Vector3 rollAxis => transform.TransformDirection(Vector3.back);

        private Vector3 forward => transform.TransformDirection(Vector3.forward);

        private Rigidbody? body; // Body may be null when drawing Gizmos.

        public void Start()
        {
            pilot.Start();
            body = GetComponent<Rigidbody>();
        }

        public void FixedUpdate()
        {
            if (body == null) return;

            var action = pilot.Act();

            // TODO: Order here matters, because thrust can be applied before or after rotation is applied, affecting movement.
            // Ideally, this movement should be interpolated, to simulate it's application over `Time.deltaTime`. For example,
            // we could linearly interpolate the previous frame's rotation/thrust and the new frame's rotation/thrust, then
            // sample that interpolation N times, applying that force scaled by `Time.deltaTime / N` to more accurately simulate
            // the intended movement from the player.
            if (action.pitch != 0) body.AddTorque(pitchAxis * 10 * action.pitch * Time.deltaTime, ForceMode.Force);
            if (action.yaw != 0) body.AddTorque(yawAxis * 10 * action.yaw * Time.deltaTime, ForceMode.Force);
            if (action.roll != 0) body.AddTorque(rollAxis * 10 * action.roll * Time.deltaTime, ForceMode.Force);
            if (action.thrust != 0) body.AddForce(forward * 100 * action.thrust * Time.deltaTime, ForceMode.Force);
        }

        [SerializeField] private Vector3 rotationalMomentumGizmosDrawOffset;
        private Vector3 momentumGizmosDrawPoint => transform.position + transform.TransformDirection(rotationalMomentumGizmosDrawOffset);
        public void OnDrawGizmosSelected()
        {
            if (body == null) return;

            // Draw velocity vectory.
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(momentumGizmosDrawPoint, body.velocity);

            // Draw vectors representing rotational momentum.
            Gizmos.color = Color.red;
            var pitchMagnitude = Vector3.Dot(body.angularVelocity, pitchAxis);
            Gizmos.DrawRay(momentumGizmosDrawPoint, -pitchAxis * pitchMagnitude);

            Gizmos.color = Color.green;
            var yawMagnitude = Vector3.Dot(body.angularVelocity, yawAxis);
            Gizmos.DrawRay(momentumGizmosDrawPoint, yawAxis * yawMagnitude);

            Gizmos.color = Color.blue;
            var rollMagnitude = Vector3.Dot(body.angularVelocity, rollAxis);
            Gizmos.DrawRay(momentumGizmosDrawPoint, -rollAxis * rollMagnitude);
        }
    }
}
