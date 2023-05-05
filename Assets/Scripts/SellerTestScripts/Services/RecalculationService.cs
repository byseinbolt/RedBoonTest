using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class RecalculationService : IRecalculationService
    { 
        public float RecalculateSellingPrice(float price, bool isBought)
        {
            return isBought ? Mathf.Round(price / 1.5f)  : Mathf.Round(price * 1.5f);
        }
    }
}