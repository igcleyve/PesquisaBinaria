using System;

class Item {
    public int Id;
    public string Nome;
    public Item Esq, Dir; // Ponteiros para os próximos itens

    public Item(int id, string nome) {
        Id = id;
        Nome = nome;
    }
}

class InventarioBST {
    public Item Raiz; // O começo da árvore (Nó 400)

    public void Adicionar(int id, string nome) {
        Raiz = InserirRecursivo(Raiz, id, nome);
    }

    // Função para montar a estrutura da árvore
    private Item InserirRecursivo(Item atual, int id, string nome) {
        if (atual == null) return new Item(id, nome); // Achou vaga, cria o item

        if (id < atual.Id)
            atual.Esq = InserirRecursivo(atual.Esq, id, nome); // Menor -> Esquerda
        else if (id > atual.Id)
            atual.Dir = InserirRecursivo(atual.Dir, id, nome); // Maior -> Direita

        return atual;
    }

    public void Buscar(int idAlvo) {
        Item atual = Raiz;
        int passos = 0;

        Console.WriteLine($"\n--- Buscando ID {idAlvo} ---");

        // Loop principal da busca 
        while (atual != null) {
            passos++;
            Console.Write($"Passo {passos} (Estou no {atual.Id}): ");

            if (idAlvo == atual.Id) {
                Console.WriteLine($"ACHOU! Item: '{atual.Nome}'");
                return;
            }

            // Decide o caminho: Vai pra Direita ou Esquerda?
            if (idAlvo > atual.Id) {
                Console.WriteLine("É maior? Vai pra direita ->");
                atual = atual.Dir;
            } else {
                Console.WriteLine("É menor? Vai pra esquerda <-");
                atual = atual.Esq;
            }
        }
        Console.WriteLine("Item não encontrado.");
    }
}

class Program {
    static void Main(string[] args) {
        InventarioBST sistema = new InventarioBST();
        
        sistema.Adicionar(400, "Espada Velha");
        sistema.Adicionar(600, "Escudo de Ferro");
        sistema.Adicionar(550, "Botas Mágicas");
        sistema.Adicionar(507, "Poção de Cura");

        Console.Write("O sistema já foi carregado. Digite o ID para buscar: ");
        int id = int.Parse(Console.ReadLine());

        sistema.Buscar(id);
        
        Console.ReadKey();
    }
}