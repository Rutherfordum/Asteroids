using TMPro;
using UnityEngine;

public class ShipView: MonoBehaviour, IShipHealthView
{
    public TextMeshProUGUI HealthLabel;

    private IShipHealth shipHealth;

    private void Awake()
    {
        shipHealth = new ShipHalthPresenter(this);
    }

    public void SetHealth(int value)
    {
        HealthLabel.text = $"Health:{value}";
    }

    public void Destroyed()
    {
        Debug.Log("Ship is dead");
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Asteroid":
                shipHealth.SubHealth(1);
                break;

            case "Health":
                shipHealth.AddHealth(1);
                break;
        }
    }
}
