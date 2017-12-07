using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLike.Models
{
    public class Message
    {
        public int MessageId { set; get; }
        public string Text { set; get; }
        public string Sign { set; get; }
    }
  
    public class ChatContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
     
        public ChatContext(DbContextOptions<ChatContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем строку соединения
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            string conStr = configuration["ConnectionStrings:DefaultConnection"];

            // добавляем SqlServer в опции  
            optionsBuilder.UseSqlServer(conStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
 
}
