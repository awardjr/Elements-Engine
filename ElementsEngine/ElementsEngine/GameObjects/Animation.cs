using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsEngine.AssetInfo;
using SFML.Graphics;

namespace ElementsEngine.GameObjects
{
    public class Animation
    {
        private List<SpriteInfo> _sprites;
        public float FrameTime { get; set; }
        public bool Loop { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; private set; }
        public bool IsPlaying { get; private set; }
        private TimeSpan _previousTimeSpan;
        

        public EventHandler<EventArgs> AnimationFinished;


        public Animation(List<SpriteInfo> sprites, float frameTime = 1, bool loop = false)
        {
            _sprites = sprites;
            FrameTime = frameTime;
            Loop = loop;
            TotalFrames = _sprites.Count;
        }

        /// <summary>
        /// Gets the rectangle associated with current frame.
        /// </summary>
        /// <returns>Rectangle</returns>
        public IntRect GetCurrentFrameRect()
        {
            return _sprites[CurrentFrame].Rectangle;
        }

        /// <summary>
        /// Starts animation playback
        /// </summary>
        public void Play()
        {
            IsPlaying = true;
        }
        /// <summary>
        /// Ends  animation playback
        /// </summary>
        public void Stop()
        {
            IsPlaying = false;
        }

        /// <summary>
        /// Periodic updates
        /// </summary>
        /// <param name="gTimeSpan"></param>
        public void Update(TimeSpan gTimeSpan)
        {
            if (!IsPlaying)
            {
                return;
            }

            if (gTimeSpan.Ticks >= _previousTimeSpan.Ticks + FrameTime)
            {
                var difference = Math.Abs(gTimeSpan.Ticks - _previousTimeSpan.Ticks);
                var framesToAdvance = Math.Round(difference/FrameTime);
                CurrentFrame += (int)framesToAdvance;
            }

            if (CurrentFrame > TotalFrames && Loop)
            {
                CurrentFrame = CurrentFrame - TotalFrames;
            }
            else
            {
                CurrentFrame = TotalFrames;
            }

            if (CurrentFrame == TotalFrames && IsPlaying)
            {
                IsPlaying = false;
                AnimationFinished.Invoke(this, null);
            }
        }
    }
}
