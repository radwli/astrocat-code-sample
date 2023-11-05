using UnityEngine;

namespace Astrocat
{
    [CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item/Basic")]

    public class ItemScriptableObject : ScriptableObject
    {
        public string itemName;
        public string description;

        public Sprite art;
    }
}