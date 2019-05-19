using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class BolsaContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public BolsaContext() : base("name=BolsaContext")
    {
    }

    public System.Data.Entity.DbSet<Bolsa.Models.Info> Infoes { get; set; }

    public System.Data.Entity.DbSet<Bolsa.Models.Compra> Compras { get; set; }

    public System.Data.Entity.DbSet<Bolsa.Models.Venda> Vendas { get; set; }

    public System.Data.Entity.DbSet<Bolsa.Models.Ação> Acao { get; set; }

}
