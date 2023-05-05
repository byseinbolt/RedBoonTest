using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class PlayerBalanceModel
    {
        public float Balance
        {
            get => _balance;
            set => _balance = value;
        }
        
        [SerializeField]
        private float _balance;
    }
}