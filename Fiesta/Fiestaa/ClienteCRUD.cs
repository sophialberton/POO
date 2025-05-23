public class ClienteCRUD
{
    // atributos
    private List<ClienteDTO> listaClientes;
    private ClienteDTO cliente;
    private Tela tela;
    private int linCodigo, colCodigo;
    private int posicao;


    public ClienteCRUD()
    {
        this.listaClientes = new List<ClienteDTO>(); // "Banco de dados"
        this.cliente = new ClienteDTO();   // Cliente "da vez""
        //this.cliente = new ClienteDTO(1, "ze", "ze@gmail.com", "999999999");
        this.tela = new Tela();
    }

    public void executarCRUD()
    {
        // 1 - montar a tela do CRUD
        this.montarTelaCliente(31, 2);

        //preparar m registro de cliente
        this.cliente = new ClienteDTO();

        // 2 - perguntar ao usuario a chave do cliente
        this.entrarDados(1);

        // 3 - Procurar pela chave no "banco de dados" (listaClientes)
        bool achou = this.buscarCodigo();

        // 4 - Se nao achou a chave o banco de dados
        if (!achou)
        {
            //4.1 - informar que nao achou 
            this.tela.centralizar("Cliente nao encontrado. Deseja Cadastrar?(s/n):", 24, 0, 80);

            // 4.2 - perguntar se deseja cadastrar
            string resp = Console.ReadLine();

            //4.3 - se o usuario informar que deseja cadastrar
            if (resp.ToLower() == "s")
            {
                //4.3.1 - perguntar os dados restantes ao usuario
                this.entrarDados(2);

                //4.3.2 - perguntar se o usuario confirma o cadastro
                this.tela.centralizar("Confirma cadastro?(s/n): ", 24, 0, 80);
                resp = Console.ReadLine();

                // 4.3.3 - se o usuario confirmar
                if (resp.ToLower() == "s")
                {
                    //4.3.3.1 - informar a inclusão do novo cliente
                    this.listaClientes.Add(this.cliente);

                }
            }
        }

        // 5 - Se achou a chae no banco de dados
        else
        {
            // codigos 5.1 em diante
        }
        // 5.2 - perguntar ao usuario se deseja  voltar, alterar ou excluir
        //5.3 - se o usuario informou que deseja alterar
        //5.3.1 - pergunta os novos dados ao usuario
        //5.3.2 - pergunta se o usuario confirma a alteração
        //5.3.3 - se o usuario confirmou a alteração
        //5.3.3.1 - gravar a alteração que dos dados do cliente
        //5.4 - se o usuario informou que deseja excluir
        //5.4.1 - pergunta se o usuario confirma a exlcusao
        //5.4.2 - se o usuario confirmou exclusao
        //5.4.2.1 - excluir cliente
        /*
            Uma lógica possivel para o CRUD console .NET
            -------------------------------
            1 - montar a tela do CRUD
            2 - perguntar ao usuário a chave do cliente
            3 - buscar pela chave no "banco de dados" (listaClientes)
            4 - se não achou a chave no banco de dados
                4.1 - informar que nao achou
                4.2 - perguntar se deseja cadastrar
                4.3 - se o usuário informar que deseja cadastrar
                    4.3.1 - perguntar os dados restantes ao usuário
                    4.3.2 - perguntar se o usuario confirma o cadastro
                    4.3.3 - se o usuario confirmar
                        4.3.3.1 - informar a inclusão do novo cliente
            5 - se achou a chave  no banco de dados
                5.1 - mostrar os dados na tela
                5.2 - perguntar ao usuario se deseja  voltar, alterar ou excluir
                5.3 - se o usuario informou que deseja alterar
                    5.3.1 - pergunta os novos dados ao usuario
                    5.3.2 - pergunta se o usuario confirma a alteração
                    5.3.3 - se o usuario confirmou a alteração
                        5.3.3.1 - gravar a alteração que dos dados do cliente
                5.4 - se o usuario informou que deseja excluir
                    5.4.1 - pergunta se o usuario confirma a exlcusao
                    5.4.2 - se o usuario confirmou exclusao
                        5.4.2.1 - excluir cliente
        */
    }

    private bool buscarCodigo()
    {
        bool encontrei = false;
        for (int i = 0; i < this.listaClientes.Count; i++)
        {
            if (this.listaClientes[i].Codigo == this.cliente.Codigo)
            {
                encontrei = true;
                this.posicao = i;
                break;
            }
        }
        return encontrei;
    }






    private void entrarDados(int qual)
    {
        //entrada de código (chave primária / identificador único)
        if (qual == 1)
        {
            Console.SetCursorPosition(colCodigo, linCodigo);
            this.cliente.Codigo = int.Parse(Console.ReadLine());
        }

        // entrada de dados do registro
        if (qual == 2)
        {
            Console.SetCursorPosition(colCodigo, linCodigo + 1);
            this.cliente.Nome = Console.ReadLine();

            Console.SetCursorPosition(colCodigo, linCodigo + 2);
            this.cliente.Email = Console.ReadLine();

            Console.SetCursorPosition(colCodigo, linCodigo + 3);
            this.cliente.Telefone = Console.ReadLine();

        }
    }


    private void montarTelaCliente(int coluna, int linha)
    {
        int coluna2 = coluna + 30;
        List<string> cadCliente = new List<string>();
        cadCliente.Add("Código   :");
        cadCliente.Add("Nome     :");
        cadCliente.Add("Email    :");
        cadCliente.Add("Telefone :");

        this.tela.desenharMoldura(coluna, linha, coluna2, linha + 6);
        linha++;
        this.tela.centralizar("Cadastro de Cliente", linha, coluna, coluna2);

        coluna++;
        linha++;

        this.colCodigo = coluna + cadCliente[0].Length;
        this.linCodigo = linha;

        for (int i = 0; i < cadCliente.Count; i++)
        {
            Console.SetCursorPosition(coluna, linha);
            Console.Write(cadCliente[i]);
            linha++;
        }

    }

    /*private void montarTelaCliente(int coluna, int linha)
    {
        int coluna2 = coluna+30;
        this.tela.desenharMoldura(coluna, linha, coluna2, linha + 6);
        linha++;
        this.tela.centralizar("Cadastro de Cliente", linha, coluna, coluna2);
        linha++;
        coluna++;
        Console.SetCursorPosition(coluna, linha);
        Console.Write("Código  :");
        linha++;
        Console.SetCursorPosition(coluna, linha);
        Console.Write("Nome    :");
        linha++;
        Console.SetCursorPosition(coluna, linha);
        Console.Write("Email   :");
        linha++;
        Console.SetCursorPosition(coluna, linha);
        Console.Write("Telefone:");
    }*/


}