using System;

namespace Checkers
{
    public interface IRecorder
    {
            public event Action<ChipComponent> ChipDestroyed;


            public event Action<String> Step;

            public event Action<ColorType> GameEnded;

    }
}
