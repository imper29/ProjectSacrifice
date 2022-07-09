using UnityEngine;

namespace ProjectSacrifice
{
    [RequireComponent(typeof(Health))]
    public class HealthRegeneration : MonoBehaviour
    {
        [SerializeField] private Statistic m_Regeneration;
        /// <summary>
        /// The regeneration strength.
        /// </summary>
        public Statistic Regeneration => m_Regeneration;

        private void FixedUpdate()
        {
            GetComponent<Health>().Modify(Regeneration.Result * Time.fixedDeltaTime, gameObject);
        }
    }
}
