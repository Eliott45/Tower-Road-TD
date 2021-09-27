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
    
    private void Awake()
    {
        instance = this;
        Display(false);
    }

    /// <summary>
    /// Show or not show construction panel.
    /// </summary>
    /// <param name="statusDisplay">Enable panel(true/false).</param>
    /// <param name="newPos">New position of panel.</param>
    public void Display(bool statusDisplay, Vector2 newPos = new Vector2())
    {
        var pos = gameObject.transform.position;
        pos.x = newPos.x;
        pos.y = newPos.y;
        gameObject.transform.position = pos;
        
        gameObject.SetActive(statusDisplay);
    }
    
}
