﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uchebnaya.Components
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class shamaev322_uchebnayaEntities : DbContext
    {
        public shamaev322_uchebnayaEntities()
            : base("name=shamaev322_uchebnayaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<disciplina> disciplina { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<engineer> engineer { get; set; }
        public virtual DbSet<exam> exam { get; set; }
        public virtual DbSet<ExamStudent> ExamStudent { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Kafedra> Kafedra { get; set; }
        public virtual DbSet<prepod> prepod { get; set; }
        public virtual DbSet<specialization> specialization { get; set; }
        public virtual DbSet<student> student { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<zav_kafedri> zav_kafedri { get; set; }
        public virtual DbSet<zayavka> zayavka { get; set; }
    }
}
