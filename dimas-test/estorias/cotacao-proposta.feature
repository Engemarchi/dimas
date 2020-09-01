#language: pt-BR

Funcionalidade: Evoluir uma cotação para o status de proposta

Evolui uma cotação para o status de proposta, não permitindo mais alterações nessa linha cotação-proposta

Cenário: Enviar email de proposta para o cliente
	Dado que a cotação está com o cliente
	E que a cotação já tem importado 1 ou mais cotações à fornecedores
	E que a cotação já tem formato de distribuição do comissionamento configurado
	E que a cotação já consegue realizar corretamente o cálculo do breakdown
	E que o usuário clicou em "Enviar email de cotação" para o cliente
	Então atualizamos o status da cotação para proposta, bloqueando novas alterações à esta linha de evolução da cotação