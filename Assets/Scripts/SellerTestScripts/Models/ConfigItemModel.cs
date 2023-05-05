using System;
using UnityEngine;

namespace Models
{
   [Serializable]
   public class ConfigItemModel
   {
      public string Name => _name;
   
      public float Price => _price;
   
      public Sprite View => _view;
      
      [SerializeField]
      private string _name;
   
      [SerializeField]
      private float _price;
      
      [SerializeField]
      private Sprite _view;
   }
}

