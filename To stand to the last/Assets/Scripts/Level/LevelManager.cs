using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Player))]
    public class LevelManager : MonoBehaviour
    {
        private void Win() { }

        /// <summary>
        /// Lose the game.
        /// </summary>
        public static void Lose()
        {
            Debug.Log("You lose game");
        }
        
        private void Pause() {}
        private void Restart() {}
    }
}
