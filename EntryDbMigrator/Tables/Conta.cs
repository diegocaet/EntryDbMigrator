using FluentMigrator;

namespace EntryDbMigrator.Tables
{
    [Migration(20230304121801)]
    public class Conta : Migration
    {
        public override void Down()
        {
            Delete.Table("Conta");
        }

        public override void Up()
        {
            Create.Table("Conta").WithDescription("Tabela criada para armazenar as contas")
                .WithColumn("Sequencia").AsInt32().PrimaryKey().WithColumnDescription("Chave primária da tabela Conta")
                .WithColumn("ContaPai").AsString().PrimaryKey().WithColumnDescription("Código de identificação da conta pai")
                .WithColumn("Nome").AsString(100).NotNullable().WithColumnDescription("Nome de exibição da conta")
                .WithColumn("Codigo").AsString(30).NotNullable().WithColumnDescription("Código da conta")
                .WithColumn("Tipo").AsInt32().NotNullable().WithColumnDescription("Tipo da conta. (Chave da tabela tipo)")
                .WithColumn("AceitaLancamento").AsBoolean().NotNullable().WithColumnDescription("Identifica se a conta aceita um lançamento");

            Create.Index("ix_Conta").OnTable("Conta").OnColumn("Sequencia").Ascending()
            .WithOptions().NonClustered();

            Create.ForeignKey("fk_Conta_TipoConta_Id")
                .FromTable("Conta").ForeignColumn("Tipo")
                .ToTable("TipoConta").PrimaryColumn("Id");

        }
    }
}
