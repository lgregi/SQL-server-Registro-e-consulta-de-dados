using System;
using System.Data.SqlClient;

namespace InsereDadosSqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define a string de conexão com o banco de dados e passa as informações de autenticação
            string connectionString = "Data Source='nome do host';Initial Catalog='nome da tabela';Integrated Security=True";

            // Cria uma nova conexão com o banco de dados utilizando o Framerwork  SqlClient
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrindo a conexão
                    connection.Open();

                    // Define as informações que serão inseridas na tabela
                    string Nome = "Luccas";
                    string id_acess = "250";
                    string Email = "@1!2!@";

                    // Cria a consulta SQL
                    string query = "INSERT INTO Acesso (id_acess, Nome, Email) VALUES (@id_acess, @Nome, @Email)";

                    // Comando criado para executar a consulta
                    SqlCommand command = new SqlCommand(query, connection);

                    // Adiciona os parâmetros da consulta
                   command.Parameters.AddWithValue("@id_acess", id_acess);
                    command.Parameters.AddWithValue("@nome", Nome);
                    command.Parameters.AddWithValue("@email", Email);

                    // Executa a consulta
                    int result = command.ExecuteNonQuery();

                    // Verifica se foi bem-sucedida
                    if (result > 0)
                    {
                        Console.WriteLine("Inserção realizada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao inserir dados");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao inserir dados no banco de dados: " + ex.Message);
                }
            }
            //string teste = "Data Source=LAPTOP-KMODCKFP;Initial Catalog=ProjetoADS;Integrated Security=True";
            // Cria uma nova conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Serve para abrir a conexão
                    connection.Open();

                    // Serve para Criar a consulta SQL
                    string teste = "SELECT * FROM Acesso";
                   
                    // Cria um novo comando para executar a consulta
                    SqlCommand tenta = new SqlCommand(teste, connection);
                    //SqlCommand teste = new SqlCommand(a, connection);

                    // Executa a consulta e armazena o resultado em um objeto de leitor de dados
                    SqlDataReader leitor = tenta.ExecuteReader();
                    //SqlDataReader te = teste.ExecuteReader();

                    // Imprime as informações da tabela enquanto houver dados
                    while (leitor.Read())
                    {
                        Console.WriteLine("ID: " + leitor[0].ToString());
                        Console.WriteLine("Nome: " + leitor[1].ToString());
                        Console.WriteLine("E-mail: " + leitor[2].ToString());
                        Console.WriteLine("-----------------------------");
                    }

                    // Fecha o leitor de dados
                    leitor.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao buscar dados no banco de dados: " + ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
    }

