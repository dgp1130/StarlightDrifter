#nullable enable

namespace StarlightDrifter.StarFighters
{
    /**
     * Record class representing a pilot's intent over a period of time (usually a frame).
     * 
     * The values here roughly correlate to how an actual pilot manipulates the controls of an
     * aircraft. For example, pulling a joystick all the way to the right would represent a
     * maximum clockwise roll (`roll = 1`), while pressing a break pedal half way might represent
     * half deceleration (`thrust = -0.5`).
     * 
     * TODO: `pitch` and `yaw` are currently defined in terms of pixels moved by a mouse, but this
     * is temporary as it leaks the mouse abstraction into this type. These should also be clamped
     * to [-1, 1].
     */
    class PilotAction
    {
        /**
         * Represnts the number of pixels the user has moved the mouse across the pitch axis.
         * Positive values represent a desire to pitch upwards.
         * Negative values represent a desire to pitch downwards.
         * A zero value represents no change to the pitch.
         */
        public readonly float pitch;

        /**
         * Represnts the number of pixels the user has moved the mouse across the yaw axis.
         * Positive values represent a desire to yaw right.
         * Negative values represent a desire to yaw left.
         * A zero value represents no change to the yaw.
         */
        public readonly float yaw;

        /**
         * Represents rotation around the roll axis, clamped to [-1, 1].
         * Positive values represent a desire to roll clockwise (when facing forward).
         * Negative values represent a desire to roll counter-clockwise (when facing forward).
         * The magnitude of the value is linearly scaled, so a value of 1/-1 indicates a roll at
         * maximum speed, while a value of 0.5/-0.5 represents a half speed roll.
         * A zero value represents no roll.
         */
        public readonly float roll;

        /**
         * Represents thrust along the forward axis, clamped to [-1, 1].
         * Positive values represent a desire to move forward.
         * Negative values represent a desire to move backward.
         * The magnitude of the value is linearly scaled, so a value of 1/-1 indicates maximum
         * acceleration/deceleration, while a value of 0.5/-0.5 represents half
         * acceleration/deceleration.
         * A zero value represents no acceleration/deceleration.
         */
        public readonly float thrust;

        public PilotAction(float pitch, float yaw, float roll, float thrust)
        {
            this.pitch = pitch;
            this.yaw = yaw;
            this.roll = roll;
            this.thrust = thrust;
        }
    }
}
