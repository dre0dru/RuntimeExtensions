namespace Dre0Dru.Tokens
{
    public static class TokensExtensions
    {
        public static bool GetValueAndResetIfChanged(this PollingToken<bool> pollingToken)
        {
            var value = pollingToken.Value;

            if (pollingToken.ValueChanged)
            {
                pollingToken.Reset();
            }

            return value;
        }
    }
}
