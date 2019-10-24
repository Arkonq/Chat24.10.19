using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain
{
	public class Message : Entity
	{
		public string Value { get; set; }
		public virtual User User { get; set; }
	}
}
