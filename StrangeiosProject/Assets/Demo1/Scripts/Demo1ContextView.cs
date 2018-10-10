using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1ContextView : ContextView
{
    private void Awake()
    {
        this.context = new Demo1Context(this);  //启动StrangeIoc框架


        //context.Start();  
    }
}
