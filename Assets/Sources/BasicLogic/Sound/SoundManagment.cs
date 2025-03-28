using System;
using Sources.Services.SaveLoadService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace Sources.BasicLogic.Sound
{
    public class SoundManagment : MonoBehaviour
    {
        private const string MixerVolume = "Volume";
        private const float VolumeBorder = -40;
        private const float MinVolume = -80;
        
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private AudioMixer _mixer;
        
        private SaveLoadService _saveLoadService;

        [Inject]
        private void Construct(SaveLoadService saveLoadService) =>
            _saveLoadService = saveLoadService;

        private void OnEnable() =>
            _soundSlider.onValueChanged.AddListener(OnSliderValueChanged);

        private void OnDisable() =>
            _soundSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        
        public void Setup(float volume)
        {
            _soundSlider.value = volume;
            _mixer.SetFloat(MixerVolume, volume);
        }

        private void OnSliderValueChanged(float value)
        {
            value = value <= VolumeBorder ? MinVolume : value;
            
            _mixer.SetFloat(MixerVolume, value);
            _saveLoadService.Save(new SoundData() { Volume =  value});
        }
    }
}