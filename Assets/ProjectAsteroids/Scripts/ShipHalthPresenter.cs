
using Assets.ProjectAsteroids.Scripts.Interfaces;

public class ShipHalthPresenter : IShipHealth
{

    private IShipHealthView view;
    private ShipModel model;

    public ShipHalthPresenter(IShipHealthView view)
    {
        this.model = new ShipModel();
        this.view = view;
    }

    public void AddHealth(int value)
    {
        this.model.Health += value;
        this.view.SetHealth(this.model.Health);
    }
    public void SubHealth(int value)
    {
        this.model.Health -= value;
        this.view.SetHealth(this.model.Health);
    }

    public void Destroyed()
    {
        
    }
}
