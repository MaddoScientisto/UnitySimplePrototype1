using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public float Health => _health;
        [SerializeField]
        private int _health;
        [SerializeField]
        private int _startHealth = 100;

        private void Start()
        {
            _health = _startHealth;
        }

        public void Add(int amount)
        {
            _health += amount;
        }
    }
}
