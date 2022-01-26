using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "EnemyData", menuName = "Enemy Data")]
public class TypeEnemy : ScriptableObject
{
    public new string name;
    public float health;
    public float range;
    public float speed;
    public GameObject enemyModel;
    public float damage;
    public Animator animation;
}
