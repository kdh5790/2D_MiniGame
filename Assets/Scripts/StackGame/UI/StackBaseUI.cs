using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StackBaseUI : MonoBehaviour
{
    protected StackUIManager uiManager;

    public virtual void Init(StackUIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        // state 매개변수에 따라 UI의 활성화 상태 변경 (현재 UI상태와 매개변수가 같다면 true 다르면 false)
        gameObject.SetActive(GetUIState() == state);
    }
}
