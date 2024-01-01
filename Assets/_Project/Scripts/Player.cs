using System;
using UnityEngine;
namespace Shmup
{
    public class Player : Plane
    {

        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;

        float fuel;

        void Start()
        {
            fuel = maxFuel;
        }
        public float GetFuelNormalized()
        {
            return fuel / maxFuel;
        }
        void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }

        public void AddFuel(int amount)
        {
            fuel += amount;
            if(fuel > maxFuel)
            {
                fuel = maxFuel;
            }
        }

        protected override void Die()
        {
            // TODO
        }

        internal void AddFuel(float amount)
        {
            throw new NotImplementedException();
        }
    }
}
