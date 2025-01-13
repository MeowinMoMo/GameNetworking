using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[System.Serializable]
public class AssetReferecnceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferecnceAudioClip(string guid) : base(guid)
    {
    }
}
public class AddressableAssets : MonoBehaviour
{
    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetReferecnceAudioClip clip;

    GameObject addressableContainer;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        AsyncOperationHandle<GameObject> asyncOperationHandle = 
    //            Addressables.LoadAssetAsync<GameObject>("Assets/Cube.prefab");

    //        asyncOperationHandle.Completed += AsyncOperationHandleComplete;
    //    }
    //}

    //private void AsyncOperationHandleComplete(AsyncOperationHandle<GameObject> asyncOperationHandle)
    //{
    //    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        Instantiate(asyncOperationHandle.Result);
    //    }
    //    else
    //    {
    //        Debug.LogError("Failed to Load");
    //    }
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            assetReference.LoadAssetAsync<GameObject>().Completed += (AsyncOperationHandleComplete) =>
            {
                if (AsyncOperationHandleComplete.Status == AsyncOperationStatus.Succeeded)
                {
                    addressableContainer = Instantiate(AsyncOperationHandleComplete.Result);
                }
                else
                {
                    Debug.LogError("Failed to Load");
                }
            };
            //clip.LoadAssetAsync<GameObject>().Completed += (AsyncOperationHandleComplete) =>
            //{
            //    if (AsyncOperationHandleComplete.Status == AsyncOperationStatus.Succeeded)
            //    {
            //        addressableContainer = Instantiate(AsyncOperationHandleComplete.Result);
            //    }
            //    else
            //    {
            //        Debug.LogError("Failed to Load");
            //    }
            //};
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            assetReference.ReleaseInstance(addressableContainer);
            Destroy(addressableContainer);
        }
    }
}
