using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Player))]
    public class LevelManager : MonoBehaviour
    {
        /// <summary>
        /// Win the game.
        /// </summary>
        public void Win()
        {
            Debug.Log("You win");
        }

        /// <summary>
        /// Lose the game.
        /// </summary>
        public void Lose()
        {
            Debug.Log("You lose");
        }
        
        private void Pause() {}
        private void Restart() {}
    }
}
