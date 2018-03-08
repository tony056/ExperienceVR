using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItemSceneObject {

	[MenuItem("GameObject/Scene Object", false, 0)]
    private static void NewMenuOption()
    {
        initSceneObject();
    }

    private static void initSceneObject()
    {
        // init a new game object with photon transform view
        GameObject gameObject = new GameObject("PhotonGameObject");
        gameObject.transform.position = Vector3.zero;
        PhotonTransformView transformView = gameObject.AddComponent<PhotonTransformView>() as PhotonTransformView;

        if(transformView != null)
        {
            PhotonView view = gameObject.GetPhotonView() as PhotonView;
            if(view == null)
            {
                Debug.LogError("Please add photon view component to this game object manually.");
            }
            // set synchronization attributes
            transformView.m_PositionModel.SynchronizeEnabled = true;
            transformView.m_RotationModel.SynchronizeEnabled = true;
            transformView.m_ScaleModel.SynchronizeEnabled = true;

            // add transfer view to the observed list
            List<Component> tempComponents = view.ObservedComponents;
            if (tempComponents == null)
                tempComponents = new List<Component>();
            tempComponents.Add(transformView);

            // update observed option
            view.ObservedComponents = tempComponents;
            view.synchronization = ViewSynchronization.UnreliableOnChange;
        }
    }
}