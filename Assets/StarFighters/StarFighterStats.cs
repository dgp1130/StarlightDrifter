using UnityEngine;

namespace StarlightDrifter.StarFighters
{
    /** Represents tweakable parameters about a StarFighter. */
    [CreateAssetMenu(menuName = "StarFighters/Stats")]
    public class StarFighterStats : ScriptableObject
    {
        [SerializeField] private float pitchScalar;
        public float PitchScalar => pitchScalar;

        [SerializeField] private float yawScalar;
        public float YawScalar => yawScalar;

        [SerializeField] private float rollScalar;
        public float RollScalar => rollScalar;

        [SerializeField] private float thrustScalar;
        public float ThrustScalar => thrustScalar;
    }
}
