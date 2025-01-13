﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimos.Add(new Emprestimo { DtEmprestimo = DateTime.Now });
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            var emprestimo = Emprestimos.LastOrDefault(e => e.DtDevolucao == null);
            if (emprestimo != null)
            {
                emprestimo.DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool Disponivel()
        {
            return Emprestimos.All(e => e.DtDevolucao != null);
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }
}
