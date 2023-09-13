using Pancake.Apex;
using Pancake.Scriptable;
using Pancake.Sound;
using UnityEngine;

namespace Pancake.Component
{
    public class VfxParticleCollision : GameComponent
    {
        [SerializeField] private ScriptableEventInt updateCoinWithValueEvent;
        [SerializeField] private ScriptableEventNoParam updateCoinEvent;
        [SerializeField] private ScriptableListGameObject vfxMagnetCollection;
        [field: SerializeField] public ParticleSystem PS { get; private set; }
        [SerializeField] private int numberParticle;
        [SerializeField] private bool ignoreFirstTimeDisabled = true;
        [SerializeField] private bool enabledSound;
        [SerializeField, ShowIf(nameof(enabledSound))] private Audio audioCollision;
        [SerializeField, ShowIf(nameof(enabledSound))] private ScriptableEventAudio audioPlayEvent;

        private int _targetValue;
        private int _segmentValue;
        private bool _ignoreFirstTime = true;

        public void Init(int value)
        {
            _targetValue = value;
            _segmentValue = value / numberParticle;
        }

        private void OnParticleCollision(GameObject particle)
        {
            updateCoinWithValueEvent.Raise(_segmentValue);
            if (enabledSound) audioPlayEvent.Raise(audioCollision);
        }

        protected override void OnDisabled()
        {
            base.OnDisabled();
            if (ignoreFirstTimeDisabled)
            {
                if (_ignoreFirstTime)
                {
                    _ignoreFirstTime = false;
                    return;
                }
            }

            if (vfxMagnetCollection.Count == 0) updateCoinEvent.Raise();
        }
    }
}