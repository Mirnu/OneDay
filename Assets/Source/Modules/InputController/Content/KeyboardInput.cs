using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyboardInput : ITickable, IInputHandler
{
    public Action<KeyCode> KeyUp { get; set; }
    public Action<KeyCode> KeyDown { get; set; }
    public Action<KeyCode> KeyPressed { get; set; }
    public Action<float> HorizontalAxis { get; set; }
    public Action<float> VerticalAxis { get; set; }

    private List<KeyCode> AllowedKeys = new List<KeyCode> 
    { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.E, KeyCode.Escape, KeyCode.KeypadEnter };
    private const string Horizontal = "Horizontal", Vertical = "Vertical";

    public void Tick()
    {
        foreach (KeyCode key in AllowedKeys)
        {
            if (Input.GetKeyUp(key)) OnKeyUp(key);
            if (Input.GetKeyDown(key)) OnKeyDown(key);
            if (Input.GetKey(key)) OnKeyPressed(key);
        }
        OnHorizontalAxis(Input.GetAxis(Horizontal));
        OnVerticalAxis(Input.GetAxis(Vertical));
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
    private void OnHorizontalAxis(float delta)
    {
        HorizontalAxis?.Invoke(delta);
    }

    private void OnVerticalAxis(float delta)
    {
        VerticalAxis?.Invoke(delta);
    }
}
