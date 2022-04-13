using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    public void Excute();

}
public abstract class AbstractCommand :MonoBehaviour, ICommand
{
    public void Excute()
    {
        OnExcute();
    }
    protected abstract void OnExcute();
}
