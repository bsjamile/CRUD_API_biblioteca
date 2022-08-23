## Retornos endpoint relatorios

[HttpGet("devolucoes-em-atraso")]

Traga os livros que estao com as devolucoes em atraso e a multa a ser paga, considerando que o livro deve ser devolvido em 7 dias e o valor da multa e de 0,50 por dia.
Deve-se ter um filtro por data de inicio e data fim da devolucao (se deixar em branco deve vir todos), nome do usuario, nome do livro
Trazer no relatorio: titulo do livro, autor, usuario, data de emprestimo, data que deveria ter sido devolvido, dias em atraso e valor da multa

[HttpGet("livros-em-emprestimo")]
Traga todos os livros que estao emprestados mas nao atrasados e a possivel data de devolucao
Filtro por data de inicio e data fim
Trazer no relatorio: titulo, autor, usuario, data de emprestimo, data de devolucao

[HttpGet("livros-disponiveis")]
Traga todos os livros (titulo, autor), sua quantidade disponivel, a quantidade em emprestimo
Filtro por titulo e autor