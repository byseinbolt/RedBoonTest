using SellerTestScripts.Services.Interfaces;
using UnityEngine;

namespace SellerTestScripts.Services
{
    public class RecalculationService : IRecalculationService
    { 
        public float RecalculateSellingPrice(float price, bool isBought)
        {
            return isBought ? Mathf.Round(price / 1.5f)  : Mathf.Round(price * 1.5f);
        }
    }
}