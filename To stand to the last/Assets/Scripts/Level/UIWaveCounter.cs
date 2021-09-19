using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    /// <summary>
    /// Class for displaying the wave counter.
    /// </summary>
    public class UIWaveCounter : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        /// <summary>
        /// Update wave counter (UI).
        /// </summary>
        /// <param name="current">Current wave.</param>
        /// <param name="max">Max wave.</param>
        public void UpdateWaveCounter(int current, int max)
        {
            _text.text = $"WAVE {current}/{max}";
        }
    }
}
