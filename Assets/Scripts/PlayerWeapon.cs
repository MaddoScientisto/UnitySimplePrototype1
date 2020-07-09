using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerWeapon : MonoBehaviour
    {
        private PlayerController _owner;

        [SerializeField]
        private Bullet _bullet;

        [SerializeField]
        private float _rateOfFire = 0.2f;

        [SerializeField]
        private GameObject _originMarker;

        private float _fireTimer = 0f;

        private void Awake()
        {
            _owner = GetComponentInParent<PlayerController>();
        }

        public void Fire()
        {
            if (_fireTimer > _rateOfFire)
            {
                _fireTimer = 0;
                var bullet = Instantiate(_bullet, _originMarker.transform.position, _originMarker.transform.rotation);

                //Debug.DrawRay(bullet.transform.position, bullet.transform.forward, Color.green, 10f);
                //Debug.DrawRay(_originMarker.transform.position, _originMarker.transform.forward, Color.red, 10f);

                bullet.Owner = _owner;

                Destroy(bullet.gameObject, bullet.LifeTime);
            }



        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }
    }
}
