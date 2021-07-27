using MySql.Data.MySqlClient;
using System;
// importando bibliotecas
using System.Data;

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

        public static void criaBanco() {
            // estabelecendo parâmetros para conexão
            Conexao = new MySqlConnection("server=localhost; uid=root; pwd=5971; charset=utf8;");
            Conexao.Open();

            // informando instrução sql
            Comando = new MySqlCommand("create database if not exists bd_eletromarana; use bd_eletromarana", Conexao);
            
            // executando
            Comando.ExecuteNonQuery();


            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Cidades" +
                                       "(id integer auto_increment primary key," +
                                       "nome char(40)," +
                                       "id_estado integer)", Conexao);

            // executando
            Comando.ExecuteNonQuery();

            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Estados" +
                                       "(id integer auto_increment primary key," +
                                       "nome char(2))", Conexao);

            // executando
            Comando.ExecuteNonQuery();


            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Categorias" +
                                       "(id integer auto_increment primary key," +
                                       "descricao char(30))", Conexao);

            // executando
            Comando.ExecuteNonQuery();


            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Usuarios" +
                                       "(id integer auto_increment primary key," +
                                       "nome char(40)," +
                                       "senha char(10)," +
                                       "adm boolean," +
                                       "ativo boolean)", Conexao);

            // executando
            Comando.ExecuteNonQuery();

            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Fornecedores" +
                                       "(id integer auto_increment primary key," +
                                       "razao_social char(40)," +
                                       "fantasia char(30)," +
                                       "cep char(9)," +
                                       "rua char(80)," +
                                       "numero integer," +
                                       "complemento varchar(100)," +
                                       "bairro char(30)," +
                                       "id_cidade integer," +
                                       "cnpj char(18)," +
                                       "ie char(15)," +
                                       "fone char(14)," +
                                       "celular char(15)," +
                                       "representante char(40)," +
                                       "email varchar(60))", Conexao);
             
            // executando
            Comando.ExecuteNonQuery();


            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Clientes" +
                                       "(id integer auto_increment primary key," +
                                       "nome varchar(80)," +
                                       "cep char(9)," +
                                       "rua char(80)," +
                                       "numero integer," +
                                       "complemento varchar(100)," +
                                       "bairro char(30)," +
                                       "id_cidade integer," +
                                       "cpf char(14)," +
                                       "rg char(12)," +
                                       "fone char(14)," +
                                       "celular char(15)," +
                                       "email varchar(50)," +
                                       "renda decimal(10,2)," +
                                       "data_nasc date," +
                                       "foto varchar(100))", Conexao);

            // executando
            Comando.ExecuteNonQuery();

            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Tipos_PGTO" +
                                       "(id integer auto_increment primary key," +
                                       "descricao char(40), " +
                                       "baixa_aut boolean)", Conexao);

            // executando
            Comando.ExecuteNonQuery();

            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Produtos" +
                                       "(id integer auto_increment primary key," +
                                       "descricao char(40)," +
                                       "codigo_barra char(14)," +
                                       "id_categoria integer," +
                                       "id_fornecedor integer," +
                                       "prazo_garantia integer, " +
                                       "estoque decimal(10,2)," +
                                       "estoque_minimo decimal(10,2)," +
                                       "valor_venda decimal(10,2)," +
                                       "valor_custo decimal(10,2)," +
                                       "foto varchar(100)," +
                                       "fora_linha boolean)", Conexao);

            // executando
            Comando.ExecuteNonQuery();

            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Venda_CAB" +
                                       "(id integer auto_increment primary key, " +
                                       "id_usuario integer, " +
                                       "id_cliente integer, " +
                                       "data_hora datetime, " +
                                       "total decimal(15, 2), " +
                                       "id_tipo_pgto integer)", Conexao);
            
            // executando
            Comando.ExecuteNonQuery();

            // informando instrução sql
            Comando = new MySqlCommand("create table if not exists Venda_DET" +
                                       "(id integer auto_increment primary key, " +
                                       "id_venda integer, " +
                                       "id_produto integer, " +
                                       "qtd decimal(15, 2), " +
                                       "vlr_unitario decimal(15, 2))", Conexao);

            // executando
            Comando.ExecuteNonQuery();

            // fechando conexão
            Conexao.Close();
        }

        public static int retornaNumeroUsuariosAdm()
        {
            // instrução sql
            Comando = new MySqlCommand("select id from usuarios where adm = 1", Conexao);

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela.Rows.Count; 
        }

        public static void criaUsuarioPadrao()
        {
            if (retornaNumeroUsuariosAdm() == 0)
            {
                Conexao.Open();

                Comando = new MySqlCommand("insert into usuarios(nome, senha, adm, ativo) " +
                                           "values('admin', 'admin', true, true)", Conexao);

                Comando.ExecuteNonQuery();

                Conexao.Close();
            }
        }

        public static DataTable consultaCidades(String cidade) {
            // instrução sql
            Comando = new MySqlCommand("select cid.id 'Código', " +
                                       "cid.nome 'Nome', " +
                                       "est.nome 'Estado' from cidades cid " +
                                       "left join estados est on est.id = cid.id_estado " +
                                       "where cid.nome like ?cidade order by cid.nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?cidade", "%" + cidade + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaEstados(String estado)
        {
            // instrução sql
            Comando = new MySqlCommand("select id 'Código', " +
                                       "nome 'Nome' from estados " +
                                       "where nome like ?estado order by nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?estado", "%" + estado + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaCategorias(String categoria) {
            // instrução sql
            Comando = new MySqlCommand("select id 'Código', " +
                                       "descricao 'Nome' from categorias " +
                                       "where descricao like ?categoria order by descricao", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?categoria", "%" + categoria + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaUsuarios(String usuario) {
            // instrução sql
            Comando = new MySqlCommand("select id 'Código', " +
                                       "nome 'Nome', " +
                                       "senha 'Senha', " +
                                       "adm 'Administrador' from usuarios " +
                                       "where nome like ?usuario and ativo = true order by nome", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?usuario", "%" + usuario + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static Tuple<int, int> verificaUsuario(String usuario, String senha)
        {
            // instrução sql
            Comando = new MySqlCommand("select id from usuarios " +
                                       "where nome = ?usuario and senha = ?senha and adm = true and ativo = true", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?usuario", usuario);
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
            Comando = new MySqlCommand("select id from usuarios " +
                                       "where nome = ?usuario and senha = ?senha and ativo = true", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?usuario", usuario);
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

        public static DataTable consultaFornecedores(String fornecedor) {
            // instrução sql
            Comando = new MySqlCommand("select forn.id 'Código', " +
                                       "forn.razao_social 'Razão Social', " +
                                       "forn.fantasia 'Fantasia', " +
                                       "forn.cep 'CEP', " +
                                       "forn.rua 'Rua', " +
                                       "forn.numero 'Numero', " +
                                       "forn.complemento 'Complemento', " +
                                       "forn.bairro 'Bairro', " +
                                       "cid.nome 'Cidade', " + 
                                       "forn.cnpj 'CNPJ', " +
                                       "forn.ie 'IE', " +
                                       "forn.fone 'Fone', " +
                                       "forn.celular 'Celular', " +
                                       "forn.email 'E-mail', " +
                                       "forn.representante 'Representante' from fornecedores forn " +
                                       "left join cidades cid on cid.id = forn.id_cidade " +
                                       "where fantasia like ?fornecedor order by fantasia", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?fornecedor", "%" + fornecedor + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaClientes(String cliente) {
            // instrução sql
            Comando = new MySqlCommand("select cli.id 'Código', " +
                                       "cli.nome 'Nome', " +
                                       "cli.data_nasc 'Nascimento', " +
                                       "cli.renda 'Renda', " +
                                       "cli.cpf 'CPF', " +
                                       "cli.rg 'RG', " +
                                       "cli.cep 'CEP', " +
                                       "cli.rua 'Rua', " +
                                       "cli.numero 'Numero', " +
                                       "cli.complemento 'Complemento', " +
                                       "cli.bairro 'Bairro', " +
                                       "cid.nome 'Cidade', " +
                                       "cli.fone 'Fone', " +
                                       "cli.celular 'Celular', " +
                                       "cli.email 'E-mail', " +
                                       "cli.foto 'Foto' from clientes cli " +
                                       "left join cidades cid on cid.id = cli.id_cidade " +
                                       "where cli.nome like ?cliente order by cli.nome", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?cliente", "%" + cliente + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaProdutos(String produto) {
            // instrução sql
            Comando = new MySqlCommand("select prod.id 'Código', " +
                                       "prod.fora_linha 'Fora de Linha', " +
                                       "prod.descricao 'Nome', " +
                                       "prod.codigo_barra 'Código de Barra', " +
                                       "cat.descricao 'Categoria', " +
                                       "forn.fantasia 'Fornecedor', " +
                                       "prod.valor_venda 'Valor Venda', " +
                                       "prod.valor_custo 'Valor Custo', " +
                                       "prod.prazo_garantia 'Prazo de Garantia', " +
                                       "prod.estoque 'Estoque', " +
                                       "prod.estoque_minimo 'Estoque Mínimo', " +
                                       "prod.foto 'Foto' from produtos prod " +
                                       "left join categorias cat on cat.id = prod.id_categoria " +
                                       "left join fornecedores forn on forn.id = prod.id_fornecedor " +
                                       "where prod.descricao like ?produto order by prod.descricao", Conexao);

            // definindo parâmetro da instrução
            Comando.Parameters.AddWithValue("?produto", "%" + produto +"%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados no adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaTiposPGTO(String tipo_pgto)
        {
            // instrução sql
            Comando = new MySqlCommand("select id 'Código', " +
                                       "descricao 'Nome', " +
                                       "baixa_aut 'Baixa Automática' from tipos_pgto " +
                                       "where descricao like ?tipo_pgto order by descricao", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?tipo_pgto", "%" + tipo_pgto + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }

        public static DataTable consultaVendaCAB(String nome_cliente)
        {
            // instrução sql
            Comando = new MySqlCommand("select vend.id 'Código', " +
                                       "usu.nome 'Usuário', " +
                                       "cli.nome 'Cliente', " +
                                       "vend.data_hora 'Data e Hora', " +
                                       "vend.total 'Total', " +
                                       "pgt.descricao 'Pagamento' from venda_cab vend " +
                                       "left join usuarios usu on usu.id = vend.id_usuario " +
                                       "left join clientes cli on cli.id = vend.id_cliente " +
                                       "left join tipos_pgto pgt on pgt.id = vend.id_tipo_pgto " +
                                       "where cli.nome like ?nome_cliente order by vend.data_hora", Conexao);

            // definindo parâmetro da intrução
            Comando.Parameters.AddWithValue("?nome_cliente", "%" + nome_cliente + "%");

            // adaptador recebe consulta
            Adaptador = new MySqlDataAdapter(Comando);

            // datTabela recebe dados do adaptador
            Adaptador.Fill(datTabela = new DataTable());

            return datTabela;
        }
    }
}
