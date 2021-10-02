using Level;
using Mouse;
using TMPro;
using UnityEngine;

public class BuildChoice : MonoBehaviour, IClicked
{
    [Header("Set in Inspector:")] 
    [SerializeField] private int _price;
    [SerializeField] private TMP_Text _priceText;

    private Player _player;

    private void Start()
    {
        _player = Player.instance;
        _priceText.text = _price.ToString();
    }
    
    public void OnClick()
    {
        if (_player.GetGold() < _price) return;
        BuildPanel.instance.Display(false);
        _player.SpentGold(_price);
    }
}
