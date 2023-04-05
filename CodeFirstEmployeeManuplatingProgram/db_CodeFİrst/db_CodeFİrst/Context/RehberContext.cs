using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_CodeFİrst.Context
{
    //Burası bizim asıl migrationnun ihtiyacı olan yer. bunlar genelde kalıplaşmış olan değerler ve standart kullanılıyor.
    internal class RehberContext : DbContext //dbContext den miras aldırmamız gerekiyor.
    {       
        public RehberContext() // boş ctor gerekiyor
        {

        }
        public RehberContext(DbContextOptions<RehberContext> option) : base(option) //bunlar kalıplaşmış olanlar
        {

        }
        public virtual DbSet<Rehber> Rehbers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-55D3033\\MSSQLSERVER01;Database=RehberDB;Trusted_Connection=True;TrustServerCertificate=True;");//Connection string bağlantısı burada
        }
    }
}
