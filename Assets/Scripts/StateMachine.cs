﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    public T state { get; private set; }
    public T prevState { get; private set; }
    public int framesSinceStateChange { get; private set; }
    public float timeSinceStateChange { get; private set; }

    public StateMachine(T initialState)
    {
        state = initialState;
        framesSinceStateChange = 0;
        timeSinceStateChange = 0.00f;
    }

    public void Update()
    {
        framesSinceStateChange = framesSinceStateChange + 1;
    }

    public void FixedUpdate()
    {
        timeSinceStateChange = timeSinceStateChange + Time.deltaTime;
    }

    public void SetState(T state)
    {
        prevState = this.state;
        this.state = state;
        framesSinceStateChange = 0;
        timeSinceStateChange = 0.00f;
    }
}
