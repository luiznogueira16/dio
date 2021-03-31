using System;
using System.Collections.Generic;
using Novel.Interface;
namespace Novel
{
    public class NovelRepositorio : IRepositorio<LNovel>
    {
        private List<LNovel> listaNovel = new List<LNovel>();
        public void Atualiza(int id, LNovel entidade)
        {
            listaNovel[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaNovel[id].Exclui();
        }

        public void Insere(LNovel entidade)
        {
            listaNovel.Add(entidade);
        }

        public List<LNovel> Lista()
        {
            return listaNovel;
        }

        public int ProximoId()
        {
            return listaNovel.Count;
        }

        public LNovel RetornaPorId(int id)
        {
            return listaNovel[id];
        }

        internal void Atualiza(LNovel novaNovel)
        {
            throw new NotImplementedException();
        }
    }
}