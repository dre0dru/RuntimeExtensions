namespace Dre0Dru.Buildables
{
    public readonly struct Buildable<T>
    {
        private readonly T _buildable;

        public Buildable(T buildable)
        {
            _buildable = buildable;
        }

        public static implicit operator T(Buildable<T> builder)
        {
            return builder._buildable;
        }

        public static implicit operator Buildable<T>(T buildable)
        {
            return new Buildable<T>(buildable);
        }
    }
    
    public readonly struct Buildable<TPrevious, T>
    {
        private readonly TPrevious _previous;
        private readonly T _buildable;

        public Buildable(TPrevious previous, T buildable)
        {
            _previous = previous;
            _buildable = buildable;
        }

        public TPrevious Build()
        {
            return _previous;
        }

        public static implicit operator T(Buildable<TPrevious, T> builder)
        {
            return builder._buildable;
        }
    }
}
