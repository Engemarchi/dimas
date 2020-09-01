#language: pt-BR

Funcionalidade: Autenticação de Usuário
Realiza a validação do acesso ao sistema e identificação do usuário operador

Cenário: Apresentação da tela de autenticação
	Dado que o usuário acessa a tela de autenticação
	Entao o campo de usuário existe
	Entao o campo de senha existe
	Entao o link de esqueci minha senha existe
	Entao o botão de entrar é mostrados

Cenário: Autenticação Valida
	Dado que o usuário informa o seu nome de usuário correto
	E que o usuário informa a sua senha correto
	Entao Valida usuário e senha corretos e redireciona para a página inicial
	
Cenário: Esqueci minha senha com email valido
	Dado que o usuário clica em esqueci minha senha
	E que o usuário informa a seu email
	E que o email corresponde à um usuário cadastrado
	Entao Envia um email com link para atualização de senha do usuário
	
Cenário: Autenticação Invalida senha incorreta
	Dado que o usuário informa o seu nome de usuário correto
	E que o usuário informa a sua senha incorreta
	Entao Exibe mensagem de senha incorreta
	
Cenário: Autenticação Invalida usuário incorreto
	Dado que o usuário informa o seu nome de usuário incorreto
	E que o usuário informa a sua senha correto
	Entao Exibe mensagem de usuário não cadastrado
	
Cenário: Autenticação Invalida usuário e senha incorretos
	Dado que o usuário informa o seu nome de usuário incorreto
	E que o usuário informa a sua senha incorreto
	Entao Exibe mensagem de usuário não cadastrado
	
Cenário: Esqueci minha senha com email incorreto
	Dado que o usuário clica em esqueci minha senha
	E que o usuário informa a seu email
	E que o email não corresponde à um usuário cadastrado
	Entao Exibe mensagem de usuário não cadastrado