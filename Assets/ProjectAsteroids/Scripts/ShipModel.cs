using System;

public class ShipModel
{
    private const int _maxHealth = 10;


    public int Health
    {
        get
        {
            return _currentHealth;
        }

        set
        {
            if (value >= 0 && value <= _maxHealth)
                _currentHealth = value;
        }
    }

    private int _currentHealth;

}
