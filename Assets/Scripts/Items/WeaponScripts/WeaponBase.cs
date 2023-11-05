using System.Collections.Generic;
using UnityEngine;

namespace Astrocat
{
    namespace Items
    {
        namespace Weapons
        {
            public class WeaponBase : MonoBehaviour
            {
                [SerializeField] private Transform _anchorPoint;
                [SerializeField] private List<Transform> _outlets;
                [SerializeField] private WeaponScriptableObject _weaponData;

                private int _ammoLeft;
                private IShoot _shootingType;

                public Transform AnchorPoint => _anchorPoint;
                public List<Transform> Outlets => _outlets;
                public WeaponScriptableObject WeaponData => _weaponData;
                public int AmmoLeft { get => _ammoLeft; set => _ammoLeft = value; }
                public IShoot ShootingType { get => _shootingType; protected set => _shootingType = value; }
            }
        }
    }
}