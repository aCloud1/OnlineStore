namespace OnlineStore.Services
{
	public class Person : IFormattable
	{
		public string first_name;
		public string second_name;
		public string home_address;
		public string phone_number;

		public Person() { }

		public Person(string first_name, string second_name, string home_address, string phone_number)
		{
			this.first_name = first_name;
			this.second_name = second_name;
			this.home_address = home_address;
			this.phone_number = phone_number;
		}

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			string buffer = "";
			if (format != null)
			{
				switch (format.ToLower())
				{
					case "text":
						buffer = $"{first_name} {second_name} lives at {home_address} and is reachable by calling {phone_number}";
						break;

					case "json":
						buffer += "{\n";
						buffer += $"  \"first_name\": \"{first_name}\",\n";
						buffer += $"  \"second_name\": \"{second_name}\",\n";
						buffer += $"  \"home_address\": \"{home_address}\",\n";
						buffer += $"  \"phone_number\": \"{phone_number}\"\n";
						buffer += "}";
						break;

					default:
						break;
				}
			}
			return buffer;
		}
	}
}
