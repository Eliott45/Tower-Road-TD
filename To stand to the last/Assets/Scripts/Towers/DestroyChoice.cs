using Mouse;
using UnityEngine;

/// <summary>
/// When the player chooses to destroy the tower.
/// </summary>
public class DestroyChoice : MonoBehaviour, IClicked
{
    public void OnClick()
    {
        Destroy(BuildPanel.instance.towerSpotTransform.gameObject);
    }
}
