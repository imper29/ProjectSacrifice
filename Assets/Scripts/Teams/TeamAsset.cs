using UnityEngine;

namespace ProjectSacrifice
{
    [CreateAssetMenu]
    public class TeamAsset : ScriptableObject
    {
        [SerializeField]
        private bool friendlyFire;

        /// <summary>
        /// Returns true if the team allows friendly fire.
        /// </summary>
        public bool FriendlyFire {
            get => friendlyFire;
            set => friendlyFire = false;
        }
    }
}
