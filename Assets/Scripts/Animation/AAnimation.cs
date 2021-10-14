using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAnimation
{
    protected Animator animator;

    public void SetAnimator(Animator _animator)
    {
        animator = _animator;
    }

    /// <summary>
    /// ��ǰ״̬������״̬
    /// </summary>
    /// <param name="currAnimation"></param>
    /// <param name="eAnimation"></param>
    public void SetAnimation(EAnimation currAnimation,EAnimation eAnimation)
    {
        FuncAnimation(currAnimation,eAnimation);
    }

    protected abstract void FuncAnimation(EAnimation currAnimation, EAnimation eAnimation);

}
