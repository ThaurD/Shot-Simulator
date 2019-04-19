using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    void Heal();
    void OnCollisionEnter(Collision col);
}
