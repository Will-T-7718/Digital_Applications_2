using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class PlayerGunSelect : MonoBehaviour
{
    [SerializeField]
    private GunType Gun;
    [SerializeField]
    private Transform GunParent;
    [SerializeField]
    private List<GunObjScriptable> Guns;
    [Space]
    [Header("Runtime Filled")]
    public GunObjScriptable ActiveGun;

    private void Start()
    {
        GunObjScriptable gun = Guns.Find(gun => gun.type == Gun);

        if (gun == null )
        {
            Debug.LogError($"No GunScriptableObject found for GunType: {gun}");
            return;
        }
        ActiveGun = gun;
        gun.spawn(GunParent, this);
    }
}
