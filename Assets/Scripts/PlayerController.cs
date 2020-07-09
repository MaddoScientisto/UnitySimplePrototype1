using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private int _speed = 4;

        public int PlayerId => _playerId;
        private int _playerId = 0;

        private bool _alive = true;

        private InputProvider _inputProvider;
        private Rigidbody2D _rigidbody;
        private PlayerInventory _playerInventory;
        private PlayerWeapon _playerWeapon;
        private PlayerHealth _playerHealth;

        private GameManager _gameManager;

        private void Awake()
        {
            _inputProvider = this.GetComponent<InputProvider>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerInventory = GetComponent<PlayerInventory>();
            _playerWeapon = GetComponentInChildren<PlayerWeapon>();
            _playerHealth = GetComponent<PlayerHealth>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        [SerializeField]
        private Vector2 _snappedVector = Vector2.up;

        private void Start()
        {
            _playerId = _gameManager.RegisterPlayer(this);
        }

        void Update()
        {


            if (_inputProvider.Firing && _alive)
            {
                _playerWeapon.Fire();
            }


            //if (_inputProvider.LookVector != Vector2.zero)
            //{
            //    var vect = _inputProvider.LookVector;

            //    var snappedVect = SnapVector(vect);
            //    _snappedVector = snappedVect;
            //    var whatever = Vector2.SignedAngle(Vector2.up, snappedVect);

            //    var quat = Quaternion.RotateTowards(transform.rotation, qua )

            //    transform.Rotate(transf, whatever);

            //    //_rigidbody.MoveRotation(whatever);


            //    //Quaternion targetRotation = Quaternion.LookRotation(snappedVect, Vector3.back);
            //    //this._rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime));
            //    //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
            //    //this._rigidbody.MoveRotation(Quaternion.Euler(snappedVect * Time.fixedDeltaTime));

            //}
        }


        void FixedUpdate()
        {
            if (_alive)
            {
                var movementVector = _inputProvider.MovementVector * _speed * Time.fixedDeltaTime;

                _rigidbody.MovePosition(transform.position + new Vector3(movementVector.x, movementVector.y));
            }





            //this.transform.Translate(_inputProvider.MovementVector.x * _speed * Time.deltaTime, _inputProvider.MovementVector.y * _speed * Time.deltaTime, 0); 
        }

        private Vector2 SnapVector(Vector2 vect)
        {
            if (Mathf.Abs(vect.x) > Mathf.Abs(vect.y))
            {
                return Mathf.Sign(vect.x) > 0 ? Vector2.right : Vector2.left;
            }
            else
            {
                return Mathf.Sign(vect.y) > 0 ? Vector2.up : Vector2.down;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Pickup"))
            {
                _playerInventory.ResourceAmount++;
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("Bullet"))
            {
                var bullet = collision.gameObject.GetComponent<Bullet>();
                if (bullet.Owner != this)
                {
                    Destroy(bullet.gameObject);
                    _playerHealth.Add(-bullet.Damage);
                    if (_playerHealth.Health <= 0)
                    {
                        _alive = false;
                        _gameManager.PlayerDied(this);
                        this.gameObject.SetActive(false);
                    }
                }

            }
        }
        // TODO: Find how to move this to input controller
        //public void OnFire(InputAction.CallbackContext context)
        //{
        //    _playerWeapon.Fire();
        //}

    }
}
