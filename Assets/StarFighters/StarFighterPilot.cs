using UnityEngine;

#nullable enable

namespace StarlightDrifter.StarFighter
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

        public PilotAction Act()
        {
            // Generate an action from values accumulated over the last frame.
            var action = new PilotAction(
                pitch: pitchDeltaPixels,
                yaw: yawDeltaPixels,
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
