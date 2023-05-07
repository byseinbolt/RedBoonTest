using UnityEngine;

namespace SellerTestScripts.Models
{
    public class ItemModel
    {
        public string Name { get; }
        public float Price { get; set; }
        public Sprite View { get; }

        public ItemModel(string name, float price, Sprite view)
        {
            Name = name;
            Price = price;
            View = view;
        }
    }
}