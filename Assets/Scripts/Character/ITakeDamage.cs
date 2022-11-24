using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamage
{
    Transform transform { get; }
    float DefencePower { get; }

    void TakeDamage(float damage);
}
