using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState 
{
    void StartState();
    void EndState();
    void UpdateState();
    void FixedUpdate();
}