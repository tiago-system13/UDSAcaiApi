
 CREATE TABLE UDSAcaiApi.Sabor(
  id integer IDENTITY not null,
  descricao varchar(30) not null
 );

ALTER TABLE UDSAcaiApi.Sabor
   ADD CONSTRAINT PK_Sabor_ID PRIMARY KEY CLUSTERED (id);


 CREATE TABLE UDSAcaiApi.Tamanho(
  id integer IDENTITY not null,
  descricao varchar(20) not null
 );

ALTER TABLE UDSAcaiApi.Tamanho
   ADD CONSTRAINT PK_Tamanho_ID PRIMARY KEY CLUSTERED (id);


CREATE TABLE UDSAcaiApi.Preparacao(
  id integer IDENTITY not null,
  saborId int not null,
  tamanhoId int not null,
  valor decimal(12,2) not null,
  duracao time not null
 );

ALTER TABLE UDSAcaiApi.Preparacao
   ADD CONSTRAINT PK_Preparacao_ID PRIMARY KEY CLUSTERED (id);

ALTER TABLE UDSAcaiApi.Preparacao
   ADD CONSTRAINT FK_Preparacao_Sabor_ID Foreign KEY (saborId)
   References UDSAcaiApi.Sabor(id);

ALTER TABLE UDSAcaiApi.Preparacao
   ADD CONSTRAINT FK_Preparacao_Tamanho_ID Foreign KEY (tamanhoId)
   References UDSAcaiApi.Tamanho(id);


CREATE TABLE UDSAcaiApi.Pedido(
  id integer IDENTITY not null,
  preparacaoId int not null,
  total decimal(12,2) not null,
  data datetime not null
 );

ALTER TABLE UDSAcaiApi.Pedido
   ADD CONSTRAINT PK_Pedido_ID PRIMARY KEY CLUSTERED (id);

ALTER TABLE UDSAcaiApi.Pedido
   ADD CONSTRAINT FK_Pedido_Preparacao_ID Foreign KEY (preparacaoId)
   References UDSAcaiApi.Preparacao(id);


CREATE TABLE UDSAcaiApi.Adicionais(
  id integer IDENTITY not null,
  descricao varchar(40) not null,
  valor decimal(12,2)  not null,
  duracao time  not null
 );
 ALTER TABLE UDSAcaiApi.Adicionais
   ADD CONSTRAINT PK_Adicionais_ID PRIMARY KEY CLUSTERED (id);

 CREATE TABLE UDSAcaiApi.ItensAdicionais(
  id integer IDENTITY not null,
  pedidoId int not null,
  adicionaisId int not null,
  CONSTRAINT UC_Person UNIQUE (pedidoId,adicionaisId)
 );

ALTER TABLE UDSAcaiApi.ItensAdicionais
   ADD CONSTRAINT PK_ItensAdicionais_ID PRIMARY KEY CLUSTERED (id);

ALTER TABLE UDSAcaiApi.ItensAdicionais
   ADD CONSTRAINT FK_ItensAdicionais_Pedido_ID Foreign KEY (pedidoId)
   References UDSAcaiApi.Pedido(id);

ALTER TABLE UDSAcaiApi.ItensAdicionais
   ADD CONSTRAINT FK_ItensAdicionais_Adicionais_ID Foreign KEY (adicionaisId)
   References UDSAcaiApi.Adicionais(id);


  -- Inicialização de valores das tabelas 

   insert into UDSAcaiApi.Sabor values('Morango');
   insert into UDSAcaiApi.Sabor values('Banana');
   insert into UDSAcaiApi.Sabor values('Kiwi');


   insert into UDSAcaiApi.Tamanho values('Pequeno (300 ml)');
   insert into UDSAcaiApi.Tamanho values('Médio (500 ml)');
   insert into UDSAcaiApi.Tamanho values('Grande (700 ml)');

   -- Sabor Morango Preparação
   insert into UDSAcaiApi.Preparacao values(1,1,10.00,'00:05:00');
   insert into UDSAcaiApi.Preparacao values(1,2,13.00,'00:07:00');
   insert into UDSAcaiApi.Preparacao values(1,3,15.00,'00:10:00');


   -- Sabor Banana Preparação
   insert into UDSAcaiApi.Preparacao values(2,1,10.00,'00:05:00');
   insert into UDSAcaiApi.Preparacao values(2,2,13.00,'00:07:00');
   insert into UDSAcaiApi.Preparacao values(2,3,15.00,'00:10:00');

   -- Sabor Kiwi Preparação
   insert into UDSAcaiApi.Preparacao values(3,1,10.00,'00:10:00');
   insert into UDSAcaiApi.Preparacao values(3,2,13.00,'00:12:00');
   insert into UDSAcaiApi.Preparacao values(3,3,15.00,'00:15:00');

   -- Adiconais

   insert into UDSAcaiApi.Adicionais values('Leite Ninho',3,'00:00:00');
   
   insert into UDSAcaiApi.Adicionais values('Granola',0,'00:00:00');

   insert into UDSAcaiApi.Adicionais values('Paçoca',3,'00:03:00');


