using UnityEngine;

/// <summary>
/// UI Construction panel.
/// </summary>
public class BuildPanel : MonoBehaviour
{
    /// <summary>
    /// Singleton of build panel.
    /// </summary>
    public static BuildPanel instance;
    /// <summary>
    /// Transform of tower spot.
    /// </summary>
    public Transform towerSpotTransform { get; private set; }

    private void Awake()
    {
        instance = this;
        Display(false);
    }

    /// <summary>
    /// Show or not show construction panel.
    /// </summary>
    /// <param name="statusDisplay">Enable panel(true/false).</param>
    /// <param name="spot"></param>
    /// <param name="newPos">New position of panel.</param>
    public void Display(bool statusDisplay, Transform newPos = null)
    {
        if (newPos != null)
        {
            gameObject.transform.position = newPos.position;
            towerSpotTransform = newPos;
        }
        gameObject.SetActive(statusDisplay);
    }
    
}
