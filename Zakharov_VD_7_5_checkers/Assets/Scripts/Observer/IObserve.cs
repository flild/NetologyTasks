using System;
using System.Threading.Tasks;

namespace Checkers
{
    public interface IObserve
    {
        public Task Record(string input);

        public event Action<Coordinate> RepeatStep;

    }
}
