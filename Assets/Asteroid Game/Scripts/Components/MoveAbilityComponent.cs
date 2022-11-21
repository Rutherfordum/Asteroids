using System;
using UnityEngine;

[RequireComponent(typeof(AbilitiesComponent))]
public class MoveAbilityComponent : MonoBehaviour, IMoveAbility
{

    [SerializeField]
    [Range(1, 10)]
    private float _speed = 1;

    [SerializeField]
    [Range(1, 10)]
    private float _turningSpeed = 10;

    public float Speed
    {
        get => _speed / 100;
        set
        {
            if (value <= 0)
                throw new ArgumentException("value cannot be less than or equal to zero");

            _speed = value;
        }
    }

    public float TurningSpeed
    {
        get => _turningSpeed;
        set
        {
            if (value <= 0)
                throw new ArgumentException("value cannot be less than or equal to zero");

            _turningSpeed = value;
        }
    }

    public void Execute()
    {

    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!GetComponent<AbilitiesComponent>().Abilities.Contains(this))
            GetComponent<AbilitiesComponent>().Abilities.Add(this);
    }
#endif

}
