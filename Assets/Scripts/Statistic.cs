using UnityEngine;

namespace ProjectSacrifice
{
    /// <summary>
    /// Statistic is used to represent something like movement speed or maximum health.
    /// </summary>
    [System.Serializable] public struct Statistic
    {
        [SerializeField] private float m_Base;
        [SerializeField] private float m_Addition;
        [SerializeField] private float m_Multiplier;
        
        public Statistic(float @base, float addition, float multiplier)
        {
            m_Base = @base;
            m_Addition = addition;
            m_Multiplier = multiplier;
        }

        /// <summary>
        /// Base is the initial value when calculating the result.
        /// </summary>
        public float Base {
            get => m_Base;
            set => m_Base = value;
        }
        /// <summary>
        /// Addition is applied to base after multipler when calculating the result.
        /// </summary>
        public float Addition {
            get => m_Addition;
            set => m_Addition = value;
        }
        /// <summary>
        /// Multiplier is applied to base before addition when calculating the result.
        /// </summary>
        public float Multiplier {
            get => m_Multiplier;
            set => m_Multiplier = value;
        }
        /// <summary>
        /// The final value calcualted as <see cref="Base"/> * <see cref="Multiplier"/> + <see cref="Addition"/>.
        /// </summary>
        public float Result {
            get => m_Base * m_Multiplier + m_Addition;
        }

        public static Statistic operator +(Statistic l, Statistic r)
        {
            return new(l.m_Base + r.m_Base, l.m_Addition + r.m_Addition, l.m_Multiplier + r.m_Multiplier);
        }
        public static Statistic operator -(Statistic l, Statistic r)
        {
            return new(l.m_Base - r.m_Base, l.m_Addition - r.m_Addition, l.m_Multiplier - r.m_Multiplier);
        }
    }
}
