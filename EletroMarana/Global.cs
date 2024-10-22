﻿using System;
using System.Data;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    class Global
    {
        // criando variáveis para conexão e manipulação de dados
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        public static MySqlDataAdapter Adaptador;
        public static DataTable datTabela;

        public static Tuple<int, int> usuarioLogado;

        public static void CriaBanco() {
            // define string de conexão
            string stringConexao = "server=localhost; uid=root; pwd=1234; charset=utf8;";
            Conexao = new MySqlConnection(stringConexao);

            // abre a conexão
            Conexao.Open();

            // cria o banco de dados e o seleciona para uso
            ExecutaComandoSimples("create database if not exists bd_eletromarana");
            ExecutaComandoSimples("use bd_eletromarana");

            // cria as tabelas
            CriaTabelas();

            // cria os triggers 
            CriaTriggers();

            // cria usuario admin
            CriaUsuarioPadrao();

            // fecha a conexão
            Conexao.Close();

            // redefine a string de conexão
            stringConexao = "server=localhost; database=bd_eletromarana; uid=root; pwd=1234; charset=utf8;";
            Conexao = new MySqlConnection(stringConexao);
        }

        private static void ExecutaComandoSimples(string construcao)
        {
            Comando = new MySqlCommand(construcao, Conexao);
            Comando.ExecuteNonQuery();
        }

        private static void CriaTabelas()
        {
            // cria tabela de estados
            ExecutaComandoSimples(@"create table if not exists Estados
                                  (id integer not null auto_increment primary key,
                                  nome char(2) not null unique)");

            // cria tabela de cidades
            ExecutaComandoSimples(@"create table if not exists Cidades
                                  (id integer not null auto_increment primary key,
                                  nome char(40) not null,
                                  id_estado integer not null,
                                  unique (nome, id_estado),
                                  foreign key (id_estado) references Estados(id) on delete cascade)");

            // cria tabela de categorias
            ExecutaComandoSimples(@"create table if not exists Categorias
                                  (id integer not null auto_increment primary key,
                                  descricao char(40) not null unique)");

            // cria tabela de usuario
            ExecutaComandoSimples(@"create table if not exists Usuarios
                                  (id integer not null auto_increment primary key,
                                  nome varchar(100) not null,
                                  login char(40) not null unique,
                                  senha char(10) not null,
                                  adm boolean not null)");

            // cria tabela de fornecedores
            ExecutaComandoSimples(@"create table if not exists Fornecedores
                                  (id integer not null auto_increment primary key,
                                  razao_social varchar(100) not null,
                                  fantasia char(40) not null,
                                  cep char(9) not null,
                                  rua varchar(100) not null,
                                  numero integer not null,
                                  complemento varchar(100),
                                  bairro char(30) not null,
                                  id_cidade integer not null,
                                  cnpj char(18) not null unique,
                                  ie char(15) not null,
                                  fone char(14) not null,
                                  celular char(15),
                                  representante varchar(80) not null,
                                  email varchar(100) not null,
                                  foreign key (id_cidade) references Cidades(id) on delete cascade)");

            // cria tabela de clientes
            ExecutaComandoSimples(@"create table if not exists Clientes
                                  (id integer not null auto_increment primary key,
                                  nome varchar(100) not null,
                                  cep char(9) not null,
                                  rua varchar(100) not null,
                                  numero integer not null,
                                  complemento varchar(100),
                                  bairro char(30) not null,
                                  id_cidade integer not null,
                                  cpf char(14) not null unique,
                                  rg char(12) not null,
                                  fone char(14),
                                  celular char(15) not null,
                                  email varchar(100) not null,
                                  renda decimal(10,2),
                                  data_nasc date not null,
                                  foto varchar(100),
                                  foreign key (id_cidade) references Cidades(id) on delete cascade)");

            // cria tabela de tipos de pagamento
            ExecutaComandoSimples(@"create table if not exists Tipos_PGTO
                                  (id integer not null auto_increment primary key,
                                  descricao char(40) not null unique,
                                  baixa_aut boolean not null)");

            // cria tabela de produtos
            ExecutaComandoSimples(@"create table if not exists Produtos
                                  (id integer not null auto_increment primary key,
                                  descricao varchar(200) not null,
                                  codigo_barra char(14) not null unique,
                                  id_categoria integer not null,
                                  id_fornecedor integer not null,
                                  prazo_garantia integer not null,
                                  estoque integer not null,
                                  estoque_minimo integer not null,
                                  valor_venda decimal(10,2) not null,
                                  valor_custo decimal(10,2) not null,
                                  foto varchar(100),
                                  fora_linha boolean not null,
                                  foreign key (id_categoria) references Categorias(id) on delete cascade,
                                  foreign key (id_fornecedor) references Fornecedores(id) on delete cascade)");

            // cria tabela de vendas (cabeçalho)
            ExecutaComandoSimples(@"create table if not exists Venda_CAB
                                  (id integer not null auto_increment primary key,
                                  id_usuario integer not null,
                                  id_cliente integer not null,
                                  data_hora datetime not null,
                                  total decimal(15, 2) not null,
                                  id_tipo_pgto integer not null,
                                  foreign key (id_usuario) references Usuarios(id) on delete cascade,
                                  foreign key (id_cliente) references Clientes(id) on delete cascade,
                                  foreign key (id_tipo_pgto) references Tipos_PGTO(id) on delete cascade)");

            // cria tabela de vendas (detalhe)
            ExecutaComandoSimples(@"create table if not exists Venda_DET
                                  (id integer not null auto_increment primary key,
                                  id_venda integer not null,
                                  id_produto integer not null,
                                  qtd integer not null, 
                                  vlr_unitario decimal(10, 2) not null,
                                  foreign key (id_venda) references Venda_CAB(id) on delete cascade,
                                  foreign key (id_produto) references Produtos(id) on delete cascade)");

            // cria tabela de abastecimento
            ExecutaComandoSimples(@"create table if not exists Abastecimentos

                                  (id integer not null auto_increment primary key,
                                  data_hora datetime not null,
                                  id_fornecedor integer not null,
                                  id_produto integer not null,
                                  valor_custo decimal(10, 2) not null,
                                  qtd integer not null,
                                  total decimal(15, 2) not null,
                                  chegou boolean not null,
                                  foreign key (id_fornecedor) references Fornecedores(id) on delete cascade,
                                  foreign key (id_produto) references Produtos(id) on delete cascade)");
        }

        private static void CriaTriggers()
        {
            ExecutaComandoSimples(@"drop trigger if exists Tgr_VendaDET_Produto_Insert");
            ExecutaComandoSimples(@"drop trigger if exists Tgr_Abastecimento_Produto_Insert");
            ExecutaComandoSimples(@"drop trigger if exists Tgr_Abastecimento_ProdutoEstoque_Update");

            // trigger para diminuir o estoque de um produto
            ExecutaComandoSimples(@"create trigger Tgr_VendaDET_Produto_Insert
                                  after insert on Venda_DET
                                  for each row
                                  begin
                                  update Produtos set estoque = estoque - new.qtd
                                  where id = new.id_produto;
                                  end");

            // trigger para avisar sobre necessidade de abastecimento
            ExecutaComandoSimples(@"create trigger Tgr_Abastecimento_Produto_Insert
                                  after update on Produtos
                                  for each row
                                  begin
                                  declare qtd integer;
                                  declare valor_total decimal(15, 2);
                                  declare chegou_flag boolean;
                                  declare fora_linha_flag boolean;
                                  set chegou_flag := (select chegou from Abastecimentos
                                  where id_produto = new.id);
                                  set fora_linha_flag := (select fora_linha from Produtos
                                  where id = new.id);
                                  if ((new.estoque <= new.estoque_minimo)  
                                  and (chegou_flag is null or chegou_flag = true)
                                  and (fora_linha_flag = false)) then
                                  set qtd := (3 * new.estoque_minimo);
                                  set valor_total := (qtd * new.valor_custo);
                                  insert into Abastecimentos (data_hora, id_fornecedor, id_produto, valor_custo, qtd, total, chegou) 
                                  values (sysdate(), new.id_fornecedor, new.id, new.valor_custo, qtd, valor_total, false); 
                                  end if;
                                  end");

            // trigger para aumentar o estoque de um produto
            ExecutaComandoSimples(@"create trigger Tgr_Abastecimento_ProdutoEstoque_Update
                                  after update on Abastecimentos
                                  for each row
                                  begin
                                  if (new.chegou = true) then
                                  update Produtos set estoque = estoque + new.qtd
                                  where id = new.id_produto;
                                  end if;
                                  end");
        }

        public static void CriaUsuarioPadrao()
        {
            if (!TemAdm())
            {
                ExecutaComandoSimples(@"insert into usuarios(nome, login, senha, adm) 
                                      values('administrador', 'admin', 'admin', true)");
            }
        }

        public static bool TemAdm()
        {
            // instrução sql
            Comando = new MySqlCommand("select id from usuarios where adm = 1", Conexao);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela.Rows.Count > 0;
        }

        public static int TemUnicoAdm()
        {
            // instrução sql
            Comando = new MySqlCommand("select id from usuarios where adm = 1", Conexao);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static Tuple<int, int> VerificaUsuario(String login, String senha)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id 
                                       from usuarios 
                                       where login = ?login 
                                       and senha = ?senha 
                                       and adm = true", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?login", login);
            Comando.Parameters.AddWithValue("?senha", senha);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return new Tuple<int, int>(Convert.ToInt16(datTabela.Rows[0].ItemArray[0]), 1);
            }

            // instrução sql
            Comando = new MySqlCommand(@"select id 
                                       from usuarios 
                                       where login = ?login 
                                       and senha = ?senha", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?login", login);
            Comando.Parameters.AddWithValue("?senha", senha);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return new Tuple<int, int>(Convert.ToInt16(datTabela.Rows[0].ItemArray[0]), 0);
            }

            return new Tuple<int, int>(-1, -1);
        }

        public static DataTable ConsultaEstados(String estado)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id 'Código', 
                                       nome 'Nome' 
                                       from estados 
                                       where nome like ?estado 
                                       order by nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?estado", "%" + estado + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemEstado(string nome) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id
                                       from estados 
                                       where nome = ?nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?nome", nome);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaCidades(String cidade) {
            // instrução sql
            Comando = new MySqlCommand(@"select cid.id 'Código', 
                                       cid.nome 'Nome', 
                                       est.nome 'Estado' 
                                       from cidades cid 
                                       left join estados est on est.id = cid.id_estado 
                                       where cid.nome like ?cidade 
                                       order by cid.nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?cidade", "%" + cidade + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemCidade(string nome, int idEstado) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id  
                                       from cidades 
                                       where nome = ?nome
                                       and id_estado = ?id_estado", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?nome", nome);
            Comando.Parameters.AddWithValue("?id_estado", idEstado);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaCategorias(String categoria) {
            // instrução sql
            Comando = new MySqlCommand(@"select id 'Código', 
                                       descricao 'Nome' 
                                       from categorias 
                                       where descricao like ?categoria 
                                       order by descricao", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?categoria", "%" + categoria + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemCategoria(string descricao) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id 
                                       from categorias 
                                       where descricao = ?descricao", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?descricao", descricao);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaUsuarios(String usuario) {
            // instrução sql
            Comando = new MySqlCommand(@"select id 'Código', 
                                       nome 'Nome', 
                                       login 'Login',
                                       senha 'Senha', 
                                       adm 'Administrador'
                                       from usuarios 
                                       where nome like ?usuario
                                       order by nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?usuario", "%" + usuario + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemUsuario(String login)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id 
                                       from usuarios 
                                       where login = ?login", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?login", login);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaFornecedores(String fornecedor) {
            // instrução sql
            Comando = new MySqlCommand(@"select forn.id 'Código', 
                                       forn.razao_social 'Razão Social', 
                                       forn.fantasia 'Fantasia', 
                                       forn.cep 'CEP', 
                                       forn.rua 'Rua', 
                                       forn.numero 'Numero', 
                                       forn.complemento 'Complemento', 
                                       forn.bairro 'Bairro', 
                                       cid.nome 'Cidade', 
                                       forn.cnpj 'CNPJ', 
                                       forn.ie 'IE', 
                                       forn.fone 'Fone', 
                                       forn.celular 'Celular', 
                                       forn.email 'E-mail', 
                                       forn.representante 'Representante' 
                                       from fornecedores forn 
                                       left join cidades cid on cid.id = forn.id_cidade 
                                       where fantasia like ?fornecedor 
                                       order by fantasia", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?fornecedor", "%" + fornecedor + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemFornecedor(string cnpj)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id
                                       from fornecedores
                                       where cnpj = ?cnpj", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?cnpj", cnpj);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaClientes(String cliente) {
            // instrução sql
            Comando = new MySqlCommand(@"select cli.id 'Código', 
                                       cli.nome 'Nome', 
                                       cli.data_nasc 'Nascimento', 
                                       cli.renda 'Renda', 
                                       cli.cpf 'CPF', 
                                       cli.rg 'RG', 
                                       cli.cep 'CEP', 
                                       cli.rua 'Rua', 
                                       cli.numero 'Numero', 
                                       cli.complemento 'Complemento', 
                                       cli.bairro 'Bairro', 
                                       cid.nome 'Cidade', 
                                       cli.fone 'Fone', 
                                       cli.celular 'Celular', 
                                       cli.email 'E-mail', 
                                       cli.foto 'Foto' 
                                       from clientes cli 
                                       left join cidades cid on cid.id = cli.id_cidade 
                                       where cli.nome like ?cliente 
                                       order by cli.nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?cliente", "%" + cliente + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemCliente(string cpf) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id
                                       from clientes
                                       where cpf = ?cpf", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?cpf", cpf);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaTiposPGTO(String tipoPGTO)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id 'Código', 
                                       descricao 'Nome', 
                                       baixa_aut 'Baixa Automática' 
                                       from tipos_pgto 
                                       where descricao like ?tipo_pgto 
                                       order by descricao", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?tipo_pgto", "%" + tipoPGTO + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemTipoPGTO(string descricao) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id 
                                       from tipos_pgto 
                                       where descricao = ?descricao", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?descricao", descricao);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaProdutosDescricao(String produto) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select prod.id 'Código', 
                                       prod.fora_linha 'Fora de Linha', 
                                       prod.descricao 'Nome', 
                                       prod.codigo_barra 'Código de Barra', 
                                       cat.descricao 'Categoria', 
                                       forn.fantasia 'Fornecedor', 
                                       prod.valor_venda 'Valor Venda', 
                                       prod.valor_custo 'Valor Custo', 
                                       prod.prazo_garantia 'Prazo de Garantia', 
                                       prod.estoque 'Estoque', 
                                       prod.estoque_minimo 'Estoque Mínimo', 
                                       prod.foto 'Foto' 
                                       from produtos prod 
                                       left join categorias cat on cat.id = prod.id_categoria 
                                       left join fornecedores forn on forn.id = prod.id_fornecedor 
                                       where prod.descricao like ?produto 
                                       order by prod.descricao", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?produto", "%" + produto +"%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable ConsultaProdutosDisponiveisDescricao(String produto)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select prod.id 'Código', 
                                       prod.descricao 'Nome', 
                                       prod.valor_venda 'Valor Venda',
                                       prod.estoque 'Estoque'
                                       from produtos prod
                                       where prod.descricao like ?produto
                                       and prod.estoque > 0
                                       order by prod.descricao", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?produto", "%" + produto + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int ConsultaEstoqueProduto(int idProduto)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select estoque
                                       from produtos
                                       where id = ?id_produto", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?id_produto", idProduto);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaProdutoID(int idProduto)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select forn.id 'Código Fornecedor',
                                       forn.fantasia 'Fornecedor',
                                       prod.valor_custo 'Custo',
                                       prod.estoque_minimo 'Minimo'
                                       from produtos prod 
                                       left join fornecedores forn on forn.id = prod.id_fornecedor 
                                       where prod.id = ?id_produto", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?id_produto", idProduto);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemProduto(string codigoBarra) 
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id
                                       from produtos
                                       where codigo_barra = ?codigo_barra", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?codigo_barra", codigoBarra);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }

        public static DataTable ConsultaVendaCAB(String nomeCliente)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select vend.id 'Código', 
                                       usu.nome 'Usuário', 
                                       cli.nome 'Cliente', 
                                       vend.data_hora 'Data e Hora', 
                                       vend.total 'Total', 
                                       pgt.descricao 'Pagamento' 
                                       from venda_cab vend 
                                       left join usuarios usu on usu.id = vend.id_usuario 
                                       left join clientes cli on cli.id = vend.id_cliente 
                                       left join tipos_pgto pgt on pgt.id = vend.id_tipo_pgto 
                                       where cli.nome like ?nome_cliente 
                                       order by vend.data_hora desc", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?nome_cliente", "%" + nomeCliente + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable ConsultaVendaDET(long idVenda)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select det.id 'No Item', 
                                       prod.id 'Código Produto', 
                                       prod.descricao 'Produto', 
                                       det.vlr_unitario 'Valor Unitário', 
                                       det.qtd 'Quantidade' 
                                       from venda_det det 
                                       left join venda_cab cab on cab.id = det.id_venda 
                                       left join produtos prod on prod.id = det.id_produto 
                                       where det.id_venda = ?id_venda 
                                       order by prod.descricao", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?id_venda", idVenda);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable ConsultaAbastecimentos(string produto)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select abas.id 'Código',
                                       abas.data_hora 'Data e Hora',
                                       prod.descricao 'Produto',
                                       forn.fantasia 'Fornecedor',
                                       prod.valor_custo 'Valor Custo',
                                       abas.qtd 'Quantidade',
                                       abas.total 'Total',
                                       abas.chegou 'Chegou'
                                       from abastecimentos abas
                                       left join produtos prod on prod.id = abas.id_produto 
                                       left join fornecedores forn on forn.id = abas.id_fornecedor 
                                       where prod.descricao like ?produto 
                                       order by data_hora desc", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?produto", "%" + produto + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static int TemSolicitacaoAberta(int idProduto)
        {
            // instrução sql
            Comando = new MySqlCommand(@"select id
                                       from abastecimentos
                                       where id_produto = ?id_produto 
                                       and chegou = false", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?id_produto", idProduto);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            if (datTabela.Rows.Count == 1)
            {
                return Convert.ToInt16(datTabela.Rows[0].ItemArray[0]);
            }

            return -1;
        }
    }
}