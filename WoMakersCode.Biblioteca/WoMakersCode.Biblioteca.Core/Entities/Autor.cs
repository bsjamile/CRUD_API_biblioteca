﻿using System.Collections.Generic;

namespace WoMakersCode.Biblioteca.Core.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
