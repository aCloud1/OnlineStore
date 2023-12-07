namespace OnlineStore.Errors
{
	public class InvalidInput : Exception {
		public InvalidInput(string message): base($"Invalid input - {message}") {}
	}

	public class InternalError : Exception
	{
		public InternalError(string message): base($"internal error - {message}") {}
	}

	public class InvalidCredentials : Exception
	{
		public InvalidCredentials(string message) : base($"invalid credentials - {message}") { }
	}

	public class DoesNotExist : Exception
	{
		public DoesNotExist(string message) : base($"does not exist - {message}") { }
	}
	
}
