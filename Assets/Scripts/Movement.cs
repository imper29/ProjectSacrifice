using ProjectSacrifice.Messages;
using UnityEngine;

namespace ProjectSacrifice
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour, IMessageListenerPost<Movement.MsgChangeUnscaledTargetVelocity>
    {
        private Rigidbody2D body;

        /// <summary>
        /// The maximum amount of time it will take for something to accelerate from -maximumSpeed to +maximumSpeed.
        /// </summary>
        public Statistic maximumAccelerationTime;
        /// <summary>
        /// The maximum walking speed.
        /// </summary>
        public Statistic maximumSpeed;
        /// <summary>
        /// The unscaled target velocity.
        /// </summary>
        private Vector2 unscaledTargetVelocity;

        public void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }
        public void FixedUpdate()
        {
            float maximumCorrectionVelocityMagnitude = maximumSpeed.Result / maximumAccelerationTime.Result * Time.fixedDeltaTime;
            Vector2 correctionVelocity = unscaledTargetVelocity * maximumSpeed.Result - body.velocity;
            float correctionVelocityMagnitude = correctionVelocity.magnitude;
            if (correctionVelocityMagnitude > maximumCorrectionVelocityMagnitude) {
                correctionVelocity.Normalize();
                correctionVelocity *= maximumCorrectionVelocityMagnitude;
            }
            body.AddForce(correctionVelocity, ForceMode2D.Impulse);
        }

        public void OnMessageReceivedPost(ref MsgChangeUnscaledTargetVelocity message)
        {
            if (message.unscaledVelocity.sqrMagnitude > 1f)
                unscaledTargetVelocity = message.unscaledVelocity.normalized;
            else
                unscaledTargetVelocity = message.unscaledVelocity;
        }

        public struct MsgChangeUnscaledTargetVelocity : IMessage
        {
            public Vector2 unscaledVelocity;
        }
    }
}
