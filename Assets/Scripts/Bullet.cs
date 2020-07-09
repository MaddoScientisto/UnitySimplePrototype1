using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _solidMask;

        [SerializeField]
        private float _speed = 12f;

        public int Damage => _damage;

        [SerializeField]
        private int _damage = 1;

        public float LifeTime => _lifeTime;

        [SerializeField]
        private float _lifeTime = 2f;

        public PlayerController Owner
        {
            get => _owner;
            set => _owner = value;
        }
        private PlayerController _owner;

        private void Update()
        {
            this.transform.Translate(transform.up * _speed * Time.deltaTime, Space.World);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Debug.Log("Collision");

            if ((_solidMask.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                Destroy(this.gameObject);
            }

            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("Trigger");
            if ((_solidMask.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                Destroy(this.gameObject);
            }
        }



    }
}
