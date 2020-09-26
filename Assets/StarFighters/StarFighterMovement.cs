using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighter
{
    public class StarFighterMovement : MonoBehaviour
    {
        private Vector3 pitchAxis => transform.TransformDirection(Vector3.left);
        private Vector3 yawAxis => transform.TransformDirection(Vector3.up);
        private Vector3 rollAxis => transform.TransformDirection(Vector3.back);

        private float pitchDeltaPixels = 0;
        private float yawDeltaPixels = 0;
        private float rollDirection = 0;

        private Rigidbody? body; // Body may be null when drawing Gizmos.

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
                rollDirection = roll;
            };
            controls.StarFighter.Roll.canceled += (ctx) =>
            {
                rollDirection = 0;
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

            if (rollDirection != 0)
            {
                body.AddTorque(rollAxis * 10 * rollDirection * Time.deltaTime, ForceMode.Force);
            }
        }

        [SerializeField] private Vector3 rotationalMomentumGizmosDrawOffset;
        private Vector3 rotMomentumGizmosDrawPoint => transform.position + transform.TransformDirection(rotationalMomentumGizmosDrawOffset);
        public void OnDrawGizmosSelected()
        {
            if (body == null) return;

            // Draw vectors representing rotational momentum.
            Gizmos.color = Color.red;
            var pitchMagnitude = Vector3.Dot(body.angularVelocity, pitchAxis);
            Gizmos.DrawRay(rotMomentumGizmosDrawPoint, -pitchAxis * pitchMagnitude);

            Gizmos.color = Color.green;
            var yawMagnitude = Vector3.Dot(body.angularVelocity, yawAxis);
            Gizmos.DrawRay(rotMomentumGizmosDrawPoint, yawAxis * yawMagnitude);

            Gizmos.color = Color.blue;
            var rollMagnitude = Vector3.Dot(body.angularVelocity, rollAxis);
            Gizmos.DrawRay(rotMomentumGizmosDrawPoint, -rollAxis * rollMagnitude);
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
