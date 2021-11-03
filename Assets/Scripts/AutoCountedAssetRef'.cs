//using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[System.Serializable]
public class AutoCountedAssetRef
{
    [SerializeField] private AssetReference _assetReference;

    private readonly Stack<AsyncOperationHandle> _handles = new Stack<AsyncOperationHandle>();

    public int RefCount => _handles.Count;

    public Task<T> LoadAsync<T>() where T : Object
    {
        return LoadAsyncInternal<T>().Task.ContinueWith(obj => (T)obj.Result);
    }

    public IEnumerator LoadAsyncCoroutine<T>() where T : Object
    {
        return LoadAsyncInternal<T>();
    }

    public void Release()
    {
        if (_handles.Count > 0)
        {
            var handle = _handles.Pop();
            Addressables.Release(handle);
        }
        else
        {
            Debug.LogWarning("Attempting to Release AutoCountedAssetRef, but the count is already at 0!");
        }
    }

    private AsyncOperationHandle LoadAsyncInternal<T>() where T : Object
    {
        var handle = Addressables.LoadAssetAsync<T>(_assetReference.RuntimeKey);
        _handles.Push(handle);
        return handle;
    }
}