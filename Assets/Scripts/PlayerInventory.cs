using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerInventory : MonoBehaviour
    {
        public int ResourceAmount
        {
            get => _resourceAmount;
            set => _resourceAmount = value;
        }

        [SerializeField]
        private int _resourceAmount;

    }
}
