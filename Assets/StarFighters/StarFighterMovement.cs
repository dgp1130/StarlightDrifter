using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighter
{
    public class StarFighterMovement : MonoBehaviour
    {
        private static readonly Vector3 pitchAxis = Vector3.left;
        private static readonly Vector3 yawAxis = Vector3.up;
        private static readonly Vector3 rollAxis = Vector3.back;

        private Rigidbody body = null!;

        public StarFighterControls controls = null!;

        public void Awake()
        {
            controls = new StarFighterControls();
        }

        public void Start()
        {
            body = GetComponent<Rigidbody>();
            body.AddForce(transform.forward * 10, ForceMode.VelocityChange);

            controls.StarFighter.Pitch.performed += (ctx) =>
            {
                var pitch = ctx.ReadValue<float>();
                // Negate the pitch for inverted controls.
                body.AddTorque(pitchAxis * 10 * -pitch, ForceMode.Acceleration);
            };

            controls.StarFighter.Yaw.performed += (ctx) =>
            {
                var yaw = ctx.ReadValue<float>();
                body.AddTorque(yawAxis * 10 * yaw, ForceMode.Acceleration);
            };

            controls.StarFighter.Roll.performed += (ctx) =>
            {
                var roll = ctx.ReadValue<float>();
                body.AddTorque(rollAxis * 10 * roll, ForceMode.Acceleration);
            };
        }

        public void OnEnable()
        {
            controls.StarFighter.Enable();
        }

        public void OnDisable()
        {
            controls.StarFighter.Disable();
        }
    }
}
