namespace ListaTarefas.Domain.Entities;

public sealed class Tarefa : Entity
{
    public Tarefa(string titulo, string usuario, DateTime dataConclusao)
    {
        Titulo = titulo;
        Concluida = false;
        DataConclusao = dataConclusao;
        Usuario = usuario;
    }

    public string? Titulo { get; private set; }
    public bool Concluida { get; private set; }
    public DateTime DataConclusao { get; private set; }
    public string? Usuario { get; private set; }

    public void MarcarComoConcluida()
    {
        Concluida = true;
    }

    public void MarcarComoNaoConcluida()
    {
        Concluida = false;
    }

    public void AlterarTitulo(string titulo)
    {
        Titulo = titulo;
    }
}