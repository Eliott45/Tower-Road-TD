using Mouse;
using UnityEngine;

public class TowerSpot : MonoBehaviour, IClicked
{
    public void OnClick()
    {
        BuildPanel.instance.Display(true, transform.position);
    }   
}
