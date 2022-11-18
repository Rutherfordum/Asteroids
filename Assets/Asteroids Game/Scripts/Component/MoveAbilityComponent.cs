using System;
using Asteroid.Interfaces;
using UnityEngine;

namespace Asteroid.Components
{
    public class MoveAbilityComponent : MonoBehaviour, IMoveAbility
    {
        [SerializeField] [Range(1, 100)] private float _speed = 1;

        [SerializeField] [Range(1, 100)] private float _turningSpeed = 10;

        public float Speed
        {
            get => _speed / 100;
            set
            {
                if (value <= 0 || value > 100)
                    throw new ArgumentException("value is a big", "Speed");

                _speed = value;
            }
        }

        public float TurningSpeed
        {
            get => _turningSpeed;
            set
            {
                if (value <= 0 || value > 100)
                    throw new ArgumentException("value is a big", "SpeedRotate");

                _turningSpeed = value;
            }
        }

        public void Execute()
        {

        }
    }
}