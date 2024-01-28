using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DOTWeenHelper
{

    public static Sequence DOJumpZ(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
    {
        if (numJumps < 1)
        {
            numJumps = 1;
        }

        float startPosZ = target.position.z;
        float offsetZ = -1f;
        bool offsetZSet = false;
        Sequence s = DOTween.Sequence();
        Tween zTween = DOTween.To(() => target.position, delegate (Vector3 x)
        {
            target.position = x;
        }, new Vector3(0f, 0, jumpPower), duration / (float)(numJumps * 2)).SetOptions(AxisConstraint.Z, snapping).SetEase(Ease.OutQuad)
            .SetRelative()
            .SetLoops(numJumps * 2, LoopType.Yoyo)
            .OnStart(delegate
            {
                startPosZ = target.position.z;
            });
        s.Append(DOTween.To(() => target.position, delegate (Vector3 x)
        {
            target.position = x;
        }, new Vector3(endValue.x, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetEase(Ease.Linear)).Join(DOTween.To(() => target.position, delegate (Vector3 x)
        {
            target.position = x;
        }, new Vector3(0f, endValue.y, 0), duration).SetOptions(AxisConstraint.Y, snapping).SetEase(Ease.Linear)).Join(zTween)
            .SetTarget(target)
            .SetEase(DOTween.defaultEaseType);
        zTween.OnUpdate(delegate
        {
            if (!offsetZSet)
            {
                offsetZSet = true;
                offsetZ = (s.isRelative ? endValue.y : (endValue.y - startPosZ));
            }

            Vector3 position = target.position;
            position.z += DOVirtual.EasedValue(0f, offsetZ, zTween.ElapsedPercentage(), Ease.OutQuad);
            target.position = position;
        });
        return s;
    }

}
