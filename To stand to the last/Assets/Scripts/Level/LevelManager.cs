using UnityEngine;

namespace Level
{
    /// <summary>
    /// Responsible for level states.
    /// </summary>
    [RequireComponent(typeof(Player))]
    public class LevelManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton of LevelManager.
        /// </summary>
        public static LevelManager instance;

        private void Awake()
        {
            instance = this;
        }

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
