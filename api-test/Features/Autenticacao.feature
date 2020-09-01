#language: pt-BR

Funcionalidade: Autenticação de Usuário

Permite que uma aplicação realize a autenticação de um usuário e fornece um token de autenticação para continuidade dos processos

Contexto: 
	Dados os usuários cadastrados
	| Id | Username | PasswordHash                                                                         | Enable |
	| 1  | user1    | AQAAAAEAACcQAAAAEMqqnv/afSfAaJoHXNQiMdk0zA+d6995ncs7senVarj6XLVu+eq2WYZaEde9En0PCQ== | true   |
	| 2  | user2    | AQAAAAEAACcQAAAAEHqSx238YMvWchQW7sKCc9xjUf/TU9H92idDwrdiQ69SmlLxfJXzuK8NQnWRC1+4AA== | false  |

	Cenário: Autentica Usuário ativo e Senha corretos 
		E que o usuário é "user1"
		E que a senha é "user1@123"
		Quando é solicitada a autenticação
		Entao retorna codigo "200" e o token com as informações do usuário

	Cenário: Autentica Usuário ativo correto e Senha incorreta
		E que o usuário é "user1"
		E que a senha é "user1@124"
		Quando é solicitada a autenticação
		Entao retorna codigo "401" e mensagem de erro "Senha incorreta"

	Cenário: Autentica Usuário inativo e Senha corretos 
		E que o usuário é "user2"
		E que a senha é "user2@123"
		Quando é solicitada a autenticação
		Entao retorna codigo "401" e mensagem de erro "Usuário não autorizado"

	Cenário: Autentica Usuário inativo correto e Senha incorreta
		E que o usuário é "user2"
		E que a senha é "user2@124"
		Quando é solicitada a autenticação
		Entao retorna codigo "401" e mensagem de erro "Usuário não autorizado"

	Cenário: Autentica Usuário incorreto e Senha correta
		E que o usuário é "user3"
		E que a senha é "user1@123"
		Quando é solicitada a autenticação
		Entao retorna codigo "404" e mensagem de erro "Usuário não cadastrado"

	Cenário: Autentica Usuário incorreto e Senha incorreta
		E que o usuário é "user3"
		E que a senha é "user1@124"
		Quando é solicitada a autenticação
		Entao retorna codigo "404" e mensagem de erro "Usuário não cadastrado"