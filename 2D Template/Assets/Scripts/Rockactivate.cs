using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockactivate : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    [ContextMenu(itemName:"Fall")]
    public void Fall()
    {
        _animator.SetTrigger(name: "Fall");
    }

}
