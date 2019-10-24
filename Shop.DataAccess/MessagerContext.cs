using Microsoft.EntityFrameworkCore;
using Chat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.DataAccess
{
	public class MessagerContext : DbContext
	{
		public MessagerContext()
		{
			Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Message> Messages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=A-305-04;Database=Messager;Trusted_Connection=true;");
		}
	}
}
