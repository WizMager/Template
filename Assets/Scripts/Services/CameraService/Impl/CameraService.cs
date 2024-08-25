using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Utils;

namespace Services.CameraService.Impl
{
    public class CameraService : ICameraService
    {
        private const int ACTIVE_PRIORITY = 10;
        private const int INACTIVE_PRIORITY = 0;
        
        private readonly IReadOnlyDictionary<ECameraType, CinemachineVirtualCamera> _cameras;

        public CameraService(IReadOnlyDictionary<ECameraType, CinemachineVirtualCamera> cameras)
        {
            _cameras = cameras;
        }

        public void SetActiveCamera(ECameraType cameraType)
        {
            foreach (var camera in _cameras)
            {
                camera.Value.Priority = camera.Key == cameraType ? ACTIVE_PRIORITY : INACTIVE_PRIORITY;
            }
        }

        public void SetFollowToCamera(Transform target, ECameraType cameraType)
        {
            foreach (var camera in _cameras)
            {
                if (camera.Key != cameraType)
                    continue;

                camera.Value.Follow = target;
                break;
            }
        }

        public void SetLookAtToCamera(Transform target, ECameraType cameraType)
        {
            foreach (var camera in _cameras)
            {
                if (camera.Key != cameraType)
                    continue;

                camera.Value.LookAt = target;
                break;
            }
        }

        public void SetLookAtToAllCameras(Transform target)
        {
            foreach (var camera in _cameras)
            {
                camera.Value.LookAt = target;
            }
        }

        public void SetFollowToAllCameras(Transform target)
        {
            foreach (var camera in _cameras)
            {
                camera.Value.Follow = target;
            }
        }
    }
}