using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private void Update()
    {
        if (Berserk._isBerserk)
        {
            CinemachineVirtualCamera cvc = GetComponent<CinemachineVirtualCamera>();
            CinemachineBasicMultiChannelPerlin cbmcp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cbmcp.m_AmplitudeGain = 2f;
            cbmcp.m_FrequencyGain = 2f;
        }
        else
        {
            CinemachineVirtualCamera cvc = GetComponent<CinemachineVirtualCamera>();
            CinemachineBasicMultiChannelPerlin cbmcp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cbmcp.m_AmplitudeGain = 0f;
            cbmcp.m_FrequencyGain = 0f;
        }
    }
}