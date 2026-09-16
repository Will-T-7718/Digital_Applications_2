using UnityEngine;

[CreateAssetMenu(fileName = "Shoot Config", menuName = "Guns/Gun Shoot Config", order = 2)]
public class ShootObjConScript : ScriptableObject
{
    public LayerMask HitMask;
    public Vector3 Spread = new Vector3 (0.1f, 0.1f, 0.1f);
    public float FireRate = 0.25f;
}
