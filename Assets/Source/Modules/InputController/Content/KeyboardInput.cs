using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyboardInput : ITickable, IInputHandler
{
    public Action<KeyCode> KeyUp { get; set; }
    public Action<KeyCode> KeyDown { get; set; }
    public Action<KeyCode> KeyPressed { get; set; }
    public Action<string> HorizontalAxis { get; set; }
    public Action<string> VerticalAxis { get; set; }

    private List<KeyCode> AllowedKeys = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private List<string> AllowedAxes = new List<string> { "Horizontal", "Vertical" };

    public void Tick()
    {
        foreach (KeyCode key in AllowedKeys)
        {
            OnKeyUp(key);
            OnKeyDown(key);
            OnKeyPressed(key);
        }
        foreach (string axis in AllowedAxes)
        {
            OnHorizontalAxis(axis);
            OnVerticalAxis(axis);
        }
    }

    private void OnKeyUp(KeyCode key)
    {
        KeyUp?.Invoke(key);
    }

    private void OnKeyDown(KeyCode key)
    {
        KeyDown?.Invoke(key);
    }
    private void OnKeyPressed(KeyCode key)
    {
        KeyPressed?.Invoke(key);
    }
    private void OnHorizontalAxis(string axis)
    {
        HorizontalAxis?.Invoke(axis);
    }

    private void OnVerticalAxis(string axis)
    {
        VerticalAxis?.Invoke(axis);
    }
}
