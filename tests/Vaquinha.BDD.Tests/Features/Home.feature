#language: pt-br

Funcionalidade: Ir para pagina de doacoes


@setUp
Cenario: Apertar botao doar agora e ir para a pagina de doacoes
 Dado que o usuario esteja acessando a pagina home
 E o usuario pressione o botao Doar agora
 Entao o sistema apresenta a pagina de doacoes
 E o sistema apresenta o titulo da pagina de doacoes
 | Titulo    |
 | Doe agora |