using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighter
{
    public class StarFighterMovement : MonoBehaviour
    {
        private Vector3 pitchAxis => transform.TransformDirection(Vector3.left);
        private Vector3 yawAxis => transform.TransformDirection(Vector3.up);
        private Vector3 rollAxis => transform.TransformDirection(Vector3.back);

        private Vector3 forward => transform.TransformDirection(Vector3.forward);

        private float pitchDeltaPixels = 0;
        private float yawDeltaPixels = 0;
        private float rollDelta = 0;
        private float thrustDelta;

        private Rigidbody? body; // Body may be null when drawing Gizmos.

        public StarFighterControls controls = null!;

        public void Awake()
        {
            controls = new StarFighterControls();
        }

        public void Start()
        {
            body = GetComponent<Rigidbody>();

            controls.StarFighter.Pitch.performed += (ctx) =>
            {
                var pitch = ctx.ReadValue<float>();
                pitchDeltaPixels += pitch;
            };

            controls.StarFighter.Yaw.performed += (ctx) =>
            {
                var yaw = ctx.ReadValue<float>();
                yawDeltaPixels += yaw;
            };

            controls.StarFighter.Roll.started += (ctx) =>
            {
                var roll = ctx.ReadValue<float>();
                rollDelta = roll;
            };
            controls.StarFighter.Roll.canceled += (ctx) =>
            {
                rollDelta = 0;
            };

            controls.StarFighter.Thrust.started += (ctx) =>
            {
                var thrust = ctx.ReadValue<float>();
                thrustDelta = thrust;
            };
            controls.StarFighter.Thrust.canceled += (ctx) =>
            {
                thrustDelta = 0;
            };
        }

        public void FixedUpdate()
        {
            if (body == null) return;

            if (pitchDeltaPixels != 0)
            {
                // Negate the pitch for inverted controls.
                body.AddTorque(pitchAxis * 10 * -pitchDeltaPixels * Time.deltaTime, ForceMode.Force);
                pitchDeltaPixels = 0;
            }

            if (yawDeltaPixels != 0)
            {
                body.AddTorque(yawAxis * 10 * yawDeltaPixels * Time.deltaTime, ForceMode.Force);
                yawDeltaPixels = 0;
            }

            if (rollDelta != 0)
            {
                body.AddTorque(rollAxis * 10 * rollDelta * Time.deltaTime, ForceMode.Force);
            }

            if (thrustDelta != 0)
            {
                body.AddForce(forward * 100 * thrustDelta * Time.deltaTime, ForceMode.Force);
            }
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
