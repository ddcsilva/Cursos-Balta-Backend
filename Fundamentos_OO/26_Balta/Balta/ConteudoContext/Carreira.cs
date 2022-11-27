namespace Balta.ConteudoContext
{
    public class Carreira : Conteudo
    {
        public Carreira()
        {
            this.Itens = new List<ItemCarreira>();
        }

        public IList<ItemCarreira> Itens { get; set; }
        public int TotalCursos => Itens.Count; // Expression Body
    }
}