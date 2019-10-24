using System.Collections.Generic;

namespace Chat.Domain
{
	public class User : Entity
	{
		public string Login { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
	}
}
