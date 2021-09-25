using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    /// <summary>
    /// Class for displaying the wave counter.
    /// </summary>
    public class UIWaveCounter : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>(); // Get Text Mesh Pro from this object
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
