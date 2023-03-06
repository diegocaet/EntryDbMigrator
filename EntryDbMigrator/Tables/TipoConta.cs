using FluentMigrator;

namespace EntryDbMigrator.Tables
{
    [Migration(20230304121800)]
    public class TipoConta : Migration
    {
        public override void Down()
        {
            Delete.Table("TipoConta");
        }

        public override void Up()
        {
            Create.Table("TipoConta").WithDescription("Tabela criada para armazenar os tipos de conta")
                .WithColumn("Id").AsInt32().PrimaryKey().WithColumnDescription("Chave primária da tabela TipoConta")
                .WithColumn("Nome").AsString(50).NotNullable().WithColumnDescription("Nome de exibição do tipo de conta");

            Create.Index("ix_TipoConta").OnTable("TipoConta").OnColumn("Id").Ascending()
            .WithOptions().NonClustered();

            Insert.IntoTable("TipoConta").Row(new { Id = 1, Nome = "Receita" });
            Insert.IntoTable("TipoConta").Row(new { Id = 2, Nome = "Despesa" });
        }
    }
}
