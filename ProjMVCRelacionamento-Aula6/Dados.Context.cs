﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjMVCRelacionamento_Aula6
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PessoaTelefoneEntities : DbContext
    {
        public PessoaTelefoneEntities()
            : base("name=PessoaTelefoneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_PESSOA> TB_PESSOA { get; set; }
        public virtual DbSet<TB_TELEFONE> TB_TELEFONE { get; set; }
    }
}