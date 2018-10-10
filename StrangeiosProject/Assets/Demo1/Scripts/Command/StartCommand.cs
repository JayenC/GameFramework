using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//开始命令
public class StartCommand : Command
{
    [Inject]
    public AudioManager audioManager { get; set; }

    /// <summary>
    /// 当这个命令被执行时，会默认调用Execute方法
    /// </summary>
    public override void Execute()
    {
        Debug.Log("start command");

        audioManager.Init();
        PoolManager.Instance.Init();
        LocalizationManager.Instance.Init();
    }

}
