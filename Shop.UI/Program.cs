using Chat.DataAccess;
using Chat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.UI
{
	class Program
	{
		private static List<Message> result; 

		static void Main()
		{			
			Console.WriteLine("Добро пожаловать в анонимный чат 'Введи ТОЛЬКО Логин и Общайся!'");
			Console.WriteLine("Перед отправкой сообщения рекомендуется обновлять чат командой '/r'");
			Console.Write("Введите имя пользователя: ");

			User user = new User
			{
				Login = Console.ReadLine()
			};

			Console.WriteLine();

			string text;
			using (var context = new MessagerContext())
			{
				while (true)
				{					
					Console.Clear();
					result = context.Messages.OrderBy(x => x.CreationDate).TakeLast(100).ToList();
					
					foreach(var oneMessage in result)
					{
						Console.WriteLine($"({oneMessage.CreationDate}) {oneMessage.User.Login}: {oneMessage.Value}");
					}

					text = Console.ReadLine();

					if(text == "/r")
					{
						continue;
					}

					Message message = new Message
					{
						Value = text,
						User = user
					};
					context.Add(message);
					context.SaveChanges();
				}
			}
		}
	}
}