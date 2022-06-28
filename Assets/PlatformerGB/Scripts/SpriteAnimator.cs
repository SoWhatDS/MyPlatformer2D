using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer2D
{
    public class SpriteAnimator : IDisposable
    {
        private SpriteAnimationConfig _config;
        private Dictionary<SpriteRenderer, CustomAnimation> _activeAnimations = new Dictionary<SpriteRenderer, CustomAnimation>();

        private bool _isPlayingAnimation;

        public SpriteAnimator(SpriteAnimationConfig config)
        {
            _config = config;
        }

        internal void StartAnimation(SpriteRenderer spriteRenderer, Track track, bool loop, float speed)
        {
            if (_isPlayingAnimation)
                return;

            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.SpeedAnimation = speed;
                animation.Sleep = false;

                if (animation.Track == track)
                    return;     
                
                animation.Track = track;
                animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                animation.Counter = 0;                             
            }
            else
            {
                
                var customAnimation = new CustomAnimation
                {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    SpeedAnimation = speed
                };
                customAnimation.OnStopAnimation += EndAnimation;

                _isPlayingAnimation = true;

                _activeAnimations.Add(spriteRenderer, customAnimation);
                
            }
        }

        private void EndAnimation()
        {
            _isPlayingAnimation = false;
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
                _activeAnimations.Remove(sprite);
        }

        public void Update()
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update();
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }

        public void Dispose()
        {
            _activeAnimations.Clear();
        }
    }
}