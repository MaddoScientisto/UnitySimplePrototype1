using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;

        [SerializeField]
        private Camera _camera;

        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
        }

        
        public void OnPlayerJoined(PlayerInput playerInput)
        {
            Console.WriteLine($"Spawned {playerInput.playerIndex}");

            
        }
    }
}
