using System;
using static System.Console;

namespace TrabalhoCSharp
{
    class CadastroFuncionarios
    {
        public class Funcionarios
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string Sexo { get; set; }
            public string EstadoCivil { get; set; }
            public string EndereçoCompleto { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
        }

        // Função para não aceitar campos vazios
        static string SolicitarEntradaNaoVazia(string mensagem)
        {
            string entrada;
            do
            {
                Console.Write(mensagem);
                entrada = ReadLine().Trim(); // Remove espaços antes e depois da entrada
            } while (string.IsNullOrWhiteSpace(entrada)); // Loop enquanto a entrada estiver vazia
            return entrada;
        }

        // Função que valida o CPF
        public static bool Valida_CPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        static void Main(string[] args)
        {
            Funcionarios funcionario = new Funcionarios();

            // Solicitação do nome do funcionário
            funcionario.Nome = SolicitarEntradaNaoVazia("Nome do funcionário: ");

            // Validação e solicitação do CPF
            bool cpfValido = false;
            while (!cpfValido)
            {
                string cpfInput = SolicitarEntradaNaoVazia("CPF do funcionário: "); //entrada do CPF
                if (Valida_CPF(cpfInput)) // Validação
                {
                    funcionario.CPF = cpfInput;
                    cpfValido = true;
                }
                else
                {
                    WriteLine("CPF inválido. Digite novamente."); //loop emquanto cpf não é valido
                }
            }

            // Solicitação do sexo 
            funcionario.Sexo = SolicitarEntradaNaoVazia("Sexo do funcionário (M/F): ").ToUpper();

            // Solicitação do estado civil

            funcionario.EstadoCivil = SolicitarEntradaNaoVazia("Estado civil do funcionário: ");

            // Solicitação do estado endereço
            funcionario.EndereçoCompleto = SolicitarEntradaNaoVazia("Endereço completo do funcionário: ");

            // Solicitação do estado cidade
            funcionario.Cidade = SolicitarEntradaNaoVazia("Cidade do funcionário: ");

            // Solicitação do estado estado
            funcionario.Estado = SolicitarEntradaNaoVazia("Estado do funcionário: ");

            // Exibição dos dados do funcionário, que foram preenchidos anteriormente
            WriteLine("\n--- Dados do Funcionário ---");
            WriteLine("Nome: " + funcionario.Nome);
            WriteLine("CPF: " + funcionario.CPF);
            WriteLine("Sexo: " + funcionario.Sexo);
            WriteLine("Estado Civil: " + funcionario.EstadoCivil);
            WriteLine("Endereço Completo: " + funcionario.EndereçoCompleto);
            WriteLine("Cidade: " + funcionario.Cidade);
            WriteLine("Estado: " + funcionario.Estado);
        }
    }
}



