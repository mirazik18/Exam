namespace Exam
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GoodContext : DbContext
    {
        
        public GoodContext()
            : base("name=GoodContext")
        {
           
        }
        public DbSet<Good> Goods { get; set; }



    }

   
}