using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _startPositions;
        private int _playersCount = 0;

        private List<PlayerController> _players = new List<PlayerController>();

        private List<PlayerController> _deadPlayers = new List<PlayerController>();

        public void OnPlayerJoined(PlayerInput playerInput)
        {

            //_playersCount++;
            //playerInput.

            Debug.Log($"Spawned {playerInput.playerIndex}");

        }

        public int RegisterPlayer(PlayerController player)
        {
            _players.Add(player);
            _playersCount++;
            player.transform.position = _startPositions[_playersCount - 1].transform.position;

            return _playersCount - 1;
        }

        public void PlayerDied(PlayerController player)
        {
            _deadPlayers.Add(player);
            Debug.Log($"Player {player.PlayerId} died");
            if (_deadPlayers.Count >= _playersCount - 1)
            {
                var remainingPlayer = _players.FirstOrDefault(x => !_deadPlayers.Contains(x));

                if (remainingPlayer)
                {
                    Debug.Log($"Player {remainingPlayer.PlayerId} wins!");

                    StartCoroutine(WaitForRestart());

                }
                else
                {
                    Debug.Log("Error");
                }
            }
        }

        IEnumerator WaitForRestart()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(0);
        }


    }
}
