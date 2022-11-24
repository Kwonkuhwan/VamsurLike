using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    Transform transform { get; }
    float AttackPower { get; }

    void Attack(ITakeDamage target);
}
