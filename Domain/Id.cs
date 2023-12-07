namespace OnlineStore.Domain
{
    public static class Id
    {
        public static string generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
