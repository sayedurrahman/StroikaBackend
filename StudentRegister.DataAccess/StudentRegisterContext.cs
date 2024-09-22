using Microsoft.EntityFrameworkCore;
using StudentRegister.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess
{
    public class StudentRegisterContext : DbContext
    {
        public StudentRegisterContext(DbContextOptions<StudentRegisterContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FamilyMember>().HasOne(x => x.Student).WithMany(x => x.FamilyMembers).HasForeignKey(x => x.StudentID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
