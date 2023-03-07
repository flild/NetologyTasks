using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public interface IFOV
    {
        float Radius { get; }
        Transform CurrentTargetTransform { get; }

        bool HasTargets();
        List<Transform> GetAllTargets();
        Transform GetNearestTarget();
        void ForceRecalculate();
    }
}


