create database nota_fiscal_normalizada;

use nota_fiscal_normalizada;

create table nota_fiscal(
	nro_nota int not null identity primary key,
    nm_cliente varchar(256) not null,
    end_cliente varchar(256) not null,
    nm_vendedor varchar(256) not null,
    dt_emissao datetime default current_timestamp,
    vl_total float not null
);

create table produto(
	cod_produto int not null identity primary key,
    desc_produto varchar(256) not null,
    un_med char(2) not null,
    vl_produto float not null
);

create table item_nota_fiscal(
	nro_nota int not null,
    cod_produto int not null,
    qtd_produto int not null,
    vl_preco float not null,
    vl_total float not null,
    primary key (nro_nota, cod_produto),
    constraint fk_nro_nota_nota_fiscal
		foreign key(nro_nota)
        references nota_fiscal(nro_nota),
	constraint fk_cod_produto_produto
		foreign key(cod_produto)
        references produto(cod_produto)
);

insert into produto(desc_produto, un_med, vl_produto)
values('leite', 'lt', 4.50);
insert into produto(desc_produto, un_med, vl_produto)
values('cafe', 'kg', 32.00);
insert into produto(desc_produto, un_med, vl_produto)
values('maça', 'kg', 7.50);

insert into nota_fiscal(nm_cliente,end_cliente, nm_vendedor, vl_total)
values ('Aragorn', 'Terra Média', 'Bilbo', 100.00);
insert into nota_fiscal(nm_cliente,end_cliente, nm_vendedor, vl_total)
values ('Gandalf', 'Terra Média', 'Frodo', 100.00);

insert into nota_fiscal(nm_cliente,end_cliente, nm_vendedor, vl_total)
values ('Boromir', 'Mordor', 'Sam', 100.00);
insert into nota_fiscal(nm_cliente,end_cliente, nm_vendedor, vl_total)
values ('Galadriel', 'Valinor', 'Saruman', 100.00);

insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(1, 1, 1, 4.50, 4.50);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(1, 2, 2, 40.00, 80.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(1, 3, 10, 100.00, 1000.00);

insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(2, 1, 1, 9.00, 9.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(2, 2, 2, 80.00, 160.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(2, 3, 10, 200.00, 2000.00);

insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(3, 1, 1, 18.00, 18.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(3, 2, 2, 160.00, 320.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(3, 3, 10, 400.00, 4000.00);

insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(4, 1, 1, 32.00, 32.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(4, 2, 2, 420.00, 840.00);
insert into item_nota_fiscal(nro_nota,cod_produto, qtd_produto, vl_preco, vl_total)
values(4, 3, 10, 800.00, 8000.00);

select * from produto; 
select * from nota_fiscal;
select * from item_nota_fiscal;
select * from item_nota_fiscal where nro_nota=1;