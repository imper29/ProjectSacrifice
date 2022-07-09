using UnityEngine;

namespace ProjectSacrifice
{
    public class Team : MonoBehaviour
    {
        [SerializeField]
        private TeamAsset current;

        /// <summary>
        /// The current team.
        /// </summary>
        public TeamAsset Current {
            get => current;
            set => current = value;
        }
    }
}
