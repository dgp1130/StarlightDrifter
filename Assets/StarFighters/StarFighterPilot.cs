using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighters
{
    /**
     * Represents a "pilot", responsible for controlling a StarFighter.
     * 
     * The inputs of this class are the actual user controls, while the output of this class
     * is a `PilotAction`, representing the intent of the user over the last frame.
     */
    [CreateAssetMenu(menuName = "StarFighters/Pilot")]
    class StarFighterPilot : ScriptableObject
    {
        private StarFighterControls controls = null!;

        [SerializeField] private float maxMouseDeltaPixels = 50;

        private float pitchDeltaPixels;
        private float yawDeltaPixels;
        private float rollDelta;
        private float thrustDelta;

        public void Start()
        {
            // Listen to user controls and update internal state.
            
            controls.StarFighter.Pitch.performed += (ctx) =>
            {
                pitchDeltaPixels += ctx.ReadValue<float>();
            };

            controls.StarFighter.Yaw.performed += (ctx) =>
            {
                yawDeltaPixels += ctx.ReadValue<float>();
            };

            controls.StarFighter.Roll.started += (ctx) =>
            {
                rollDelta = ctx.ReadValue<float>();
            };
            controls.StarFighter.Roll.canceled += (ctx) =>
            {
                rollDelta = 0;
            };

            controls.StarFighter.Thrust.started += (ctx) =>
            {
                thrustDelta = ctx.ReadValue<float>();
            };
            controls.StarFighter.Thrust.canceled += (ctx) =>
            {
                thrustDelta = 0;
            };
        }

        /** Flushes the pilot's actions and returns a `PilotAction` of the desired movement. */
        public PilotAction Act()
        {
            // Restrict to the maximum delta, if the mouse moved farther than that,
            // then we assume user desired maximum movement in that direction.
            var pitchDelta = Mathf.Clamp(pitchDeltaPixels / maxMouseDeltaPixels, -1, 1);
            var yawDelta = Mathf.Clamp(yawDeltaPixels / maxMouseDeltaPixels, -1, 1);

            // Generate an action from values accumulated over the last frame.
            var action = new PilotAction(
                pitch: pitchDelta,
                yaw: yawDelta,
                roll: rollDelta,
                thrust: thrustDelta
            );

            // Reset relevant values for the next frame.
            pitchDeltaPixels = 0;
            yawDeltaPixels = 0;

            return action;
        }

        public void OnEnable()
        {
            controls ??= new StarFighterControls();
            controls.Enable();
        }

        public void OnDisable()
        {
            controls.Disable();
        }
    }
}
