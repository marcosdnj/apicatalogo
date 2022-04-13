﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutosReal : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            //ALTERAR NOME DA TABELA ESCRITO ERRADO
           



            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)"
                + "Values('Coca-cola Diet', 'Regrigernde de cola 350ml', 5.45, 'cocacola.jpg',50,now(),1)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)"
                + "Values('Lanche de Atum', 'Lanche de Atum com maionese', 8.5, 'atum.jpg',10,now(),2)");


            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)"
                + "Values('Pudim 100g', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg',20,now(),3)");


        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");



        }
    }
}
