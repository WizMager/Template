using UnityEngine;
using Utils;

namespace Services.CameraService
{
    public interface ICameraService
    {
        void SetActiveCamera(ECameraType cameraType);
        void SetFollowToCamera(Transform target, ECameraType cameraType);
        void SetLookAtToCamera(Transform target, ECameraType cameraType);
        void SetLookAtToAllCameras(Transform target);
        void SetFollowToAllCameras(Transform target);
    }
}