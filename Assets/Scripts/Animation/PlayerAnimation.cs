using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : AAnimation
{
    protected override void FuncAnimation(EAnimation currAnimation, EAnimation eAnimation)
    {
        switch (eAnimation)
        {
            case EAnimation.STOP:
                {
                    switch (eAnimation)
                    {
                        case EAnimation.STOP:
                            {
                                break;
                            }
                        case EAnimation.MOVE:
                            {
                                animator.SetBool("isStop", false);
                                animator.SetBool("isMove", true);
                                break;
                            }
                        case EAnimation.DIG:
                            {
                                animator.SetBool("isStop", false);
                                animator.SetBool("isDig", true);
                                break;
                            }
                    }
                    break;
                }
            case EAnimation.MOVE:
                {
                    switch (eAnimation)
                    {
                        case EAnimation.STOP:
                            {
                                animator.SetBool("isStop", true);
                                animator.SetBool("isMove", false);
                                animator.SetBool("isDig", false);
                                break;
                            }
                        case EAnimation.MOVE:
                            {
                                break;
                            }
                        case EAnimation.DIG:
                            {
                                animator.SetBool("isDig", true);
                                animator.SetBool("isMove", false);
                                break;
                            }
                    }
                    break;
                }
            case EAnimation.DIG:
                {
                    switch (eAnimation)
                    {
                        case EAnimation.STOP:
                            {
                                animator.SetBool("isStop", true);
                                animator.SetBool("isMove", false);
                                animator.SetBool("isDig", false);
                                break;
                            }
                        case EAnimation.MOVE:
                            {
                                animator.SetBool("isMove", true);
                                animator.SetBool("isDig", false);
                                break;
                            }
                        case EAnimation.DIG:
                            {
                                break;
                            }
                    }
                    break;
                }
        }
    }
}
