namespace UserProject.Core.AppException
{
    [Serializable]
    internal class MisMacthUserAndProfileIDExeption : Exception
    {
        public MisMacthUserAndProfileIDExeption()
        {
        }

        public MisMacthUserAndProfileIDExeption(string? message) : base(message)
        {
        }

        public MisMacthUserAndProfileIDExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}