using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class DataLoading : MonoBehaviour
{
    public static void LoadMaterialData(GameObject sticker, AssetReferenceT<Material> stickerRef, Func<int> function)
    {
        if (stickerRef.OperationHandle.IsValid())
        {
            if (!stickerRef.OperationHandle.IsDone)
            {
                stickerRef.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        sticker.GetComponent<Renderer>().material = obj.Convert<Material>().Result;
                        if (function != null)
                        {
                            function();
                        }
                    }
                };
            }
            else
            {
                sticker.GetComponent<Renderer>().material = stickerRef.OperationHandle.Convert<Material>().Result;
                if (function != null)
                {
                    function();
                }
            }
        }
        else
        {
            stickerRef.LoadAssetAsync<Material>().Completed += (AsyncOperationHandle<Material> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    sticker.GetComponent<Renderer>().material = obj.Result;
                    if (function != null)
                    {
                        function();
                    }
                }
            };
        }
    }

    public static void GetSpriteFromRef(AssetReferenceSprite stickerRef, Image image)
    {
        // If asset has already started being loaded into memory.
        if (stickerRef.OperationHandle.IsValid())
        {
            // if loading is not already completed.
            if (!stickerRef.OperationHandle.IsDone)
            {
                stickerRef.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        image.sprite = obj.Convert<Sprite>().Result;
                    }
                };
            }
            // if loading is completed.
            else
            {
                image.sprite = stickerRef.OperationHandle.Convert<Sprite>().Result;
            }
        }
        else
        {
            // if loading hasn't started.
            stickerRef.LoadAssetAsync<Sprite>().Completed += (AsyncOperationHandle<Sprite> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    image.sprite = obj.Result;
                }
            };
        }
    }

    public static void LoadTexData(GameObject origami, int childIndex, AssetReferenceTexture texReference, string ID)
    {
        if (texReference.OperationHandle.IsValid())
        {
            if (!texReference.OperationHandle.IsDone)
            {
                texReference.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        origami.transform.GetChild(childIndex).GetComponent<Renderer>().material.SetTexture(ID, obj.Convert<Texture>().Result);
                    }
                };
            }
            else
            {
                origami.transform.GetChild(childIndex).GetComponent<Renderer>().material.SetTexture(ID, texReference.OperationHandle.Convert<Texture>().Result);
            }
        }
        else
        {
            texReference.LoadAssetAsync<Texture>().Completed += (AsyncOperationHandle<Texture> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    origami.transform.GetChild(childIndex).GetComponent<Renderer>().material.SetTexture(ID, obj.Result);
                }
            };
        }
    }

    public static Texture GetTextureFromMaterial(AssetReferenceT<Material> stickerRef)
    {
        Texture temp = null;
        if (stickerRef.OperationHandle.IsValid())
        {
            if (!stickerRef.OperationHandle.IsDone)
            {
                stickerRef.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        temp = obj.Convert<Material>().Result.mainTexture;
                    }
                };
            }
            else
            {
                temp = stickerRef.OperationHandle.Convert<Material>().Result.mainTexture;
            }
        }
        else
        {
            stickerRef.LoadAssetAsync<Material>().Completed += (AsyncOperationHandle<Material> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    temp = obj.Result.mainTexture;
                }
            };
        }
        return temp;
    }
}
