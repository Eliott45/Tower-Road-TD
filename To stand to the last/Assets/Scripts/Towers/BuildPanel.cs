using UnityEngine;

/// <summary>
/// UI Construction panel.
/// </summary>
[RequireComponent(typeof(Animator))]
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

    private static readonly int Index = Animator.StringToHash("index");
    private Animator _animator;

    private void Awake()
    {
        instance = this;
        _animator = GetComponent<Animator>(); 
        Display(false);
    }

    /// <summary>
    /// Show or not show construction panel.
    /// </summary>
    /// <param name="statusDisplay">Enable panel (true/false).</param>
    /// <param name="newPos">New position of panel.</param>
    /// <param name="level">Level of tower (0 is just a spot).</param>
    public void Display(bool statusDisplay, Transform newPos = null, int level = 0)
    {
        if (newPos != null)
        {
            gameObject.transform.position = newPos.position;
            towerSpotTransform = newPos;
        }
        _animator.SetFloat(Index, level);
        gameObject.SetActive(statusDisplay);
       
    }
}
