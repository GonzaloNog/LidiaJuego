using UnityEngine;

[CreateAssetMenu(fileName = "Attributes", menuName = "Attributes")]
public class Attributes : ScriptableObject
{
    public float life;
    public float maxLife;
    public float dmg, attackRange;
    public bool aggresive;
    public string nombre;
}
