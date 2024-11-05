using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            return Exemplares.Count(e => e.Disponivel());
        }

        public int QtdeEmprestimos()
        {
            return Exemplares.Sum(e => e.QtdeEmprestimos());
        }

        public double PercDisponibilidade()
        {
            if (QtdeExemplares() == 0) return 0;
            return (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }
    }
}
